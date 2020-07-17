<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="WebCommerce.Restaurant.MemberDetail" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBKXlqK86p53fhELYnwWI5xoF-gaPkjUxs" type="text/javascript"></script>


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

     
        #map-canvas{
            width:400px;
            height:500px;
        }




    </style>

    <section class="content-header">

        <h1 runat="server" id="lblStatus">รายละเอียดผู้ใช้งาน
          
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Administrator</a></li>
            <li class="active">Member Mng</li>
        </ol>
    </section>

    <section class="content">
        <asp:HiddenField ID="hdRestaurantID" runat="server" />
        <asp:HiddenField ID="hdMemberID" runat="server" />
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
            <ContentTemplate>
                <div class="box-body">
                    <div class="col-md-12">
           

                         
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        ชื่อ
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtName" class="form-control" maxlength="100" runat="Server" id="txtContactName" />
                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        นามสกุล
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtLastname" class="form-control" maxlength="100" runat="Server" id="txtContactLastname" />
                                                    </div>
                                                </div>
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        เลขที่ 
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtAddrNo" class="form-control" maxlength="100" runat="Server" id="txtAddressNo" />
                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        หมู่ที่
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtMoo" class="form-control" maxlength="100" runat="Server" id="txtAddressMoo" />
                                                    </div>
                                                </div>
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        ตรอก/ซอย 
										
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtSoi" class="form-control" maxlength="50" runat="Server" id="txtAddressSoi" />
                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        ถนน
										
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtRoad" class="form-control" maxlength="50" runat="Server" id="txtAddressRoad" />
                                                    </div>
                                                </div>
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        จังหวัด 
										
                                                    </label>
                                                    <div class="col-md-4">

                                                        <asp:DropDownList CssClass="form-control select" Style="width: 100%;" runat="server" ID="ddlProvince" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                                        </asp:DropDownList>


                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        อำเภอ/เขต 
                                                    </label>
                                                    <div class="col-md-4">

                                                        <asp:DropDownList CssClass="form-control select" Style="width: 100%;" runat="server" ID="ddlAmphur" AutoPostBack="true" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged">
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        ตำบล/แขวง  
                                                    </label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList CssClass="form-control select" Style="width: 100%;" runat="server" ID="ddlTumbon">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        รหัสไปรษณีย์ 
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtMobile" class="form-control " maxlength="10" runat="server" id="txtZipCode" />
                                                    </div>
                                                </div>
                                                <div class="row form-group">
                                                    <label class="col-form-label text-left col-md-2">
                                                        โทรศัพท์
                                                    </label>
                                                    <div class="col-md-4">
                                                        <input type="text" name="txtTel" class="form-control" maxlength="20" runat="Server" id="txtTel" />
                                                    </div>
                                                    <label class="col-form-label text-left col-md-2">
                                                        โทรศัพท์มือถือ 
									
                                                    </label>
                                                    <div class="col-md-4 tooltip2">
                                                        <input type="text" name="txtMobile" class="form-control " maxlength="10" runat="server" id="txtPhone" />

                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                               

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>ชื่อร้านอาหาร</label>
                                                    <input type="text" class="form-control" id="txtRestaurantName" runat="server" style="width: 30%;">
                                                </div>

                                            </div>
                                        </div>



                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">รูปภาพอาหาร </label>
                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>--%>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="imgFood" runat="server" Width="200px" Height="200px" BorderStyle="Solid" BorderWidth="2px" />
                                                 <%--ImageUrl="~/ImageTemp/User.png"--%>
                                            </td>
                                            <td></td>
                                            <td style="vertical-align: bottom; margin-left: 50px">
                                                <asp:FileUpload ID="FileUpload1" runat="server" OnDisposed="FileUpload1_Disposed" /></td>
                                            <td style="vertical-align: bottom; margin-left: 10px">
                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" /></td>
                                        </tr>

                                    </table>
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>


                        </div>


                    </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>สถานที่ตั้ง</label>


                                                       <div id="map-canvas"></div>



                                                </div>

                                            </div>
                                        </div>


                                        
    
        <div class="form-group">
                <div class="row">
      <label class="control-label col-sm-2" for="Des">LAT LNG:</label>
      <div class="col-sm-10">          
        <input type="text" class="form-control" id="txtLatLng" placeholder="Test" name="txtLatLng">
      </div>
       </div>
    </div>



                                            <input type="hidden"  id="hid_email" value="prakasit.y@gmail.com"><br />
    <input type="hidden"  id="hid_lat" runat="server" ClientIDMode="Static"><br />
    <input type="hidden"  id="hid_lng" runat="server" ClientIDMode="Static"><br />






                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <%--OnClientClick=" return confirm('Do you want to edit RDC Plan ?');"--%>
                                                                <%-- <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Save" />
                                                        <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text=" Delete " />--%>
                                                            </td>

                                                        </tr>
                                                    </table>

                                                </div>
                                            </div>
                                        </div>

                           
                              


                      



                            <br />
                            <div class="row form-group">
                                <label class="col-form-label text-left col-md-2">
                                </label>
                                <div class="col-md-4">
                                     <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save"  OnClick="btnSave_Click" />
                                            &nbsp &nbsp &nbsp
                                    <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                 
                            
                            
                                </div>
                                <%--<label class="col-form-label text-left col-md-2">
                        </label>
                        <div class="col-md-4 tooltip2">
                        </div>--%>
                            </div>
                            <br />
                            <br />




                        <!-- /.modal-dialog -->
                    </div>
                </div>

                <asp:HiddenField ID="hdRTVID" runat="server" />
            </ContentTemplate>
   <%--     </asp:UpdatePanel>--%>
    </section>

    

                      <script>
                    
                          if ($('#hid_lat').val().length != 0) {
                              var valueLat = parseFloat($('#hid_lat').val())
                              var valueLng = parseFloat($('#hid_lng').val())
                              var map = new google.maps.Map(document.getElementById('map-canvas'), {
                                  center: {
                                      lat:  valueLat,
                                      lng:  valueLng
                                  },
                                  zoom: 15
                              });
                              var marker = new google.maps.Marker(
                                  {
                                      position: {
                                          lat:  valueLat,
                                          lng:  valueLng
                                      },

                                      map: map,
                                      draggable: true

                                  });

                                      google.maps.event.addListener(marker, 'dragend', function () {
                                  var lat = marker.getPosition().lat();
                                  var lng = marker.getPosition().lng();
                                  $('#hid_lat').val(lat);
                                  $('#hid_lng').val(lng);
                                  $('#txtLatLng').val(lat + " " + lng);
                              });
                          }
                          else {
                              var map = new google.maps.Map(document.getElementById('map-canvas'), {
                                  center: {
                                      lat: 13.746425113738958,
                                      lng: 100.51145540237428
                                  },
                                  zoom: 15
                              });
                              var marker = new google.maps.Marker(
                                  {
                                      position: {
                                          lat: 13.746425113738958,
                                          lng: 100.51145540237428
                                      },

                                      map: map,
                                      draggable: true

                                  });
                              google.maps.event.addListener(marker, 'dragend', function () {
                                  var lat = marker.getPosition().lat();
                                  var lng = marker.getPosition().lng();
                                  $('#hid_lat').val(lat);
                                  $('#hid_lng').val(lng);
                                  $('#txtLatLng').val(lat + " " + lng);
                              });
                          }
    </script>

</asp:Content>
