<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_AdminMaster.master" AutoEventWireup="true" CodeFile="Edit_Project.aspx.cs" Inherits="ADMIN_Edit_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function successModal() {
            $('#SuccessModal').modal('show');
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            font-size: 14px;
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
                background: #82ce34;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-confirm .icon-box i {
                    font-size: 58px;
                    position: relative;
                    top: 3px;
                }

            .modal-confirm.modal-dialog {
                margin-top: 80px;
            }

            .modal-confirm .btn {
                color: #fff;
                border-radius: 4px;
                background: #82ce34;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-confirm .btn:hover, .modal-confirm .btn:focus {
                    background: #6fb32b;
                    outline: none;
                }

        .trigger-btn {
            display: inline-block;
            margin: 100px auto;
        }
    </style>

    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">ADMINISTRATOR MODULE</h1>
                <h3 class="font-weight-bold text-muted">EDIT PROJECT</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Project Details</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="50" Height="10"></asp:TableCell>
                            <asp:TableCell Width="175" Height="10"></asp:TableCell>
                            <asp:TableCell Width="25"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblProjectCode" runat="server" Text="Project Code" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="lblPCode" runat="server" CssClass="form-control form-control-sm" Width="150" Enabled="false"></asp:TextBox>
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control input-sm" Width="20" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblProjectDesc" runat="server" Text="Project Description" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldPDesc" runat="server" CssClass="form-control form-control-sm" Width="385"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblPM" runat="server" Text="Project Manager" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldPMgr" runat="server" CssClass="form-control form-control-sm" Width="385"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <div class="col-sm-12 text-center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-success btn-md center-block font-weight-bold" Width="100" OnClick="btnUpdate_Click"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary btn-md center-block font-weight-bold" Width="100" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:Button>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-danger btn-md center-block font-weight-bold" Width="100" Visible="false"></asp:Button>
                    </div>

                    <hr />

                    <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
                        <asp:TableRow>
                            <asp:TableCell Width="50" Height="10"></asp:TableCell>
                            <asp:TableCell Width="100" Height="10"></asp:TableCell>
                            <asp:TableCell Width="20"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell ColumnSpan="3" Height="2">
                                <p class=" text-left small">
                                    <asp:Label ID="lblNotes" runat="server" Text=" Notes:" CssClass="font-weight-bold small fa fa-info-circle" />
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="lbl5" runat="server" Text="1. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="lbl9" runat="server" Text="Update " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="button to update the changes." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="Label2" runat="server" Text="1. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="Back " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="button to return to the previous screen." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>

        <footer class="pt-4 my-md-5 pt-md-5 border-top">
            <div class="row">
                <div class="col-12 col-md">
                    <small class="d-block mb-3 text-muted">© 2021 Copyright - UEM Edgenta Bhd</small>
                </div>
            </div>
        </footer>

        <div id="SuccessModal" class="modal fade">
            <div class="modal-dialog modal-confirm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE876;</i>
                        </div>
                        <h4 class="modal-title w-100">Success!</h4>
                    </div>
                    <div class="modal-body">
                        <p class="text-center">Project has been successfully updated.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button class="btn btn-success btn-block" ID="btnSuccess" runat="server" data-dismiss="modal" Text="OK" UseSubmitBehavior="false" OnClick="btnSuccess_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

