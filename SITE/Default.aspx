<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="Img/logo_only.png"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title>Opus Group Berhad</title>
</head>
<body>
    <form id="formLogin" runat="server">
        <br /><br /><br /><br />
        <table border="0" width="300" align="center">
        <tr>
            <td>
                <div class="panel panel-danger">
                <div class="panel-heading">User Authentication</div>
                <div class="panel-body">
                    <table border="0" align="center" width="100%">
                    <tr>
                        <td align="center"><img src="Img/opus_logo.jpg" width="118" height="55" /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;<br /></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group input-group-sm">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            <asp:TextBox ID="fldStaffID" runat="server" CssClass="form-control input-sm" placeholder="Please enter Staff ID"></asp:TextBox>
                            </div>
                            <div id="errDvfldStaffID" runat="server">
                                <asp:Label ID="errfldStaffID" runat="server" Text='Staff ID is required !' CssClass="input-sm" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group input-group-sm">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="fldPass" runat="server" CssClass="form-control input-sm" TextMode="Password" placeholder="Please enter Password"></asp:TextBox>
                            </div>
                            <div id="errDvfldPass" runat="server">
                                <asp:Label ID="errfldPass" runat="server" Text='Password is required !' CssClass="input-sm" ForeColor="Red"></asp:Label>
                            </div>                         
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="form-control btn btn-danger btn-sm" Width="75" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                    </table>
                </div>
                </div>
            </td>
        </tr>
        </table>
        <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="Scripts/jquery-2.1.1.min.js" />
        <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
    </Scripts>
    </asp:ScriptManager>

    </form>
  
</body>
</html>