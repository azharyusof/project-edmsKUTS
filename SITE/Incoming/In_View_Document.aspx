<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="In_View_Document.aspx.cs" Inherits="SITE_Incoming_In_View_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <%  
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spProjectTabYr", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pProjectCode", lblProjectCode.Text.Trim());

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter(cmd);
                System.Data.DataTable dt1 = new System.Data.DataTable();
                da1.Fill(dt1);
            %>

            <hgroup>
                <h1 class="font-weight-bold text-muted">INCOMING</h1>
                <h3 class="font-weight-bold text-muted">PROJECT LIST</h3>
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
                                <asp:TableCell Width="100" Height="10"></asp:TableCell>
                                <asp:TableCell Width="25"></asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="Top">
                                    <p class="text-left">
                                        <asp:Label ID="Label2" runat="server" Text="Originator" CssClass="font-weight-bold"></asp:Label>
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldOriginator" runat="server" CssClass="form-control form-control-sm" Width="400px"
                                            OnSelectedIndexChanged="fldOriginator_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <br />

                        <p class="text-left font-weight-bold">
                            <small class="text-muted">** Note : Click on <b>Tracking No.</b> to view details or click
                                <img src="../Img/icon_pdf_small.gif" />
                                for scanned document.
                            </small>
                        </p>

                        <asp:GridView ID="GridViewInDoc" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                            AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="There are no data records to display." PageSize="15"
                            AllowPaging="true" OnPageIndexChanging="GridViewInDoc_OnPageIndexChanging" OnRowDataBound="GridViewInDoc_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                        <asp:Label ID="lblScanDoc" runat="server" Text='' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Eval("PROJECT_CODE") + "/" + Eval("COMPANY_CODE") + "/incoming/" + Eval("FLD_IN_DATE", "{0:yyyy}") + "/" + Eval("FLD_IN_SERIAL") + ".pdf" %>' Target="_blank">
                                            <asp:Image Style="cursor: pointer" src="../Img/icon_pdf_small.gif" runat="server" ID="img_all" Visible="false" />
                                        </asp:HyperLink>
                                        <asp:HyperLink ID="HyperLinkPNC" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Eval("PROJECT_CODE") + "/" + Eval("COMPANY_CODE") + "/incoming/" + Eval("FLD_IN_DATE", "{0:yyyy}") + "/" + Eval("ID") + "/" + Eval("FLD_IN_SERIAL") + ".pdf" %>' Target="_blank">
                                            <asp:Image Style="cursor: pointer" src="../Img/security.jpg" runat="server" ID="imgSecure" Visible="false" />
                                        </asp:HyperLink>

                                        <br />
                                        <br />
                                        <asp:Image src="../Img/actionee.png" runat="server" ID="img_actionee" Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tracking No." HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Blue">
                                    <ItemTemplate>
                                        <a href='In_Edit_Document.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%= Request.QueryString["ID1"] %>&ID2=<%# Eval("ID")%>&url=IVD'>
                                            <asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm"></asp:Label></a>

                                        <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="COMPANY_CODE" runat="server" Text='<%# Eval("COMPANY_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="FLD_IN_SERIAL" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                        <asp:Label ID="ID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Received" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRcvdDt" runat="server" Text='<%# Eval("FLD_IN_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reference No." HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefNo" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString() != "" ? Eval("FLD_REFERENCE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date of Document" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDtDoc" runat="server" Text='<%# Eval("FLD_CORR_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Package" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%# Eval("FLD_PACKAGE").ToString() != "" ? Eval("FLD_PACKAGE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("FLD_TITLE").ToString() != "" ? Eval("FLD_TITLE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                        <asp:Label ID="lblConfidential" runat="server" Text='<%# Eval("FLD_CONFIDENTIAL").ToString() != "" ? Eval("FLD_CONFIDENTIAL").ToString().ToUpper() : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Author" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("FLD_AUTHOR").ToString() != "" ? Eval("FLD_AUTHOR").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Attachment" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                    <ItemTemplate>

                                        <asp:GridView ID="GridViewAttach" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>)        
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Request.QueryString["ID1"] + "/" + Eval("COMPANY_CODE") + "/incoming/attachment/" + Eval("ID") + "/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString().ToUpper()%></asp:HyperLink>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("FILENAME").ToString() == "" ? Eval("FLD_ATCH_TITLE").ToString().ToUpper() : ""%>' CssClass="input-sm" Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                        <asp:Label ID="lblAttach" runat="server" CssClass="input-sm" Visible="false"></asp:Label>
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
