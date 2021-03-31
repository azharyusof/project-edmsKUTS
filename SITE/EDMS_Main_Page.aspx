<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EDMS_Main_Page.aspx.cs" Inherits="EDMS_Main_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-danger">
        <div class="panel-heading">Electronic Document Management System</div>
        <div class="panel-body">
            
            <table border="0" class="table table-bordered">
                <tr>
                    <td colspan="3" align="left">
                        <asp:Label ID="lblDepartment" runat="server" CssClass="input-sm"></asp:Label>
                        <br />
                        <asp:Label ID="lblHodPm" runat="server" CssClass="input-sm"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="GridViewResultIncoming" runat="server" CssClass="table table-bordered table-striped input-sm" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoIn" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%# Eval("InYr").ToString()  != "" ? Eval("InYr") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Incoming Document" ItemStyle-Width="200" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblIncoming" runat="server" Text='<%# Eval("totalInDoc").ToString()  != "" ? Eval("totalInDoc") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:GridView ID="GridViewResultOutgoing" runat="server" CssClass="table table-bordered table-striped input-sm" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOut" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblYearIn" runat="server" Text='<%# Eval("OutYr").ToString()  != "" ? Eval("OutYr") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Outgoing Document" ItemStyle-Width="200" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblOutgoing" runat="server" Text='<%# Eval("totalOutDoc").ToString()  != "" ? Eval("totalOutDoc") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnChangeProject" runat="server" Text="Change Project" CssClass="btn btn-default btn-sm" Width="150" Enabled="false" />

        </div>
    </div>
</asp:Content>

