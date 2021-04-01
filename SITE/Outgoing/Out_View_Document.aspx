<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="Out_View_Document.aspx.cs" Inherits="SITE_Outgoing_Out_View_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <%  
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDocTabYr", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pProjectCode", Request.QueryString["ID1"]);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter(cmd);
                System.Data.DataTable dt1 = new System.Data.DataTable();
                da1.Fill(dt1);
            %>

            <hgroup>
                <h1 class="font-weight-bold text-muted">OUTGOING</h1>
                <h3 class="font-weight-bold text-muted">DOCUMENT LIST</h3>
            </hgroup>
        </div>

        <asp:HiddenField ID="hid_Year" runat="server" />

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <nav>
                        <ul class="nav nav-tabs" role="tablist">
                            <% 
                                if (dt1.Rows.Count == 0)
                                {
                            %>
                            <li class="nav-item nav-link active">
                                <a href="?ID=<%= Request.QueryString["ID"]%>&ID1=<%= Request.QueryString["ID1"]%>&Year=<%= DateTime.Now.ToString("yyyy")%>"><%= DateTime.Now.ToString("yyyy")%></a>
                            </li>
                            <% 
                                }
                                else
                                {
                                    for (int index = 0; index < dt1.Rows.Count; index++)
                                    {
                                        System.Data.DataRow row = dt1.Rows[index];
                            %>
                            <li <% if (Convert.ToInt32(hid_Year.Value) == Convert.ToInt32(row["year"].ToString())) Response.Write("class='nav-item nav-link active'");%>>
                                <a href="?ID=<%= Request.QueryString["ID"]%>&ID1=<%= Request.QueryString["ID1"]%>&Year=<%= row["year"].ToString()%>">
                                    <p class="text-muted font-weight-bold">
                                        <%= row["year"].ToString()%>
                                    </p>
                                </a>
                            </li>
                            <% 
                                    }
                                }
                            %>
                        </ul>
                    </nav>

                    <asp:Label ID="lblProjectCode" runat="server" Visible="false" />

                    <br />

                    <div class="table-responsive-lg">
                        <asp:Table ID="tblHeader" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Width="50" Height="10"></asp:TableCell>
                                <asp:TableCell Width="100" Height="10"></asp:TableCell>
                                <asp:TableCell Width="25"></asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                    <p class="text-left">
                                        <asp:Label ID="Label6" runat="server" Text="Addressee" CssClass="font-weight-bold"></asp:Label>
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldAddressee" runat="server" CssClass="form-control form-control-sm" Width="400px"
                                            OnSelectedIndexChanged="fldAddressee_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <br />

                        <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
                            <asp:TableRow>
                                <asp:TableCell ForeColor="Gray">
                                    <p class=" text-right small">
                                        <asp:Label ID="Label1" runat="server" Text=" Notes: " CssClass="small fa fa-info-circle font-weight-bold"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text="Click on" CssClass="small"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Tracking No. " CssClass="small font-weight-bold"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text="to view details or click " CssClass="small"></asp:Label>
                                        <img src="../Img/icon_pdf_small.gif" />
                                        <asp:Label ID="Label5" runat="server" Text=" for scanned document." CssClass="small"></asp:Label>
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:GridView ID="GridViewOutDoc" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                            AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="There are no data records to display." PageSize="15"
                            AllowPaging="true" OnPageIndexChanging="GridViewOutDoc_OnPageIndexChanging" OnRowDataBound="GridViewOutDoc_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" >
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Eval("PROJECT_CODE") + "/" + Eval("COMPANY_CODE") + "/outgoing/" + Eval("FLD_DOC_DATE", "{0:yyyy}") + "/" + Eval("FLD_OUT_SERIAL") + ".pdf" %>' Target="_blank">
                                            <asp:Image Style="cursor: pointer" src="../Img/icon_pdf_small.gif" runat="server" ID="img_all" />
                                        </asp:HyperLink>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tracking No." HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Blue">
                                    <ItemTemplate>
                                        <a href='Out_Edit_Document.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%= Request.QueryString["ID1"] %>&ID2=<%# Eval("ID")%>&url=OVD'>
                                            <asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_OUT_SERIAL")%>' CssClass="input-sm"></asp:Label></a>
                                        <asp:Label ID="FLD_OUT_SERIAL" runat="server" Text='<%# Eval("FLD_OUT_SERIAL")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="COMPANY_CODE" runat="server" Text='<%# Eval("COMPANY_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="TRACK_NO" runat="server" Text='<%# Eval("TRACK_NO")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reference No." HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReference" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString() != "" ? Eval("FLD_REFERENCE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date of Document" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDtDoc" runat="server" Text='<%# (Eval("FLD_DOC_DATE").ToString()  != "") ? Convert.ToDateTime(Eval("FLD_DOC_DATE")).ToString("dd/MM/yy") : "-" %>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Package" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%# Eval("FLD_PACKAGE").ToString()  != "" ? Eval("FLD_PACKAGE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("FLD_TITLE").ToString()  != "" ? Eval("FLD_TITLE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                        <asp:Label ID="lblCancelled" runat="server" Text='<%# Eval("CANCELLED").ToString()  != "" ? Eval("CANCELLED").ToString().ToUpper() : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Originator" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOriginator" runat="server" Text='<%# Eval("FLD_ORIGINATOR").ToString()  != "" ? Eval("FLD_ORIGINATOR").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sent To" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSentTo" runat="server" Text='<%# Eval("FLD_SENT_TO").ToString() != "" ? Eval("FLD_SENT_TO").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
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

