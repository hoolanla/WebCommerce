<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="BillList.aspx.cs" Inherits="WebCommerce.Restaurant.BillList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group" style="padding-left: 20px; padding-right: 20px; padding-top: 20px; padding-top: 20px">
                <telerik:RadGrid ID="dgvData" runat="server" AllowPaging="True" AllowSorting="True" Width="100%" Height="100%"
                    AutoGenerateColumns="False"
                    PageSize="15" AllowFilteringByColumn="true">

                    <ClientSettings Selecting-AllowRowSelect="true">
                        <ClientEvents OnCommand="OnGridCommand" />
                    </ClientSettings>


                    <MasterTableView TableLayout="Fixed">

                        <PagerStyle PageSizes="5,10,15,20,50" PagerTextFormat="All {4}<strong>{5}</strong> Records"
                            PageSizeLabelText="RTV Order per page:" />

                        <Columns>
                            <telerik:GridBoundColumn DataField="ID" HeaderText="No" UniqueName="ID"
                                Visible="True">
                                <HeaderStyle Width="0" />
                                <ItemStyle Width="0" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BillNo" HeaderText="Bill No" UniqueName="GSOrderNo"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="true" ItemStyle-Font-Size="Large" FilterControlWidth="80%">
                                <HeaderStyle Width="160px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BillTableName" HeaderText="Tabel Name" UniqueName="RTVData" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large" FilterControlWidth="80%" HeaderStyle-Font-Bold="true"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BillMenuCount" HeaderText="Menu Count" UniqueName="CustName" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large" FilterControlWidth="80%" HeaderStyle-Font-Bold="true"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BillTotalPrice" HeaderText="Total Price" UniqueName="BranchName" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large" FilterControlWidth="80%" HeaderStyle-Font-Bold="true"
                                AutoPostBackOnFilter="false" CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="BillStatusText" HeaderText="Status" UniqueName="status" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large" FilterControlWidth="80%" HeaderStyle-Font-Bold="true"
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


                </telerik:RadGrid>
            </div>
        </div>

    </div>




</asp:Content>
