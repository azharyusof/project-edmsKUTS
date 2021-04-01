<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change.aspx.cs" Inherits="_Change" %>

<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="Img/opus.jpg" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title>Electronic Document Management System (EDMS) - KUTS</title>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="css/bootstrap/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" type="text/css" href="css/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="css/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="css/animsition/css/animsition.min.css">
    <link rel="stylesheet" type="text/css" href="css/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="Scripts/daterangepicker/daterangepicker.css">
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <style type="text/css">
        .messagealert {
            width: 100%;
            position: center;
            top: 0px;
            z-index: 100000;
            padding: 0;
            font-size: 12px;
        }
    </style>

    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="../default.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</head>

<body>
    <div class="container-login100" style="background-image: url('Img/bg-01.jpg');">
        <div class="wrap-login100 p-l-55 p-r-50 p-t-50 p-b-25">
            <form class="login100-form validate-form" runat="server">
                <div class="messagealert" id="alert_container">
                </div>

                <div>
                    <span class="login100-form-password p-b-10">
                        <img src="Img/opus_logo_small.jpg" width="118" height="55" /></span>
                </div>

                <span class="login100-form-title p-b-15">Change Password
                </span>

                <div class="wrap-input100 validate-input m-b-10" data-validate="Please Enter User ID">
                    <asp:TextBox class="input100" type="text" ID="fldStaffID" placeholder="User ID" runat="server" />
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100 validate-input m-b-10" data-validate="Please Enter Old Password">
                    <asp:TextBox class="input100" type="password" ID="fldOldPwd" placeholder="Old Password" runat="server" />
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100 validate-input m-b-15" data-validate="Please Enter New Password">
                    <asp:TextBox class="input100" type="password" ID="fldNewPwd" placeholder="New Password" runat="server" />
                    <span class="focus-input100"></span>
                </div>

                <div>
                    <span class="login100-form-password p-b-15">Return Home? <a href="/Default.aspx">Click here. </a>
                    </span>
                </div>

                <div class="container-login100-form-btn">
                    <asp:Button class="login100-form-btn" OnClick="btnChange_Click" runat="server" ID="btnChange" Text="Change" />
                </div>

                <br />

                <div>
                    <footer class="page-footer font-small mdb-color lighten-3 pt-4">
                        <div class="footer-copyright text-center py-3">
                            © 2021 Copyright - UEM Edgenta Bhd
                        </div>
                    </footer>
                </div>
            </form>
        </div>
    </div>
    <div id="dropDownSelect1"></div>

    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="css/animsition/js/animsition.min.js"></script>
    <script src="Scripts/esm/popper.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="css/select2/select2.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/daterangepicker/daterangepicker.js"></script>
    <script src="Scripts/countdowntime/countdowntime.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
