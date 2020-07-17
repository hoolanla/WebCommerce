<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportTableQRCode.aspx.cs" Inherits="WebCommerce.Restaurant.ReportTableQRCode" %>

<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=11.0.17.222, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QRCode</title>

    <style>
    /*#rptDocument {
			position: absolute;
			left: 5px;
			right: 5px;
			top: 5px;
			bottom: 5px;
			overflow: hidden;
			font-family: Verdana, Arial;
		}*/
        .auto-style1 {
            width: 100%;
            height: 100%;
        }
    </style>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <!DOCTYPE html>
</head>
<body>
    <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>

        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
        <div class="auto-style1">
            <asp:HiddenField ID="hdRestaurantID" runat="server" />
            <telerik:ReportViewer ID="rptDocument" runat="server" Width="100%" ViewMode="PrintPreview" PrintMode="ForcePDFFile">
               
            </telerik:ReportViewer>
        </div>
    </form>
</body>
</html>
