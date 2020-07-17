<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SOCreate.aspx.cs" Inherits="WebCommerce.Admin.SOCreate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .example-modal .modal {
            position: relative;
            top: auto;
            bottom: auto;
            right: auto;
            left: auto;
            display: block;
            z-index: 1;
        }

        .example-modal .modal {
            background: transparent !important;
        }
    </style>
    <script type='text/javascript'>


       <%-- function SelectChange() {
            //alert('Ok');
            var data = document.getElementById("<%=ddlProduct.ClientID %>").value;
            alert(data);

            ///Get Data From Session
            var session = '<%= Session["session_cbProduct"] %>';
           
            if (session != null) {
                //Show popup
                alert('Yes');
                var sValue = '<%=HttpContext.Current.Session["session_cbProduct"]%>';
                alert(sValue);
            }
            else {
                //Show loginpage
                alert('No');
            }
        }--%>
        function GotoDetail(RTVID, RTVNo, Url) {
            //document.getElementById("ContentPlaceHolder1_txtTruckID").value = "";
            var userControl = 'Usercontrol';
            document.getElementById("ContentPlaceHolder1_Usercontrol_txtCheckDays").innerHTML = "Goto";
            document.getElementById("ContentPlaceHolder1_Usercontrol_txtEstimateBox").innerHTML = "Goto";
            document.getElementById("ContentPlaceHolder1_Usercontrol_txtRNNumber").innerHTML = "Goto";
            document.getElementById("ContentPlaceHolder1_Usercontrol_txtTotalQty").innerHTML = "Goto";
            document.getElementById("ContentPlaceHolder1_Usercontrol_txtRemark").innerHTML = "Goto";

            //window.location.href = "RTVOrderDetail.aspx?RTVID=" + RTVID + "&RTVNo=" + RTVNo;
            //window.location.href = Url;
            window.open(Url);

        }
        function InsertRTV() {

        }
    </script>
    <section class="content-header">

        <h1 runat="server" id="lblStatus">ใบสั่งซื้อ
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">S/0</a></li>
            <li class="active">Create</li>
        </ol>
    </section>

    <section class="content">

        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">รายละเอียด</a></li>
                        <li><a href="#box" data-toggle="tab">Tab 2</a></li>
                        <li><a href="#files" data-toggle="tab">Tab 3</a></li>

                    </ul>


                    <div class="tab-content">
                        <div class="active tab-pane" id="main">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Sales Channel</label>
                                            <asp:DropDownList ID="ddlRDC" CssClass="form-control select" Style="width: 30%;" runat="server">
                                                <asp:ListItem Text="Facebook" Value="1" />
                                                <asp:ListItem Text="Line" Value="2" />
                                                <asp:ListItem Text="Direct Sales" Value="3" />
                                            </asp:DropDownList>
                                            <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>รายละเอียดใบสั่งซื้อ</label>
                                            <textarea class="form-control" id="txtDetail" runat="server" style="width: 90%;" rows="6" required></textarea>
                                        </div>

                                    </div>

                                </div>

                                <div class="row" style="background-color: azure">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <h2>เลือกรายการสินค้า</h2>                                           
                                        </div>

                                    </div>
                                </div>
                                <div class="row" style="background-color: azure">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>สินค้า</label>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlProduct" CssClass="form-control select2"  runat="server" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            
                                        </div>

                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>จำนวนสินค้า</label>
                                            <input type="text" class="form-control" id="Text3" placeholder="" runat="server">
                                        </div>

                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label>หน่วยนับ</label>
                                            <input type="text" class="form-control" id="Text5" placeholder="" runat="server">
                                        </div>

                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>ราคาต่อหน่วย</label>
                                            <input type="text" class="form-control" id="Text6" placeholder="" runat="server">
                                        </div>

                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>ราคารวม</label>
                                            <input type="text" class="form-control" id="Text7" placeholder="" runat="server">
                                        </div>

                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            
                                          <asp:Button class="btn btn-info" runat="server" ID="btnCreate" Text="เพิ่มสินค้า" Style="margin-top:25px"></asp:Button>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="box">
                                            <div class="box-header">
                                                <h3 class="box-title">รายการสินค้าในใบสั่งซื้อ</h3>
                                            </div>
                                            <!-- /.box-header -->
                                            <div class="box-body">
                                                <table id="example2" class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>รหัสสินค้า</th>
                                                            <th>ชื่อสินค้า</th>
                                                            <th>จำนวน</th>
                                                            <th>ราคาต่อหน่วย</th>
                                                            <th>ราคารวม</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>A0001</td>
                                                            <td>ปากกา</td>
                                                            <td>12</td>
                                                            <td>4</td>
                                                            <td>48</td>
                                                            <td>
                                                                <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>A0002</td>
                                                            <td>ปากกา</td>
                                                            <td>12</td>
                                                            <td>4</td>
                                                            <td>48</td>
                                                            <td>
                                                                <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>A0003</td>
                                                            <td>ปากกา</td>
                                                            <td>12</td>
                                                            <td>4</td>
                                                            <td>48</td>
                                                            <td>
                                                                <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>


                                                        <tr>
                                                            <td>Other browsers</td>
                                                            <td>All others</td>
                                                            <td>-</td>
                                                            <td>-</td>
                                                            <td>U</td>
                                                            <td>
                                                                <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>
                                                    </tbody>

                                                </table>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>
                                        <!-- /.box -->

                                    </div>
                                    <!-- /.col -->
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ราคาสุทธิ</label>
                                            <input type="text" class="form-control" id="Text4" placeholder="" runat="server" style="width: 90%;">
                                        </div>

                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <asp:Button ID="btnConfirm" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnConfirm_Click" />
                                            <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="Delete" />

                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal modal-info fade" id="modal-info">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">เลือกรายการสินนค้า</h4>
                        </div>
                        <div class="modal-body">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>สินค้า</label>
                                                <div>
                                                    <select class="form-control select2" id="ddlProduct2" name="departmentsDropdown"></select>
                                                 
                                                </div>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>หน่วยนับ</label>
                                                <div>
                                                    <textarea class="form-control" id="txtCheckDays" runat="server" style="width: 50%;" maxlength="2" rows="1" onchange="checkDayToEndDate()" onkeypress="return isNumber(event)"></textarea>

                                                </div>


                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>ราคาขาย</label>
                                                <div>
                                                    <textarea class="form-control" id="txtRNNumber" runat="server" rows="1"></textarea>
                                                </div>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>จำนวนสินค้า</label>
                                                <div>
                                                    <textarea class="form-control" id="txtEstimateBox" runat="server" rows="1"></textarea>
                                                </div>


                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>ราคารวม</label>
                                                <div>
                                                    <textarea class="form-control" id="txtTotalQty" runat="server" rows="1"></textarea>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="txtRemark">หมายเหตุ</label>
                                                <textarea class="form-control" rows="2" id="txtRemark" runat="server" style="width: 80%;"></textarea>

                                            </div>

                                        </div>
                                    </div>


                                </div>
                                <!-- /.row -->
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-outline" runat="server" Text="Create" OnClick="btnSave_Click" />
                            <!--<button type="button" class="btn btn-outline">Save changes</button>-->
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

        </form>

    </section>




</asp:Content>
