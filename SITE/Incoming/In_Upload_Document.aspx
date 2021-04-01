<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="In_Upload_Document.aspx.cs" Inherits="SITE_Incoming_In_Upload_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <h1 class="font-weight-bold text-muted">INCOMING</h1>
            <h3 class="font-weight-bold text-muted">UPLOAD DOCUMENT</h3>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="175"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell Width="175"></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left form-group row">
                                    <asp:Label ID="lblFileUpload" runat="server" Text="File Name" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <div class="form-group row">
                                    <div class=" custom-file">
                                        <asp:FileUpload ID="file_upload" class="multi form-control form-control-sm custom-file-input" runat="server" />
                                        <label class="custom-file-label" for="file_upload">Choose file</label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div id="DvFileUpload" runat="server" class="alert alert-light form-control form-control-sm" visible="false">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-12 text-center">
                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-primary btn-md border-dark center-block font-weight-bold" Width="100" OnClick="btnUpload_Click"></asp:Button>
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

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
                                    <asp:Label ID="lbl5" runat="server" Text="1. Rename your " CssClass="small"></asp:Label>
                                    <img src="../Img/icon_pdf_small.gif" />
                                    <asp:Label ID="Label2" runat="server" Text="according to Tracking No. " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="(Eg: 00240-14.pdf)" CssClass="small font-weight-bold"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="Label3" runat="server" Text="2. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Browse " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="button and select your file (maximum file size is 3MB) " CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="Label6" runat="server" Text="3. When the file has been selected, click on " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text="Open " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Text="button or double click on the file." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="Label9" runat="server" Text="4. Click again on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" Text="Browse " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text="to add more files or " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" Text="Upload " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label14" runat="server" Text="to upload file(s)" CssClass="small"></asp:Label>
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
    </form>
</asp:Content>

