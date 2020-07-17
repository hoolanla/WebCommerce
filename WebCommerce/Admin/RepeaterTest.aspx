<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RepeaterTest.aspx.cs" Inherits="WebCommerce.Admin.RepeaterTest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
        function newPage(tableName) {
            alert(tableName);
        }
    </script>

    <link href="../Content/StyleRepeater.css" rel="stylesheet" type="text/css" />

    <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group" style="padding-left:20px;padding-right:20px;padding-top:20px;padding-top:20px">
                <telerik:RadListView ID="RadListView1" runat="server" ItemPlaceholderID="DataGroupPlaceHolder3"
                    InsertItemPosition="BeforeDataGroups" AllowMultiFieldSorting="True"
                    AllowPaging="false" GroupAggregatesScope="AllItems" DataKeyNames="tableName">
                    <%-- DataKeyNames="Classification"--%>
                    <ItemTemplate>
                        <div class="rlvI">
                            <div class="category model">
                                <span class="bold_text">Menu: </span>
                                <%#Eval("menu")%>
                            </div>
                            <%-- <div class="category">
                            <span class="bold_text">Menu: </span>
                            <%#Eval("Menu")%>
                        </div>--%>
                            <div class="category">
                                <span class="bold_text">Status: </span>
                                <%#Eval("menuStatus")%>
                            </div>

                            <div class="category">
                                <span class="bold_text">Price: </span>
                                <%#Eval("Price")%>
                            </div>
                            <%--  <div class="clearfix">
                        </div>--%>
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:Panel ID="DataGroupPlaceHolder2" runat="server">
                        </asp:Panel>
                    </LayoutTemplate>

                    <GroupSeparatorTemplate>
                    </GroupSeparatorTemplate>

                    <DataGroups>
                        <telerik:ListViewDataGroup GroupField="tableName" DataGroupPlaceholderID="DataGroupPlaceHolder2"
                            SortOrder="Ascending">
                            <DataGroupTemplate>
                                <asp:Panel runat="server" ID="Panel3" CssClass="dataGroup"  GroupingText='<%# "Table Name : " + (Container as RadListViewDataGroupItem).DataGroupKey %>'  >
                                    
                                    <asp:HyperLink ID="CarImage" runat="server" CssClass="car_brand_img" Style="cursor:pointer" Font-Bold="true" 
                                        Font-Size="Medium" ForeColor="blue" Text=" View.... " ToolTip="<%# (Container as RadListViewDataGroupItem).DataGroupKey %>" href='<%# "RepeaterTable.aspx?tablename=" + (Container as RadListViewDataGroupItem).DataGroupKey %>' />
                                    <asp:PlaceHolder runat="server" ID="DataGroupPlaceHolder3"></asp:PlaceHolder>
                                    <asp:Label runat="server" ID="Label39" CssClass="groupFooter clearfix" Text='<%# "Total Price: " + (Container as RadListViewDataGroupItem).AggregatesValues["price"].ToString() %>'>
                                    </asp:Label>
                                </asp:Panel>
                            </DataGroupTemplate>
                            <GroupAggregates>
                                <telerik:ListViewDataGroupAggregate Aggregate="Sum" DataField="price" />
                            </GroupAggregates>
                        </telerik:ListViewDataGroup>
                    </DataGroups>
                </telerik:RadListView>

            </div>
        </div>
    </div>

</asp:Content>
