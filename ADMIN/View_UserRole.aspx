<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_AdminMaster.master" AutoEventWireup="true" CodeFile="View_UserRole.aspx.cs" Inherits="ADMIN_View_UserRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">ADMINISTRATOR MODULE</h1>
                <h3 class="font-weight-bold text-muted">LIST USER ROLE</h3>
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

                    <asp:GridView ID="GridViewProject" runat="server" Width="100%" AutoGenerateColumns="false" DataKeyNames="PROJECT_CODE"
                        ShowHeaderWhenEmpty="false" EmptyDataText="There are no data records to display." OnRowDataBound="OnRowDataBound"
                        CssClass="table table-striped table-bordered table-hover table-responsive-lg">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="10px" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Image Style="cursor: pointer" src="img/plus.png" runat="server" ID="img_expand" />

                                    <asp:Panel ID="PanelAttach" AutoGenerateColumns="False" runat="server" Style="display: none">
                                        <asp:GridView ID="GridViewUser" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive-lg" AutoGenerateColumns="false" Width="95%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-Width="25" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#808080">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Staff No." ItemStyle-Width="30" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#808080">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("STAFFNO").ToString() != "" ? Eval("STAFFNO") : "-"%>' CssClass="input-sm"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Staff Name" ItemStyle-Width="250" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#808080">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("STAFFNAME").ToString() != "" ? Eval("STAFFNAME") : "-"%>' CssClass="input-sm"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="150" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#808080">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMAIL").ToString() != "" ? Eval("EMAIL") : "-"%>' CssClass="input-sm"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Role" ItemStyle-Width="80" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#808080">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRole" runat="server" Text='<%# Eval("TYPE").ToString() != "" ? Eval("TYPE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="#" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Project Code" ItemStyle-Width="40" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblPCode" runat="server" Text='<%# Eval("PROJECT_CODE").ToString() != "" ? Eval("PROJECT_CODE") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Project Description" ItemStyle-Width="280" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblPDesc" runat="server" Text='<%# Eval("DESCRIPTION").ToString() != "" ? Eval("DESCRIPTION") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Project Manager" ItemStyle-Width="120" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblPMgr" runat="server" Text='<%# Eval("PROJECT_MANAGER").ToString() != "" ? Eval("PROJECT_MANAGER") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $("[src*=plus]").live("click", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "img/minus.png");
            });
            $("[src*=minus]").live("click", function () {
                $(this).attr("src", "img/plus.png");
                $(this).closest("tr").next().remove();
            });
        </script>
    </form>
</asp:Content>

