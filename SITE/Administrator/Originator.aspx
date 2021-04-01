<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="Originator.aspx.cs" Inherits="SITE_Administrator_Originator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">ADMINISTRATOR</h1>
                <h3 class="font-weight-bold text-muted">ORIGINATOR</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
                        <asp:TableRow>
                            <asp:TableCell ForeColor="Gray">
                                <p class=" text-right small">
                                    <asp:Label ID="Label1" runat="server" Text=" Notes: " CssClass="small fa fa-info-circle font-weight-bold"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text=" * " CssClass="small font-weight-bold" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="is mandatory fields" CssClass="small"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <asp:GridView ID="GridOriginator" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true"
                        OnPageIndexChanging="OnPaging" OnRowEditing="EditOriginator" OnRowUpdating="UpdateOriginator" OnRowCancelingEdit="CancelEdit"
                        ShowHeaderWhenEmpty="false" EmptyDataText="There are no data records to display."
                        PageSize="50" CssClass="table table-striped table-bordered table-hover table-responsive-lg">
                        <Columns>

                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="#" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtID" Width="40px" MaxLength="5" runat="server" CssClass="form-control input-sm" Visible="false"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-Width="400px" HeaderText="Originator Name" HeaderStyle-CssClass="text-sm-center" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="lblOriginator" runat="server"
                                        Text='<%# Eval("FLD_AUTHOR")%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOriginator" runat="server"
                                        Text='<%# Eval("FLD_AUTHOR")%>' Width="800" CssClass="form-control input-sm border-primary"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtOriginator" runat="server" CssClass="form-control input-sm border-primary" Width="800"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-Width="20px" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete" OnClick="DeleteOriginator"></asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddNewOriginator" CssClass="btn btn-sm text-muted" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ItemStyle-Width="80px" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Size="Smaller" ControlStyle-Font-Size="Smaller" />
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

