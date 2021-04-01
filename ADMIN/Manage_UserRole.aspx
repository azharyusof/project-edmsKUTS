<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_AdminMaster.master" AutoEventWireup="true" CodeFile="Manage_UserRole.aspx.cs" Inherits="ADMIN_Manage_UserRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">ADMINISTRATOR MODULE</h1>
                <h3 class="font-weight-bold text-muted">MANAGE USER ROLE</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Filter</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="35"></asp:TableCell>
                            <asp:TableCell Width="35"></asp:TableCell>
                            <asp:TableCell Width="30"></asp:TableCell>
                            <asp:TableCell Width="175"></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblFilter" runat="server" Text="Type" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldFilter" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldFilter_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <div id="dvProject" runat="server" visible="false">
                                    <p class="text-left">
                                        <asp:Label ID="Label1" runat="server" Text="Project Name" CssClass="font-weight-bold" />
                                    </p>
                                </div>
                                <div id="dvStaff" runat="server" visible="false">
                                    <p class="text-left">
                                        <asp:Label ID="Label2" runat="server" Text="Staff Name" CssClass="font-weight-bold" />
                                    </p>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div id="dvfldProject" runat="server" visible="false">
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldPName" runat="server" CssClass="form-control form-control-sm" Width="400" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="dvfldStaff" runat="server" visible="false">
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldSName" runat="server" CssClass="form-control form-control-sm" Width="400" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <div class="col-sm-12 text-center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-md center-block font-weight-bold" Width="100" OnClick="btnSearch_Click"></asp:Button>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btn-md center-block font-weight-bold" Width="100" OnClick="btnReset_Click"></asp:Button>
                    </div>

                    <hr />

                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowEditing="EditModel" OnRowUpdating="UpdateModel" OnRowCancelingEdit="CancelEdit" 
                        CssClass="table table-striped table-bordered table-hover table-responsive-lg" OnRowDataBound="GridView1_RowDataBound"
                        ShowHeaderWhenEmpty="false" EmptyDataText="There are no data records to display.">
                        <HeaderStyle ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="#" ItemStyle-Width="10" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Project Code" ItemStyle-Width="75" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblPCode" runat="server" Text='<%# Eval("PROJECT_CODE").ToString() != "" ? Eval("PROJECT_CODE") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Project Description" ItemStyle-Width="200" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblPDesc" runat="server" Text='<%# Eval("DESCRIPTION").ToString() != "" ? Eval("DESCRIPTION") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Staff No." ItemStyle-Width="50" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("STAFFNO").ToString() != "" ? Eval("STAFFNO") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Staff Name" ItemStyle-Width="200" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("STAFFNAME").ToString() != "" ? Eval("STAFFNAME") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email" ItemStyle-Width="150" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray" >
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMAIL").ToString() != "" ? Eval("EMAIL") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Role" ItemStyle-Width="30" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type").ToString() %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="dropType" CssClass="form-control form-control-sm input-sm" Width="60" runat="server" SelectedValue='<%# Bind("Type") %>'>
                                        <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                                        <asp:ListItem Value="DC" Text="DC"></asp:ListItem>
                                        <asp:ListItem Value="PT" Text="PT"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Initial" ItemStyle-Width="30" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblInitial" runat="server" Text='<%# Eval("Staff_Initial").ToString() != "" ? Eval("Staff_Initial").ToString() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>

                                    <asp:TextBox ID="fldInitial" runat="server" CssClass="form-control form-control-sm input-sm" Width="60" MaxLength="20" Text='<%# Bind("Staff_Initial")%>'></asp:TextBox>

                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sort" ItemStyle-Width="30" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblSorting" runat="server" Text='<%# Eval("Sorting").ToString() != "" ? Eval("Sorting").ToString() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>

                                    <asp:TextBox ID="fldSorting" runat="server" CssClass="form-control form-control-sm input-sm" Width="60" MaxLength="20" Text='<%# Bind("Sorting")%>'></asp:TextBox>

                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" ItemStyle-Width="10" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete" OnClick="DeleteModel"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" HeaderText="" ItemStyle-Width="10" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" HeaderStyle-BackColor="Gray" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

