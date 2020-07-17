<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PaymentChannel.aspx.cs" Inherits="WebCommerce.Admin.PaymentChannel" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">

        <h1 runat="server" id="lblStatus">Payment Channel          
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Pament</a></li>
            <li class="active">Create</li>
        </ol>
    </section>
    <section class="content">

        <form runat="server">

            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">Payment Detail</a></li>
                        <li><a href="#box" data-toggle="tab">Tab 2</a></li>
                        <li><a href="#files" data-toggle="tab">Tab 3</a></li>
                        <li><a href="#image" data-toggle="tab">Tab 4</a></li>
                        <%--<li><a href="#signature" data-toggle="tab">RTV Signature</a></li>--%>
                        <li><a href="#document" data-toggle="tab">Tab 5</a></li>
                    </ul>


                    <div class="tab-content">
                        <div class="active tab-pane" id="main">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Payment</label>
                                            <asp:DropDownList ID="ddlRDC" CssClass="form-control select" Style="width: 30%;" runat="server">
                                                <asp:ListItem Text="กสิกร" Value="1" />
                                                <asp:ListItem Text="กรุงไทย" Value="2" />
                                                <asp:ListItem Text="เงินสด" Value="3" />
                                            </asp:DropDownList>
                                            <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                                        </div>

                                    </div>
                                </div>
                                 <div class="row">
                                        <div class="col-md-12">

                                            <div class="form-group">
                                                <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Save" />
                                                <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="Delete"  />

                                            </div>

                                        </div>
                                    </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </form>

    </section>


</asp:Content>
