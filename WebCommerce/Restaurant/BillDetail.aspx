<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="WebCommerce.Restaurant.BillDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdRestaurantID" runat="server" />
    <asp:HiddenField ID="hdMemberID" runat="server" />
    <asp:HiddenField ID="hdOrderNo" runat="server" />
    <div class="content">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Bill No.
           
                <small runat="server" id="txtBillNo"></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Restaurant</a></li>
                <li class="active">Bill</li>
            </ol>
        </section>



        <!-- Main content -->
        <section class="invoice">
            <!-- title row -->
            <div class="row">
                <div class="col-xs-12">
                    <h2 class="page-header">
                        <p runat="server" id="txtRestaurantName"> ชื่อร้านอาหาร : AdminLTE, Inc.</p>
               
                        
                    </h2>
                </div>
                <!-- /.col -->
            </div>
            <!-- info row -->
            <div class="row invoice-info">
                <div class="col-sm-4 invoice-col">
                    ผูู้สั่งรายการ   
                
                    <address>
                        <strong runat="server" id="txtUser">..............</strong><br>
                    </address>

                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                    ชื่อโต๊ะอาหาร
               
                    <address>
                        <strong runat="server" id="txtTableName"></strong><br>
                    </address>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                    <%--<b>Invoice #007612</b><br/>
              <br/>
              <b>Order ID:</b> 4F3S8J<br/>
              <b>Payment Due:</b> 2/22/2014<br/>
              <b>Account:</b> 968-34567--%>
                </div>
                <!-- /.col -->
            </div>

            <div class="row invoice-info">
                <div class="col-sm-12 invoice-col">               
                        <br><h3 style="color:brown">รายการอาหาร</h3><br>                   
                </div>
               
            </div>
             
            <!-- /.row -->

            <!-- Table row -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>จำนวนอาหาร</th>
                                <th>ชื่อเมนูอาหาร</th>
                                <th>ขนาด</th>
                                <th>รสชาติ</th>                                
                                <th>ราคา</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repMain">
                                        <HeaderTemplate>
                                           <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("qty") %></td>
                                                <td><%# Eval("foodsName") %></td>
                                                <td><%# Eval("foodsSize") %></td>
                                                <td><%# Eval("foodsTaste") %></td>                                            
                                                <td><%# Eval("price") %></td>                                            
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </FooterTemplate>
                                    </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
              <hr />
            <div class="row">
                <!-- accepted payments column -->
                <div class="col-xs-6">
                    <p class="lead"></p>
                   <img src="../../dist/img/credit/visa.png" alt="Visa" />
                    <img src="../../dist/img/credit/mastercard.png" alt="Mastercard" />
                    <img src="../../dist/img/credit/american-express.png" alt="American Express" />
                    <img src="../../dist/img/credit/paypal2.png" alt="Paypal" />
                     <%--<p class="text-muted well well-sm no-shadow" style="margin-top: 10px;">
                        Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles, weebly ning heekya handango imeem plugg dopplr jibjab, movity jajah plickers sifteo edmodo ifttt zimbra.
             
                    </p>--%>
                </div>
              
                <!-- /.col -->
                <div class="col-xs-6">
                    <p class="lead" runat="server" id="txtCurrentDate"></p>
                    <div class="table-responsive">
                        <table class="table">
                            <tr>
                                <th style="width: 50%">ราคาอาหาร:</th>
                                <td><p runat="server" id="txtTotalPrice"></p></td>
                            </tr>
                           <%-- <tr>
                                <th>Tax (7.0%)</th>
                                <td></td>
                            </tr>                            
                            <tr>
                                <th>Total:</th>
                                <td>$265.24</td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->

            
            <!-- this row will not appear when printing -->
            <div class="row no-print">
                <div class="col-xs-12">
                    <a href="invoice-print.html" target="_blank" class="btn btn-default"><i class="fa fa-print"></i>Print</a>
                    <asp:Button ID="btnConfirm" CssClass="btn btn-success pull-right" runat="server" Text="Submit Payment"  Width="150px" OnClick="btnConfirm_Click" OnClientClick=" return confirm('Are you sure ?');"/>                                          
                    <%--<button ><i class="fa fa-credit-card"></i>Submit Payment</button>--%>
                    <%--<button class="btn btn-primary pull-right" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>--%>
                </div>
            </div>
        </section>
        <!-- /.content -->
        <div class="clearfix"></div>
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
