<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="Img/opus.jpg" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title>Electronic Document Management System (EDMS) - KUTS</title>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
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

    <link rel="stylesheet" type="text/css" href="css/bootstrap/css/bootstrap.min.css" />

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

    <style>
        /* fallback */
        @font-face {
            font-family: 'Material Icons';
            font-style: normal;
            font-weight: 400;
            src: url(https://fonts.gstatic.com/s/materialicons/v81/flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2) format('woff2');
        }

        .material-icons {
            font-family: 'Material Icons';
            font-weight: normal;
            font-style: normal;
            font-size: 24px;
            line-height: 1;
            letter-spacing: normal;
            text-transform: none;
            display: inline-block;
            white-space: nowrap;
            word-wrap: normal;
            direction: ltr;
            -webkit-font-feature-settings: 'liga';
            -webkit-font-smoothing: antialiased;
        }

        body {
            font-family: 'Varela Round', sans-serif;
        }

        .modal-backdrop {
            z-index: -1;
        }

        .modal-confirm {
            color: #636363;
            width: 325px;
        }

            .modal-confirm .modal-content {
                padding: 20px;
                border-radius: 5px;
                border: none;
            }

            .modal-confirm .modal-header {
                border-bottom: none;
                position: relative;
            }

            .modal-confirm h4 {
                text-align: center;
                font-size: 26px;
                margin: 30px 0 -15px;
            }

            .modal-confirm .form-control, .modal-confirm .btn {
                min-height: 40px;
                border-radius: 3px;
            }

            .modal-confirm .close {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-confirm .modal-footer {
                border: none;
                text-align: center;
                border-radius: 5px;
                font-size: 13px;
            }

            .modal-confirm .icon-box {
                color: #fff;
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #ef513a;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-confirm .icon-box i {
                    font-size: 56px;
                    position: relative;
                    top: 4px;
                }

            .modal-confirm.modal-dialog {
                margin-top: 80px;
            }

            .modal-confirm .btn {
                color: #fff;
                border-radius: 4px;
                background: #ef513a;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-confirm .btn:hover, .modal-confirm .btn:focus {
                    background: #da2c12;
                    outline: none;
                }

        .trigger-btn {
            display: inline-block;
            margin: 100px auto;
        }
    </style>

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
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

                <span class="login100-form-title p-b-30">Electronic Document Management System (EDMS): Kuching Urban Transportation System Project
                </span>

                <div class="wrap-input100 validate-input m-b-10" data-validate="Please Enter User ID">
                    <asp:TextBox class="input100" type="text" ID="fldStaffID" placeholder="User ID" runat="server" />
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100 validate-input m-b-15" data-validate="Please Enter Password">
                    <asp:TextBox class="input100" type="password" ID="fldPass" placeholder="Password" runat="server" />
                    <span class="focus-input100"></span>
                </div>

                <div>
                    <span class="login100-form-password p-b-15">Forgot password? <a href="/reset.aspx">Click here. </a>
                    </span>
                </div>

                <div class="container-login100-form-btn">
                    <asp:Button class="login100-form-btn" OnClick="btnLogin_Click" runat="server" ID="btnLogin" Text="Sign In" />
                </div>

                <br />

                <div>
                    <footer class="page-footer font-small mdb-color lighten-3 pt-4">
                        <div class="footer-copyright text-center py-3">
                            © 2021 Copyright - UEM Edgenta Bhd
                        </div>
                    </footer>
                </div>

                <div id="myModal" class="modal fade">
                    <div class="modal-dialog modal-confirm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                    <i class="material-icons">&#xE5CD;</i>
                                </div>
                                <h4 class="modal-title w-100 font-weight-bold">Sorry!</h4>
                            </div>
                            <div class="modal-body">
                                <p class="text-center">Username / Password is incorrect!</p>
                                <p class="text-center">Please try again.</p>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-danger btn-block" data-dismiss="modal">OK</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>

    <div id="dropDownSelect1"></div>

    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="css/animsition/js/animsition.min.js"></script>
    <script src="Scripts/esm/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="css/select2/select2.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/daterangepicker/daterangepicker.js"></script>
    <script src="Scripts/countdowntime/countdowntime.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
