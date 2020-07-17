<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RepeaterTable.aspx.cs" Inherits="WebCommerce.Admin.RepeaterTable" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/StyleRepeater2.css" rel="stylesheet" type="text/css" />

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

                             <div class="category" style="margin-top:10px">
                                 <asp:Button ID="btnView" runat="server" CssClass="btn btn-info" Text="View" />
                            </div>
                           <div class="category">
                              
                            </div>
                          
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
                                        Font-Size="Medium" ForeColor="blue" Text=" View.... " ToolTip="<%# (Container as RadListViewDataGroupItem).DataGroupKey %>" href='<%# "SOCREATE.aspx?tablename=" + (Container as RadListViewDataGroupItem).DataGroupKey %>' />
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
