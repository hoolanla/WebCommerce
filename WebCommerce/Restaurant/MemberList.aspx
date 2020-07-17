<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="WebCommerce.Restaurant.MemberList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>

    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
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
        function GotoDetail(UserID, UserType, RDCID) {
            window.location.href = "membercreate.aspx?PageMode=Edit&UserID=" + UserID + "&UserType=" + UserType + "&RDCID=" + RDCID;
        }
        function GotoUploadImage(UserID, UserType, RDCID) {
            window.location.href = "memberuploadimage.aspx?UserID=" + UserID + "&UserType=" + UserType + "&RDCID=" + RDCID;
        }

    </script>



    <section class="content-header">

        <h1 runat="server" id="lblStatus">Member Management
       
                                
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Administrator</a></li>
            <li class="active">Account</li>
        </ol>
    </section>
    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- SELECT2 EXAMPLE -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title"></h3>

                        <asp:Button CssClass="btn btn-info" ID="btnCreate" runat="server" Text=" Create Account  " OnClick="btnCreate_Click"></asp:Button>
                    </div>
                    
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
        <!-- /.box -->

    </section>




</asp:Content>
