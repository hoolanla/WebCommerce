<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SalesChannel.aspx.cs" Inherits="WebCommerce.Admin.SalesChannel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">

        <h1 runat="server" id="lblStatus">Sales Channel          
                                   
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Sales channel</a></li>
            <li class="active">Create</li>
        </ol>
    </section>
    <section class="content">

        <form runat="server">

            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs" runat="server">
                        <li class="active"><a href="#main" data-toggle="tab">Sales Channel</a></li>
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
