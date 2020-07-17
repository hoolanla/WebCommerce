<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="DashboardCashier.aspx.cs" Inherits="WebCommerce.Restaurant.DashboardCashier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="Refresh" content="20" />  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <script>
        //$(document).ready(function () {
        //    var settings = {
        //        "async": true,
        //        "crossDomain": true,
        //        "url": "http://localhost/APIRes/api/Dashboard/getDashboardKitchen",
        //        "method": "POST",
        //        "headers": {
        //            "Content-Type": "application/json",
        //            "Access-Control-Allow-Origin": "*"
        //        },            

        //        "processData": false,
        //        "data": "{\r\n \"RestaurantID\":\"13\",\r\n \"DashboardDate\":\"1234\"\r\n}"
        //    }

        //    $.ajax(settings).done(function (response) {
        //        console.log(response);
        //        //$('#lblFoodsOrder').text = response.
        //        alert('Ok');

        //    });
            //$.ajax({
            //    type: "POST",
            //    url: 'http://localhost/APIRes/api/Dashboard/getDashboardKitchen',
            //    data: {
            //            "RestaurantID":"13",
            //            "DashboardDate":"1234"
            //    },
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (data) {
            //        alert('Ok');

            //    }

            //});
        //});

    </script>


    <div>
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Dashboard
                <asp:HiddenField ID="hdMemberID" runat="server" />
                <asp:HiddenField ID="hdRestaurantID" runat="server" />
                <small>Control Cashier</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <!-- Small boxes (Stat box) -->
            <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3 runat="server" id="lblSumPrice">80</h3>

                            <p>Sales Volume</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3 runat="server" id="lblCountTable"></h3>

                            <p>Count Table</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3 runat="server" id="lblCountUser"></h3>
                            Count User</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-red">
                        <div class="inner">
                            <h3 runat="server" id="lblFoodPending">0</h3>

                            <p>Food Pending</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-document"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
            </div>



                 <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3 runat="server" id="lblCountDrink">80</h3>

                            <p>Count Drink</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3 runat="server" id="lblCountFood"></h3>

                            <p>Count Food</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3 runat="server" id="H3"></h3>
                            Count User</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-red">
                        <div class="inner">
                            <h3 runat="server" id="H4">0</h3>

                            <p>Food Pending</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-document"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
            </div>



            <!-- /.row -->
            <!-- Main row -->
            <div class="row">
                <!-- Left col -->
                <section class="col-lg-7 connectedSortable">


                    <!-- TO DO List -->
                    <div class="box box-primary">
                        <div class="box-header">
                            <i class="ion ion-clipboard"></i>

                            <h3 class="box-title">Food Order List</h3>

                            <div class="box-tools pull-right">
                                <%-- <ul class="pagination pagination-sm inline">
                  <li><a href="#">&laquo;</a></li>
                  <li><a href="#">1</a></li>
                  <li><a href="#">2</a></li>
                  <li><a href="#">3</a></li>
                  <li><a href="#">&raquo;</a></li>
                </ul>--%>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body overflow-auto" >
                            <div class="box-body table-responsive no-padding" style="height:600px">
                                <div class="overflow-auto">
                                    <table class="table table-hover">
                                    <tr>
                                        <th>คิว</th>
                                        <th>หมายเลขบิล</th>
                                        <th>หมายเลขโต๊ะ</th>
                                        <th>จำนวนอาหาร</th>
                                        <th>ราคารวม</th>
                                        <th>สถานะ</th>
                                        <th></th>
                                    </tr>
                                    <asp:Repeater runat="server" ID="repMain" OnItemDataBound="repMain_ItemDataBound">
                                        <HeaderTemplate>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                            <td><asp:Label runat="server" ID="lblQueue" Text='<%# Eval("queue_no") %>' /></td>
                                            <td><asp:Label runat="server" ID="lblBillNo" Text='<%# Eval("billNo") %>' /></td>
                                            <td><asp:Label runat="server" ID="lblBillTableName" Text='<%# Eval("billTableName") %>' /></td>
                                            <td><asp:Label runat="server" ID="lblBillMenuCount" Text='<%# Eval("billMenuCount") %>' /></td>
                                            <td><asp:Label runat="server" ID="lblBillTotalPrice" Text='<%# Eval("billTotalPrice") %>' /></td>
                                            <td><asp:Label runat="server" ID="lblBillStatusText" Text='<%# Eval("billStatusText") %>' /></td>
                                            <td><asp:Button ID="btnConfirm" CssClass="btn btn-primary" runat="server" Text="Bill Please" ToolTip=<%# Eval("billNo") %> Width="100px" OnClick="btnConfirm_Click"/></td>                                           
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                        </FooterTemplate>
                                    </asp:Repeater>
                                  </table>
                                </div>
                                
                                    <!-- See dist/js/pages/dashboard.js to activate the todoList plugin -->
                            </div>


                        </div>
                        </div>
                </section>
                <!-- /.Left col -->
                <!-- right col (We are only adding the ID to make the widgets sortable)-->
                <section class="col-lg-5 connectedSortable">


                    <!-- solid sales graph -->
                    <div class="box box-solid bg-teal-gradient">
                        <div class="box-header">
                            <i class="fa fa-th"></i>

                            <h3 class="box-title">Sales Chart</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn bg-teal btn-sm" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                                <button type="button" class="btn bg-teal btn-sm" data-widget="remove">
                                    <i class="fa fa-times"></i>
                                </button>
                            </div>
                        </div>
                        

                    </div>
                    <!-- /.box -->


                </section>
                <!-- right col -->
            </div>
            <!-- /.row (main row) -->

        </section>
        <!-- /.content -->
    </div>

   

</asp:Content>
