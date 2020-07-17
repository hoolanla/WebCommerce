<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SOStatus1.aspx.cs" Inherits="WebCommerce.Admin.SOStatus1" %>

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

        function InsertRTV() {

        }
    </script>
    <section class="content-header">

        <h1 runat="server" id="lblStatus">ใบสั่งซื้อยังไม่จ่ายเงิน
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">S/0</a></li>
            <li class="active">ยังไม่จ่าย</li>
        </ol>
    </section>
    <section class="content">

        <form runat="server">
            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">ใบสั่งซื้อยังไม่จ่ายเงิน</a></li>
                        <li><a href="#box" data-toggle="tab">Tab 2</a></li>
                        <li><a href="#files" data-toggle="tab">Tab 3</a></li>

                    </ul>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box">
                                <div class="box-header">
                                    <h3 class="box-title">รายการใบสั่งซื้อยังไม่จ่ายเงิน</h3>
                                    
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <table id="example2" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>หมายเลขใยสั่งซื้อ</th>
                                                <th>ราคารวม</th>
                                                <th>ปลายทาง</th>
                                                <th>วันที่สร้าง</th>
                                                <th>ยอดชำระคงเหลือ</th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>A201905001</td>
                                                <td>4200</td>
                                                <td>Adddress Desination Form S/O</td>
                                                <td>2019/05/25</td>
                                                <td>4200</td>
                                                <td>
                                                    <asp:Button ID="Button5" CssClass="btn btn-primary" runat="server" Text="รายละเอียดใบสั่งซื้อ" /></td>
                                                <td>
                                                    <asp:Button class="btn btn-info" data-toggle="modal" data-target="#modal-info" runat="server" ID="Button1" Text="ยืนยันการชำระเงิน"></asp:Button>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>A201905002</td>
                                                <td>4200</td>
                                                <td>Adddress Desination Form S/O</td>
                                                <td>2019/05/25</td>
                                                <td>2000</td>
                                                <td>
                                                    <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="รายละเอียดใบสั่งซื้อ" /></td>
                                                <td>
                                                    <asp:Button class="btn btn-info" data-toggle="modal" data-target="#modal-info" runat="server" ID="Button4" Text="ยืนยันการชำระเงิน" ></asp:Button>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>A201905003</td>
                                                <td>4200</td>
                                                <td>Adddress Desination Form S/O</td>
                                                <td>2019/05/25</td>
                                                <td>3000</td>
                                                <td>
                                                    <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="รายละเอียดใบสั่งซื้อ" /></td>
                                                <td>
                                                    <asp:Button class="btn btn-info" data-toggle="modal" data-target="#modal-info" runat="server" ID="btnCreate" Text="ยืนยันการชำระเงิน"></asp:Button>

                                                </td>
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

                </div>
            </div>
            <div class="modal modal-info fade" id="modal-info">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">ยืนยันการชำระเงิน</h4>
                        </div>
                      <%--  <div class="modal-body">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>ช่องทางการชำระเงิน</label>
                                                <div>
                                                    <asp:DropDownList ID="ddlCustomer" CssClass="form-control select2" Style="width: 80%;" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>จำนวนเงินที่ควรชำระ</label>
                                                <div>
                                                    <textarea class="form-control" id="txtCheckDays" runat="server" style="width: 50%;" maxlength="2" rows="1" onchange="checkDayToEndDate()" onkeypress="return isNumber(event)"></textarea>

                                                </div>


                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>จำนวนเงินที่ชำระ</label>
                                                <div>
                                                    <textarea class="form-control" id="txtRNNumber" runat="server" rows="1"></textarea>
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
                        </div>--%>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-outline" runat="server" Text="ยืนยันการชำระเงิน" />
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
