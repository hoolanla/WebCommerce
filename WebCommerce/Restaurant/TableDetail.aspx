<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="TableDetail.aspx.cs" Inherits="WebCommerce.Restaurant.TableDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>

    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function AddCustomer() {
            //alert("Hello");
            //$(function () {
            //    $.ajax({
            //        type: "GET",
            //        url: "../../api/RTV/GetCustomers/1",
            //        data: '',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: OnSuccess,
            //        failure: function (response) {
            //            alert("Fail : " + response.d);
            //        },
            //        error: function (response) {
            //            alert("Error : " + response.d);
            //        }
            //    });
            //});
        }
        //$(document).ready(function() {
        //$('#btnAddCustomer').click(function() {
        //    alert("Hello");
        //    });
        //});

        // $(function () {
        //    $.ajax({
        //        type: "Get",
        //        url: "MemberCreate.aspx/getCustomers",
        //        data: '{}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: OnSuccess,
        //        failure: function (response) {
        //            alert(response.d);
        //        },
        //        error: function (response) {
        //            alert(response.d);
        //        }
        //    });
        //});

        function OnSuccess(response) {
            alert('Ok');
            alert(response.d);
            //var table = $("#dvCustomers table").eq(0).clone(true);
            //var customers = response.d;
            //$("#dvCustomers table").eq(0).remove();
            //$(customers).each(function () {
            //    $(".name", table).html(this.ContactName);
            //    $(".city", table).html(this.City);
            //    $(".postal", table).html(this.PostalCode);
            //    $(".country", table).html(this.Country);
            //    $(".phone", table).html(this.Phone);
            //    $(".fax", table).html(this.Fax);
            //    $("#dvCustomers").append(table).append("<br />");
            //    table = $("#dvCustomers table").eq(0).clone(true);
            //});
        }
    </script>
    <style>
        .hidden {
            visibility: hidden;
        }
    </style>

    <section class="content-header">

        <h1 runat="server" id="lblStatus">จัดการข้อมูลโต๊ะอาหาร
          
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Administrator</a></li>
            <li class="active">Table Mng</li>
        </ol>
    </section>

    <section class="content">
         <asp:HiddenField ID="hdMemberID" runat="server"    />
        <asp:HiddenField ID="hdRestaurantID" runat="server"    />

        <div class="box-body">
            <%--<telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />--%>
            <%--<telerik:RadFormDecorator RenderMode="Lightweight" runat="server" DecoratedControls="Buttons" />--%>


            <%--<div class="box-header with-border">
            <h3 class="box-title">RDC Planning</h3>
        </div>--%>
            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">ข้อมูลโต๊ะอาหาร</a></li>
                        <li><a href="#history" data-toggle="tab">ประวัติย้อนหลัง</a></li>

                        <%--<li><a href="#files" data-toggle="tab">RDC Document</a></li>--%>
                    </ul>
                    <%--<button onclick="openWin('Test'); return false;">
            Choose Destination and date</button>--%>
                    <div class="tab-content">
                        <div class="active tab-pane" id="main">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>ชื่อร้านอาหาร</label>
                                            <input type="text" class="form-control" id="txtRestaurantName" runat="server" style="width: 30%;" readonly="readonly">
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>ชนิดของโต๊ะอาหาร</label>
                                            <asp:DropDownList ID="ddlTypeTable" CssClass="form-control select" Style="width: 30%;" runat="server">
                                                <asp:ListItem Text="สามารถเปิดบิลซ้ำได้ " Value="1" />
                                                <asp:ListItem Text="ไม่สามารถเปิดบิลซ้ำได้ " Value="2" />
                                                
                                            </asp:DropDownList>

                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>กลุ่มโต๊ะอาหาร</label>
                                            <asp:DropDownList ID="ddlCategoryTable" CssClass="form-control select" Style="width: 30%;" runat="server">
                                                <asp:ListItem Text="โต๊ะนั่ง 2 คน " Value="1" />
                                                <asp:ListItem Text="โต๊ะนั่ง 4 คน " Value="2" />
                                                <asp:ListItem Text="โต๊ะนั่ง 6 คน " Value="3" />
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>ชื่อโต๊ะอาหาร</label>
                                            <input type="text" class="form-control" id="txtTableName" runat="server" style="width: 60%;" required>
                                        </div>

                                    </div>


                                </div>

                                <div class="row">
                                   
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label for="txtRemark">หมายเหตุ</label>
                                            <textarea class="form-control" rows="2" placeholder="Remark ..." id="txtRemark" runat="server" style="width: 60%;"></textarea>

                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 50%">
                                                        <%--OnClientClick=" return confirm('Do you want to edit RDC Plan ?');"--%>
                                                        <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Save" OnClientClick=" return confirm('Are you sure ?');" OnClick="btnEdit_Click" />
                                                        <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text=" Delete " />
                                                    </td>

                                                </tr>
                                            </table>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="tab-pane" id="map">
                            Member Map
                        </div>

                    </div>
                </div>




            </div>


            <!-- /.modal-dialog -->
        </div>

        <asp:HiddenField ID="hdRTVID" runat="server" />
        <asp:HiddenField ID="hdQty" runat="server" />
    </section>

</asp:Content>
