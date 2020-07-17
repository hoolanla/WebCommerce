<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeliveryChannel.aspx.cs" Inherits="WebCommerce.Admin.DeliveryChannel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">

        <h1 runat="server" id="lblStatus">Delivery Channel          
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Delivey</a></li>
            <li class="active">Create</li>
        </ol>
    </section>
    <section class="content">

        <form runat="server">

            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">Delivery Detail</a></li>
                        <li><a href="#box" data-toggle="tab">Tab 2</a></li>
                        <li><a href="#files" data-toggle="tab">Tab 3</a></li>
                       
                    </ul>


                    <div class="tab-content">
                        <div class="active tab-pane" id="main">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Delivery</label>
                                            <asp:DropDownList ID="ddlRDC" CssClass="form-control select" Style="width: 30%;" runat="server">
                                                <asp:ListItem Text="POST Thailand" Value="1" />
                                                <asp:ListItem Text="Kerry" Value="2" />
                                                <asp:ListItem Text="Line Man" Value="3" />
                                                <asp:ListItem Text="Yourself" Value="4" />
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
