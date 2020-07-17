<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="TableMng.aspx.cs" Inherits="WebCommerce.Restaurant.TableMng" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:radscriptmanager id="RadScriptManager2" runat="server"></telerik:radscriptmanager>
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
        //function GotoDetail(RTVID, RTVNo, Url) {
        //    //document.getElementById("ContentPlaceHolder1_txtTruckID").value = "";
        //    var userControl = 'Usercontrol';
        //    document.getElementById("ContentPlaceHolder1_Usercontrol_txtCheckDays").innerHTML = "Goto";
        //    document.getElementById("ContentPlaceHolder1_Usercontrol_txtEstimateBox").innerHTML = "Goto";
        //    document.getElementById("ContentPlaceHolder1_Usercontrol_txtRNNumber").innerHTML = "Goto";
        //    document.getElementById("ContentPlaceHolder1_Usercontrol_txtTotalQty").innerHTML = "Goto";
        //    document.getElementById("ContentPlaceHolder1_Usercontrol_txtRemark").innerHTML = "Goto";

        //    //window.location.href = "RTVOrderDetail.aspx?RTVID=" + RTVID + "&RTVNo=" + RTVNo;
        //    //window.location.href = Url;
        //    window.open(Url);

        //}
        function Insert() {
            //document.getElementById("ContentPlaceHolder1_txtCreateTableID").innerHTML = "";

            //document.getElementById("ContentPlaceHolder1_txtTruckID").value = "";                            
            //document.getElementById("ContentPlaceHolder1_txtTruckLicense").innerHTML = "";
            //document.getElementById("ContentPlaceHolder1_txtRemark").innerHTML = "";            
        }
    </script>
    <section class="content">
        <asp:HiddenField ID="hdMemberID" runat="server"    />
        <asp:HiddenField ID="hdRestaurantID" runat="server"    />
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title"></h3>
                <table>
                    <tr>
                        <td style="text-align:left;width:50%">
                            <asp:Button class="btn btn-info" data-toggle="modal" data-target="#modal-info" runat="server" ID="btnCreate" Text=" สร้างโต๊ะอาหาร  " OnClick="btnCreate_Click"></asp:Button>
                        </td>
                        <td style="text-align:right;width:50%">
                            <asp:Button class="btn btn-success" runat="server" ID="btnPrintQRCode" Text=" พิมพ์ QRCode  " OnClick="Button1_Click" ></asp:Button>
                        </td>
                    </tr>
                </table>
                

            </div>
     
            <div class="box-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <%--<label>Truck List</label>--%>
                            <telerik:radgrid id="dgvData" runat="server" allowpaging="True" allowsorting="True" width="100%" height="100%"
                                autogeneratecolumns="False"
                                pagesize="15" allowfilteringbycolumn="true">

                    <ClientSettings Selecting-AllowRowSelect="true">
                        <ClientEvents OnCommand="OnGridCommand" />
                    </ClientSettings>


                    <MasterTableView TableLayout="Fixed">

                        <PagerStyle PageSizes="5,10,15,20,50" PagerTextFormat="All {4}<strong>{5}</strong> Records"
                            PageSizeLabelText="RTV Order per page:" />

                        <Columns>
                            <telerik:GridBoundColumn DataField="TableID" HeaderText="No" UniqueName="ID"
                                Visible="True">
                                <HeaderStyle Width="0" />
                                <ItemStyle Width="0" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TableName" HeaderText=" ชื่อโต๊ะ " UniqueName="GSOrderNo"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="true" ItemStyle-Font-Size="Large" FilterControlWidth="80%">
                                <HeaderStyle Width="160px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TableRemark" HeaderText="หมายเหตุ" UniqueName="RTVData" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large" FilterControlWidth="80%" HeaderStyle-Font-Bold="true"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                          
                          
                            <telerik:GridTemplateColumn UniqueName="btnEdit" AllowFiltering="false" ItemStyle-Width="80px" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <button type="button" class="btn btn-success" id="btnClick" runat="server">
                                        Detail             
                                    </button>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>

                        </Columns>



                    </MasterTableView>


                </telerik:radgrid>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!-- /.box -->

    </section>

    <%-- <div class="modal modal-info fade" id="modal-info">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">ข้อมูลโต๊ะอาหาร</h4>
                </div>
                <div class="modal-body">
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>หมายเลขโต๊ะ</label>
                                        <div>
                                            <textarea class="form-control" id="txtCreateTableID" placeholder="หมายเลขโต๊ะ" runat="server" rows="1"></textarea>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>รายละเอียดโต๊ะ</label>
                                        <div>
                                            <textarea class="form-control" id="txtCreateTableDetail" placeholder="รายละเอียดโต๊ะ ..." runat="server" rows="1"></textarea>
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
                    <asp:Button ID="btnSave" CssClass="btn btn-outline" runat="server" Text="Create"  />
                    <!--<button type="button" class="btn btn-outline">Save changes</button>-->
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>--%>
</asp:Content>
