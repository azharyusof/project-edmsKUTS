<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="View_Project.aspx.cs" Inherits="ADMIN_View_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Project Listing</div>
        <div class="panel-body">
            

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><b>Note : Click on <u>Project Code</u> to view details. Click &nbsp;<asp:Image src="Img/setup.jpg" runat="server" AlternateText="Click here"/>&nbsp; to configure setting for each project.</b></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="8"></asp:TableCell>
            </asp:TableRow>
                    
            </asp:Table>
             
            <asp:GridView ID="GridViewProject" runat="server" CssClass="table table-bordered table-striped input-sm" AutoGenerateColumns="False" DataKeyNames="ProjectId" ShowHeaderWhenEmpty="true" >
            <HeaderStyle ForeColor="White"/>
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" ItemStyle-Width="40" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080">
                    <ItemTemplate>                       
                        <a href='Setup_Project.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%# Eval("PROJECTID")%>'><asp:Image src="Img/setup.jpg" runat="server" AlternateText="Click here"/></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Code" ItemStyle-Width="40" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080">
                    <ItemTemplate>                       
                        <a href='Edit_Project.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%# Eval("PROJECTID")%>'><asp:Label ID="lblPCode" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm"></asp:Label></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Description" ItemStyle-Width="280" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080">
                    <ItemTemplate>
                        <asp:Label ID="lblPDesc" runat="server" Text='<%# Eval("DESCRIPTION")%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Project Manager" ItemStyle-Width="120" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080">
                    <ItemTemplate>
                        <asp:Label ID="lblPMgr" runat="server" Text='<%# Eval("PROJECT_MANAGER")%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>              
                
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
            <br />

            <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblMessage1" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblMessage2" runat="server" Text="Label" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>


