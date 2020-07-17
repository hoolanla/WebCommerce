<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="WebCommerce.Restaurant.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
    <link href="../Content/StyleRepeater.css" rel="stylesheet" type="text/css" />

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        
    function GotoDetail(foodID) {
        //document.getElementById("ContentPlaceHolder1_txtTruckID").value = "";                            

        window.open("MenuDetail.aspx?foodID=" + foodID);
        //window.location.href = "RDCPlanDetail.aspx?PlanID=" + PlanID + "&PlanNo=" + PlanNo;

        }



     
        function Confirm(foodID) {

              document.getElementById('<%=hdFoodID.ClientID%>').value = foodID;
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("ท่านต้องการลบเมนูนี้ ?")) {
                confirm_value.value = "Yes";
            document.getElementById('<%=hdConfirm.ClientID%>').value  = "Yes";
            } else {
                confirm_value.value = "No";
               document.getElementById('<%=hdConfirm.ClientID%>').value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

               function ConfirmRecommend(foodID) {

              document.getElementById('<%=hdFoodID.ClientID%>').value = foodID;
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("ท่านต้องการ SET ให้เป็นเมนูแนะนำ ?")) {
                confirm_value.value = "Yes";
            document.getElementById('<%=hdConfirm.ClientID%>').value  = "Yes";
            } else {
                confirm_value.value = "No";
               document.getElementById('<%=hdConfirm.ClientID%>').value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    


</script>
    <style>
        .hidden {
            visibility: hidden;
        }
    </style>

   <%-- <section class="content-header">

        <h1 runat="server" id="lblStatus"></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Administrator</a></li>
            <li class="active">Menu List</li>
        </ol>
    </section>--%>

    <section class="content">


        <asp:HiddenField ID="hdRestaurantID" runat="server" />
        <asp:HiddenField ID="hdMemberID" runat="server" />
        <asp:HiddenField ID="hdFoodID" runat="server" />
        <asp:HiddenField ID="hdConfirm" runat="server" />
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title"></h3>

                <asp:Button CssClass="btn btn-info" ID="btnCreate" runat="server" Text=" สร้างเมนูอาหาร  " OnClick="btnCreate_Click"></asp:Button>
            </div>
            <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group" style="padding-left: 20px; padding-right: 20px; padding-top: 20px; padding-top: 20px">
                                    <telerik:radlistview ID="listFoods" runat="server" ItemPlaceholderID="DataGroupPlaceHolder3"
                                        InsertItemPosition="BeforeDataGroups" AllowMultiFieldSorting="True"
                                        AllowPaging="false" GroupAggregatesScope="AllItems" DataKeyNames="foodsTypeNameLevel1" onitemdatabound="listFoods_ItemDataBound">
                                        <%-- DataKeyNames="Classification"--%>
                                        <ItemTemplate>
                                            <div class="rlvI" style="height: 350px;width: 250px;">
                                                <div class="category model">
                                                    <span class="bold_text">ชื่อเมนู: </span>
                                                    <%#Eval("foodName")%>
                                                </div>                                             
                                                <div class="category">
                                                    <span class="bold_text">ประเภท: </span>
                                                    <%#Eval("foodsTypeNameLevel2")%>
                                                </div>
                                                <div class="category">
                                                    <span class="bold_text">ราคา: </span>
                                                    <%#Eval("priceS")%>
                                                </div>
                                                <div>
                                                    <img src=<%#Eval("images")%> alt="ImageFood" style="width: 200px; margin-left: 10px;height:200px;">
                                                </div>

                                                <div class="category" style="margin-top:10px;margin-bottom:10px;align-items:center">
                                                 
                                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" ToolTip=<%#Eval("foodID")%> OnClick="btnEdit_Click" onClientClick=<%# string.Format("window.open('MenuDetailEdit.aspx?foodID={0}');", Eval("foodID")) %>  />

                                                     
                                                        <asp:Button ID="btnRecommend" runat="server" CommandName="btnRecommend" CssClass="btn btn-danger" Text="Recommend" OnClick="btnRecommend_Click" OnClientClick='<%# "ConfirmRecommend(" + Eval("foodID") + ");" %>'  />
                                                

                                                       <asp:Button ID="btnView" runat="server" CommandName="foodID" CssClass="btn btn-danger" Text="Delete" ToolTip=<%#Eval("foodID")%> OnClick="btnView_Click" OnClientClick='<%# "Confirm(" + Eval("foodID") + ");" %>'  />
                                           

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
                                            <telerik:listviewdatagroup GroupField="foodsTypeNameLevel1" DataGroupPlaceholderID="DataGroupPlaceHolder2"
                                                SortOrder="Descending">
                                                <DataGroupTemplate>
                                                    <asp:Panel runat="server" ID="Panel3" CssClass="dataGroup" GroupingText='<%# " " + (Container as RadListViewDataGroupItem).DataGroupKey %>'>


                                                       <%-- <asp:HyperLink ID="CarImage" runat="server" CssClass="car_brand_img" Style="cursor: pointer" Font-Bold="true"
                                                            Font-Size="Medium" ForeColor="blue" Text=" View.... " />--%>
                                                      
                                                        <asp:PlaceHolder runat="server" ID="DataGroupPlaceHolder3"></asp:PlaceHolder>
                                                        <asp:Label runat="server" ID="Label39" CssClass="groupFooter clearfix" Text='<%# "จำนวนเมนู: " + (Container as RadListViewDataGroupItem).AggregatesValues["price"].ToString() %>'>
                                                        </asp:Label>
                                                    </asp:Panel>
                                                </DataGroupTemplate>
                                                <GroupAggregates>
                                                    <telerik:listviewdatagroupaggregate Aggregate="Count" DataField="price" />
                                                </GroupAggregates>
                                            </telerik:listviewdatagroup>
                                        </DataGroups>
                                    </telerik:radlistview>

                                </div>
                            </div>
                        </div>

                    </div>
        </div>

         
    </section>



</asp:Content>
