<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_AdminMaster.master" AutoEventWireup="true" CodeFile="Add_UserRole.aspx.cs" Inherits="ADMIN_Add_UserRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">ADMINISTRATOR MODULE</h1>
                <h3 class="font-weight-bold text-muted">ADD USER ROLE</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-responsive-sm">
                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" VerticalAlign="Top" BackColor="LightGray">
                                <asp:Label ID="lblRole" runat="server" Text="Role" CssClass="font-weight-bold" />
                            </asp:TableCell>
                            <asp:TableCell BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Top">
                                <asp:Label ID="lblDesc" runat="server" Text="Role Description" CssClass="font-weight-bold" />
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblDC" runat="server" Text="Document Controller (DC)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblDCDesc" runat="server" Text="DC will be able to process incoming and outgoing document." CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPM" runat="server" Text="Project Manager (PM)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPMDesc" runat="server" Text="PM will be able to assign task to the project team member." CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPT" runat="server" Text="Project Team (PT)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPTDesc" runat="server" Text="PT will be able to receive email notification (optional) and response to the task given by the PM." CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblCOO" runat="server" Text="Chief Operating Officer (COO)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblCOODesc" runat="server" Text="-" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPC" runat="server" Text="Project Coordinator (PC)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPCDesc" runat="server" Text="-" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPNC" runat="server" Text="Procurement & Contract (PNC)" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPNCDesc" runat="server" Text="-" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <hr />

                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">User Role Details</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="Table1" runat="server" Width="100%" CssClass="table-responsive-lg">
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
                                    <asp:Label ID="lblProjectName" runat="server" Text="Project Name" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldPName" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label1" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblStaffName" runat="server" Text="Staff Name" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldStaffNo" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label2" runat="server" Text="* " CssClass="small" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblUserRole" runat="server" Text="Role" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldRole" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <br />

                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnSave_Click" ></asp:Button>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnReset_Click" ></asp:Button>
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
                                    <asp:Label ID="Label3" runat="server" Text="2. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Save " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="button to add new record" CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-left small">
                                    <asp:Label ID="Label6" runat="server" Text="3. Click on the " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text="Reset " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Text="button to clear the data." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

