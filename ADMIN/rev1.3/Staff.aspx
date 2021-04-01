<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Staff.aspx.cs" Inherits="ADMIN_Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Staff</div>
        <div class="panel-body">

<asp:Label ID="lblNote" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">* Mandatory field</asp:Label>

<asp:Label ID="lblMsg" runat="server" Text='All fields are required !' CssClass="input-sm" ForeColor="Red" Visible="false"></asp:Label>                 

<asp:GridView ID="GridView1" runat="server"  Width = "40%"
AutoGenerateColumns = "false" Font-Names = "Arial"
Font-Size = "10pt" AllowPaging ="true"  ShowFooter = "true" 
OnPageIndexChanging = "OnPaging" onrowediting="EditCompany"
onrowupdating="UpdateCompany"  onrowcancelingedit="CancelEdit"
PageSize = "75" CssClass="table table-bordered table-striped input-sm">
<Columns>
                
<asp:TemplateField HeaderText = "#" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
   <ItemTemplate>
        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
        <asp:Label ID="lblID" runat="server" Text='<%# Eval("staffid")%>' CssClass="input-sm" Visible="false"></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        
    </FooterTemplate>
</asp:TemplateField>
    
<asp:TemplateField HeaderText = "* Staff No." ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("StaffNo")%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
       <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("StaffNo")%>' CssClass="input-sm"></asp:Label>
        
    </EditItemTemplate> 
    <FooterTemplate>
                
        <asp:TextBox ID="txtStaffNo" runat="server" CssClass="form-control input-sm" Width="80" BackColor="#ffffcc"></asp:TextBox>  
                                              
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText = "* Staff Name" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
    <ItemTemplate>
        <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName")%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtStaffName" runat="server" Text='<%# Eval("StaffName")%>' CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:TextBox>  
        
    </EditItemTemplate> 
    <FooterTemplate>
                
        <asp:TextBox ID="txtStaffName" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:TextBox>  
                                              
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText = "* Email" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
    <ItemTemplate>
        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email")%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email")%>' CssClass="form-control input-sm" Width="250" BackColor="#ffffcc"></asp:TextBox>  
        
    </EditItemTemplate> 
    <FooterTemplate>
                
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" Width="250" BackColor="#ffffcc"></asp:TextBox>  
                                              
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText = "" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="false" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
   <ItemTemplate>
        <asp:LinkButton ID="lnkReset" runat="server" CommandArgument = '<%# Eval("staffno")%>' OnClientClick = "return confirm('Are you sure you want to reset password for this staff?')" Text = "Reset Pwd" OnClick = "lnkReset_Click"></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        
    </FooterTemplate>
</asp:TemplateField>
    
<asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument = '<%# Eval("staffno")%>' OnClientClick = "return confirm('Are you sure you want to remove this record?')" Text = "Remove" OnClick = "DeleteUser"></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "AddNewUser" CssClass="btn btn-default btn-sm"/>
    </FooterTemplate>
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" ItemStyle-Width = "20px" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center"/>

</Columns>
<AlternatingRowStyle BackColor="#CCCCCC"  />
</asp:GridView>

</div>
</div>

</asp:Content>


