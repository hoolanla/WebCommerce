<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/Restaurant.Master" AutoEventWireup="true" CodeBehind="MenuDetailEdit.aspx.cs" Inherits="WebCommerce.Restaurant.MenuDetailEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content-header">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
        <h1 runat="server" id="lblStatus">สร้างเมนูอาหาร
       
                            
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Administrator</a></li>            
            <li class="active">eMenu</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <asp:HiddenField ID="hdMemberID" runat="server" />
        <asp:HiddenField ID="hdRestaurantID" runat="server" />
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-primary">
            <div class="box-header with-border" style="margin-left: 20px">
                <h3 class="box-title">ข้อมูลเมนูอาหาร</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body" style="margin-left: 30px">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">ชื่อร้านค้า </label>
                            <input type="text" class="form-control" id="txtRestaurant" runat="server" style="width: 30%;" readonly>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="txtUsername">กลุ่มเมนูอาหาร </label>
                           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <asp:DropDownList ID="ddlCategoryLV1" CssClass="form-control select" Style="width: 80%;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryLV1_SelectedIndexChanged">
                                        <asp:ListItem Text="เครื่องดื่ม " Value="1" />
                                        <asp:ListItem Text="อาหาร " Value="2" />
                                        <asp:ListItem Text="สเต็ก" Value="3" />
                                    </asp:DropDownList>
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>

                        </div>

                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="txtUsername">กลุ่มย่อย </label>
                            <asp:DropDownList ID="ddlCategoryLV2" CssClass="form-control select" Style="width: 80%;" runat="server">
                                <asp:ListItem Text="เครื่องดื่ม " Value="1" />
                                <asp:ListItem Text="อาหาร " Value="2" />
                                <asp:ListItem Text="สเต็ก" Value="3" />
                            </asp:DropDownList>
                        </div>

                    </div>
                    <%--<div class="col-md-12">
                       <div class="form-group">
                            <label for="txtUsername">ขนาดบรรรจุ </label>
                            <asp:DropDownList ID="DropDownList3" CssClass="form-control select" Style="width: 40%;" runat="server">
                                <asp:ListItem Text="เครื่องดื่ม " Value="1" />
                                <asp:ListItem Text="อาหาร " Value="2" />
                                <asp:ListItem Text="สเต็ก" Value="3" />
                            </asp:DropDownList>
                        </div>

                    </div>--%>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">ชื่อเมูนูอาหาร </label>
                            <input type="text" class="form-control" id="txtMenuName" placeholder="ชื่อเมูนูอาหาร" style="width: 70%;" runat="server">
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">รายละเอียดเมูนูอาหาร </label>
                            <input type="text" class="form-control" id="txtMenuDescription" placeholder="รายละเอียดเมนูอาหาร" style="width: 70%;" runat="server">
                        </div>

                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="txtPriceS">ราคาอาหาร [S] </label>
                            <input type="number" class="form-control" id="txtPriceS" placeholder="ราคาอาหาร [S]" style="width: 60%;" runat="server">
                        </div>

                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="txtPriceM">ราคาอาหาร [M] </label>
                            <input type="number" class="form-control" id="txtPriceM" placeholder="ราคาอาหาร [M]" style="width: 60%;" runat="server">
                        </div>

                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="txtPriceL">ราคาอาหาร [L] </label>
                            <input type="number" class="form-control" id="txtPriceL" placeholder="ราคาอาหาร [L]" style="width: 60%;" runat="server">
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">รูปภาพอาหาร </label>
                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>--%>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="imgFood" runat="server" Width="200px" Height="200px" BorderStyle="Solid" BorderWidth="2px" />
                                                 <%--ImageUrl="~/ImageTemp/User.png"--%>
                                            </td>
                                            <td></td>
                                            <td style="vertical-align: bottom; margin-left: 50px">
                                                <asp:FileUpload ID="FileUpload1" runat="server" OnDisposed="FileUpload1_Disposed" /></td>
                                            <td style="vertical-align: bottom; margin-left: 10px">
                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" /></td>
                                        </tr>

                                    </table>
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>


                        </div>


                    </div>
                     <div class="col-md-2">
                        <div class="form-group">
                            <label for="txtUsername">สถานะเมนูแนะนำ </label>
                            <asp:DropDownList ID="ddlRecommend" CssClass="form-control select" Style="width: 60%;" runat="server">
                                <asp:ListItem Text="Activate " Value="1" />
                                <asp:ListItem Text="DeActivate " Value="0" />

                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="txtUsername">สถานะ </label>
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control select" Style="width: 60%;" runat="server">
                                <asp:ListItem Text="Activate " Value="1" />
                                <asp:ListItem Text="DeActivate " Value="0" />

                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtUsername">หมายเหตุ </label>
                            <input type="text" class="form-control" id="txtMenuRemark" placeholder="หมายเหตุ" style="width: 80%;" runat="server">
                        </div>

                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Create" OnClick="btnSave_Click" OnClientClick=" return confirm('Are you sure ?');" />
                            <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" />
                        </div>
                    </div>

                </div>
                <!-- /.row -->
            </div>

        </div>
        <!-- /.box -->



        <!-- /.row -->

    </section>


</asp:Content>
