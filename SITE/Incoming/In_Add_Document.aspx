<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="In_Add_Document.aspx.cs" Inherits="SITE_Incoming_In_Add_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">INCOMING</h1>
                <h3 class="font-weight-bold text-muted">ADD PROJECT</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Incoming Details</a>
                        </li>
                    </ul>

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="175" Height="10"></asp:TableCell>
                            <asp:TableCell Width="25"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl1" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblDateReceived" runat="server" Text="Date Received" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateReceived" runat="server" width="250" class="dtReceive form-control form-control-sm" readonly="readonly" />
                                </div>
                                <div id="errDvfldDateReceived" runat="server" class="form-group row alert alert-danger form-control form-control-sm text-left" style="width: 250px" visible="false">
                                    <asp:Label ID="lblFldDateReceived" CssClass="fa fa-times-circle" runat="server" Text=" Date Received is required!"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl2" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblOriginator" runat="server" Text="Originator" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <div class="input-group-prepend">
                                        <asp:Label ID="lblOriginatorCode" runat="server" CssClass="form-control-sm font-weight-bold" Width="100" BackColor="LightGray"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="fldOriginator" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldOriginator_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div id="errDvfldOriginator" runat="server" class="form-group row alert alert-danger form-control form-control-sm text-left" style="width: 500px" visible="false">
                                    <asp:Label CssClass="fa fa-times-circle" ID="lblfldOriginator" runat="server" Text=" Originator is required!"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblRefNo" runat="server" Text="In Reference No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRefNo" runat="server" CssClass="form-control form-control-sm" Width="350"></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <div class="input-group-prepend">
                                        <asp:Button ID="btnCheckRefNo" runat="server" Text="Check Duplicate" CssClass="btn btn-primary btn-sm font-weight-bold form-control" Width="150" OnClick="btnCheckRefNo_Click" />
                                    </div>
                                </div>
                                <div id="dvDuplicate" runat="server" class="form-group row alert alert-danger form-control form-control-sm text-left" style="width: 500px" visible="false">
                                    <span class="fa fa-times-circle"></span>
                                    <asp:Label ID="lblRefDuplicate" runat="server" Text=" Reference No. already exist!"></asp:Label>
                                </div>

                                <div id="dvAvailable" runat="server" class="form-group row alert alert-success form-control form-control-sm text-left" style="width: 500px" visible="false">
                                    <span class="fa fa-check-circle"></span>
                                    <asp:Label ID="lblRefAvailable" runat="server" Text=" You can register this In Reference No.!"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl3" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblDateDoc" runat="server" Text="Date of Document" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateDocument" runat="server" width="250" class="dtDocument form-control form-control-sm" readonly="readonly" />
                                </div>
                                <div id="errDvfldDateDoc" runat="server" class="form-group row alert alert-danger form-control form-control-sm text-left" style="width: 250px" visible="false">
                                    <asp:Label CssClass="fa fa-times-circle" ID="lblfldDateDocument" runat="server" Text=" Date Document is required!"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
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
                                    <asp:TextBox ID="fldNewPackage" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblTypeDoc" runat="server" Text="Type of Document" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldType" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewType" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lbl4" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldSubject" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                                <div id="errDvfldSubject" runat="server" class="form-group row alert alert-danger form-control form-control-sm text-left" style="width: 250px" visible="false">
                                    <asp:Label CssClass="fa fa-times-circle" ID="lblfldSubject" runat="server" Text=" Subject is required!"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblAuthor" runat="server" Text="Author" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldAuthor" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldAuthor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewAuthor" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblUrgency" runat="server" Text="Urgency" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <p class="text-left">
                                    <asp:Label ID="lblNote" runat="server" Text="Note: High - 3 days, Medium - 7 days, Low - 14 days" CssClass="font-weight-bold" />
                                </p>
                                <div class="form-group row">
                                    <asp:Button ID="btnHigh" runat="server" Text="High" CssClass="btn btn-danger btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnHigh_Click" />
                                    <asp:Button ID="btnMedium" runat="server" Text="Medium" CssClass="btn btn-primary btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnMedium_Click" />
                                    <asp:Button ID="btnLow" runat="server" Text="Low" CssClass="btn btn-success btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnLow_Click" />
                                    <asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-light btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnInfo_Click" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDateRequired" runat="server" Text="Date Required" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateRequired" runat="server" width="200" class="dtRequired form-control form-control-sm" readonly="readonly" />
                                    <asp:HiddenField ID="fldUrgency" runat="server" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblSubjectFile" runat="server" Text="Subject File" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldSubjectFile" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldSubjectFile_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewSubjectFile" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblConfidentiality" runat="server" Text="Type of Confidentiality" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldConfidential" runat="server" CssClass="form-control form-control-sm dropdown-toggle" Width="400"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDCRemarks" runat="server" Text="DC Remarks" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRemarks" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnSave_Click"></asp:Button>
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
            $('.dtReceive').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtDocument').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtRequired').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });
        </script>
    </form>
</asp:Content>

