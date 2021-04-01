<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="Out_Booking_No.aspx.cs" Inherits="SITE_Outgoing_Out_Booking_No" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">OUTGOING</h1>
                <h3 class="font-weight-bold text-muted">BOOKING NO.</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Outgoing Details</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="50"></asp:TableCell>
                            <asp:TableCell Width="175" Height="10"></asp:TableCell>
                            <asp:TableCell Width="25"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl1" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblDateTakenDraft" runat="server" Text="Date Taken / Draft" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateTaken" runat="server" width="220" class="dtTaken form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblAddressee" runat="server" Text="Addressee" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldAddressee" runat="server" CssClass="form-control form-control-sm text-center" Width="400" OnSelectedIndexChanged="fldAddressee_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <div class="input-group-prepend">
                                        <asp:Label ID="lblAddresseeCode" runat="server" CssClass="form-control-sm font-weight-bold" Width="100" BackColor="LightGray"></asp:Label>
                                    </div>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblRefNo" runat="server" Text="Out Reference No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRefNo" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl2" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblOriginator" runat="server" Text="Originator" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldOriginator" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDateDoc" runat="server" Text="Date of Document" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDocDate" runat="server" width="220" class="dtDoc form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldPackage" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldPackage_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewPackage" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDept" runat="server" Text="Department" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldDepartment" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewDepartment" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldSubject" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblIndex" runat="server" Text="File Index" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldIndex" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldPackage_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewIndex" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblRemark" runat="server" Text="DC Remark" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRemarks" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblSent" runat="server" Text="Sent To" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldSentTo" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <br />

                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnSubmit_Click"></asp:Button>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnReset_Click"></asp:Button>
                        </div>
                    </div>

                    <hr />

                    <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
                        <asp:TableRow>
                            <asp:TableCell Width="100" Height="10"></asp:TableCell>
                            <asp:TableCell Width="20"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" Height="2">
                                <p class=" text-left small">
                                    <asp:Label ID="lblNotes" runat="server" Text="Notes:" CssClass="font-weight-bold small" />
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="lbl5" runat="server" Text="1. " CssClass="small"></asp:Label>
                                    <asp:Label ID="lbl6" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lbl7" runat="server" Text="Mandatory field." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="lbl8" runat="server" Text="2. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="lbl9" runat="server" Text="Save " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="lbl10" runat="server" Text="button to add new record. " CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="lbl11" runat="server" Text="3. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="lbl12" runat="server" Text="Reset " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="lbl13" runat="server" Text="button to clear the data. " CssClass="small"></asp:Label>
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

        <script>
            $('.dtTaken').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtDoc').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });
        </script>
    </form>
</asp:Content>

