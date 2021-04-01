<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="In_View_Status.aspx.cs" Inherits="SITE_Incoming_In_View_Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">INCOMING</h1>
                <h3 class="font-weight-bold text-muted">STATUS</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" ForeColor="Gray">
                                <p class=" text-right small">
                                    <asp:Label ID="Label1" runat="server" Text=" Notes: " CssClass="small fa fa-info-circle"></asp:Label>
                                    <asp:Label ID="Label9" runat="server" Text="Tick on button in " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" Text="Status " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text=" and then, click on " CssClass="small"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" Text="Submit " CssClass="small font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label14" runat="server" Text="button." CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-responsive-sm">
                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top" BackColor="LightGray"></asp:TableCell>
                            <asp:TableCell CssClass="text-center" VerticalAlign="Top" BackColor="LightGray">
                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="font-weight-bold" />
                            </asp:TableCell>
                            <asp:TableCell BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Top">
                                <asp:Label ID="lblTotal" runat="server" Text="Total" CssClass="font-weight-bold" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center">
                                <asp:RadioButton ID="RB1" GroupName="Opt" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblTaskPending" runat="server" Text="Assigned Task - Pending" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblPending" runat="server" Text="0" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center">
                                <asp:RadioButton ID="RB2" GroupName="Opt" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblTaskComplete" runat="server" Text="Assigned Task - Completed" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblCompleted" runat="server" Text="0" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="text-center">
                                <asp:RadioButton ID="RB3" GroupName="Opt" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell CssClass="text-center" ForeColor="Black">
                                <asp:Label ID="lblTaskInfo" runat="server" Text="Info Only" />
                            </asp:TableCell>
                            <asp:TableCell Wrap="false" HorizontalAlign="Center" ForeColor="Black">
                                <asp:Label ID="lblInfo" runat="server" Text="0" CssClass="text-sm-center"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <div class="col-sm-12 text-center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-md border-dark center-block font-weight-bold" Width="100" OnClick="btnSubmit_Click"></asp:Button>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btn-md border-dark center-block font-weight-bold" Width="100" OnClick="btnReset_Click"></asp:Button>
                    </div>

                    <hr />

                    <asp:GridView ID="GridViewInStatus" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive-lg" DataKeyNames="ID" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true" EmptyDataText="There are no data records to display." OnRowDataBound="GridViewInStatus_RowDataBound" Visible="false" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://192.168.50.41/document/" + Eval("PROJECT_CODE") + "/incoming/" + Eval("FLD_IN_DATE", "{0:yyyy}") + "/" + Eval("TRACK_NO") + ".pdf" %>' Target="_blank">
                                        <asp:Image Style="cursor: pointer" src="../Img/icon_pdf_small.gif" runat="server" ID="img_all" />
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tracking No." ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <a href='In_Action_Document.aspx?ID1=<%# Eval("ID")%>&ID2=<%# Eval("FLD_IN_ACTIONEE")%>' target="_blank">
                                        <asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm"></asp:Label></a>
                                    <asp:Label ID="FLD_IN_SERIAL" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Label ID="FLD_ACTION_DATE" runat="server" Text='<%# Eval("FLD_ACTION_DATE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Label ID="FLD_OUT_REFERENCE" runat="server" Text='<%# Eval("FLD_OUT_REFERENCE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Label ID="FLD_ACTION_TAKEN" runat="server" Text='<%# Eval("FLD_ACTION_TAKEN")%>' CssClass="input-sm" Visible="false"></asp:Label>

                                    <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Label ID="TRACK_NO" runat="server" Text='<%# Eval("TRACK_NO")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Received" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblRcvdDt" runat="server" Text='<%# Eval("FLD_IN_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reference No." ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefNo" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString() != "" ? Eval("FLD_REFERENCE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date of Document" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtDoc" runat="server" Text='<%# Eval("FLD_CORR_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Subject" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("FLD_TITLE1").ToString() != "" ? Eval("FLD_TITLE1").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Author" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("FLD_AUTHOR").ToString() != "" ? Eval("FLD_AUTHOR").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Company" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("FLD_COMPANY").ToString() != "" ? Eval("FLD_COMPANY").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Urgency" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblUrgency" runat="server" Text='<%# Eval("FLD_URGENCY")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Required" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtReq" runat="server" Text='<%# Eval("FLD_REQ_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action Required" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblReq" runat="server" Text='<%# Eval("REQUIRED_ACTION").ToString() != "" ? Eval("REQUIRED_ACTION").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action Taken Date" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtTaken" runat="server" Text='<%# Eval("ACTION_TAKEN_DT", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaken" runat="server" Text='<%# Eval("ACTION_TAKEN").ToString() != "" ? Eval("ACTION_TAKEN").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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

