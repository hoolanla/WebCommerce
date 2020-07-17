<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="Cashier.aspx.cs" Inherits="WebCommerce.Restaurant.Cashier" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/StyleRepeater2.css" rel="stylesheet" type="text/css" />
    <asp:HiddenField ID="hdRestaurantID" runat="server" />
    <asp:HiddenField ID="hdMemberID" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group" style="padding-left: 20px; padding-right: 20px; padding-top: 20px; padding-top: 20px">
                <telerik:RadListView ID="RadListView1" runat="server" ItemPlaceholderID="DataGroupPlaceHolder3"
                    InsertItemPosition="BeforeDataGroups" AllowMultiFieldSorting="True"
                    AllowPaging="false" GroupAggregatesScope="AllItems" DataKeyNames="tableName">
                    <%-- DataKeyNames="Classification"--%>
                    <ItemTemplate>
                        <div class="rlvI" style="height: 380px">
                            <div class="category model">
                                <span class="bold_text"></span>
                                <%#Eval("foodMenuName")%>
                            </div>
                            <div class="category">
                                <span class="bold_text">จำนวน:</span>
                                <%#Eval("foodMenuQty")%>
                            </div>
                            <div class="category">
                                <span class="bold_text">ขนาด: </span>
                                <%#Eval("foodMenuSize")%>
                            </div>
                            <div class="category">
                                <span class="bold_text">รสชาติ: </span>
                                <%#Eval("foodMenuTaste")%>
                            </div>
                            <div class="category">
                                <span class="bold_text">ราคา: </span>
                                <%#Eval("foodMenuPrice")%>
                            </div>
                            <div class="category">
                                <span class="bold_text">สถานะ: </span>
                                <%#Eval("foodMenuStatus")%>
                            </div>
                            <div>
                                <img src=<%#Eval("foodMenuImage")%> alt="FoodImage" style="width:200px;height:200px;margin-left:10px">

                            </div>

                            <%--<div class="category" style="margin-top:10px;margin-bottom:10px">
                                 <asp:Button ID="btnView" runat="server" CssClass="btn btn-info" Text="View" />
                            </div>--%>
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
                                <asp:Panel runat="server" ID="Panel3" CssClass="dataGroup" GroupingText='<%# "ชื่อโต๊ะอาหาร : " + (Container as RadListViewDataGroupItem).DataGroupKey %>'>


                                    <asp:HyperLink ID="CarImage" runat="server" CssClass="car_brand_img" Style="cursor: pointer" Font-Bold="true"
                                        Font-Size="Medium" ForeColor="blue" Text=" View.... " />
                                    <%--  href='<%# ".aspx?tablename=" + (Container as RadListViewDataGroupItem).DataGroupKey %>'--%>
                                    <asp:PlaceHolder runat="server" ID="DataGroupPlaceHolder3"></asp:PlaceHolder>
                                    <asp:Label runat="server" ID="Label39" CssClass="groupFooter clearfix" Text='<%# "ราคารวม: " + (Container as RadListViewDataGroupItem).AggregatesValues["foodMenuPrice"].ToString() %>'>
                                    </asp:Label>
                                </asp:Panel>
                            </DataGroupTemplate>
                            <GroupAggregates>
                                <telerik:ListViewDataGroupAggregate Aggregate="Sum" DataField="foodMenuPrice" />
                            </GroupAggregates>
                        </telerik:ListViewDataGroup>
                    </DataGroups>
                </telerik:RadListView>

            </div>
        </div>
    </div>


</asp:Content>

