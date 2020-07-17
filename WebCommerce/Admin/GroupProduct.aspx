<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="GroupProduct.aspx.cs" Inherits="WebCommerce.Admin.GroupProduct" %>
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
        function GotoDetail(RTVID, RTVNo, Url) {
           
        }
        function InsertRTV() {

        }
    </script>
    <section class="content-header">

        <h1 runat="server" id="lblStatus">รวมกลุ่มสินค้า
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Group Product</a></li>
            <li class="active">Create</li>
        </ol>
    </section>
    <section class="content">

        <form runat="server">

            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">รายละเอียดกลุ่มสินค้า</a></li>
                        <li><a href="#box" data-toggle="tab">Tab 2</a></li>
                        <li><a href="#files" data-toggle="tab">Tab 3</a></li>

                    </ul>


                    <div class="tab-content">
                        <div class="active tab-pane" id="main">
                            <div class="box-body">
                               
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ชื่อกลุ่มสินค้า</label>
                                            <input type="text" class="form-control" id="Text2" placeholder="" runat="server" style="width: 90%;" required>
                                        </div>

                                    </div>
                                   
                                </div>

                                <div class="row" style="background-color: azure">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>รายการสินค้า</label>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 70%;">
                                                        <input type="text" class="form-control" id="Text1" placeholder="" runat="server" required>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:Button class="btn btn-info" data-toggle="modal" data-target="#modal-info" runat="server" ID="btnCreate" Text="Create" OnClientClick="InsertRTV();"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>



                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="box">
                                            <div class="box-header">
                                                <h3 class="box-title">รายการสินค้า</h3>
                                            </div>
                                            <!-- /.box-header -->
                                            <div class="box-body">
                                                <table id="example2" class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>รหัสสินค้า</th>
                                                            <th>ชื่อสินค้า</th>
                                                            <th>จำนวน</th>
                                                            
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>A0001</td>
                                                            <td>ปากกา</td>
                                                            <td>1</td>
                                                            
                                                            <td>
                                                                <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>A0002</td>
                                                            <td>ปากกา</td>
                                                            <td>1</td>
                                                            
                                                            <td>
                                                                <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>A0003</td>
                                                            <td>ปากกา</td>
                                                            <td>1</td>
                                                            
                                                            <td>
                                                                <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="ลบ" /></td>
                                                        </tr>


                                                        <tr>
                                                            <td>Other browsers</td>
                                                            <td>All others</td>
                                                            <td>-</td>
                                                            
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
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Save" />
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
                            <h4 class="modal-title">เลือกรรายการสินค้า</h4>
                        </div>
                        <div class="modal-body">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>สินค้า</label>
                                                <div>
                                                    <asp:DropDownList ID="ddlCustomer" CssClass="form-control select2" Style="width: 80%;" runat="server">
                                                        <asp:ListItem>A0001:ปากกา</asp:ListItem>
                                                        <asp:ListItem>A0002:ปากกา</asp:ListItem>
                                                        <asp:ListItem>A0003:ปากกา</asp:ListItem>
                                                    </asp:DropDownList>
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
                                                <label>หน่วยนับ</label>
                                                <div>
                                                    <textarea class="form-control" id="txtTotalQty" runat="server" rows="1"></textarea>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                  


                                </div>
                                <!-- /.row -->
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-outline" runat="server" Text="Create" />
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

