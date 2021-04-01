<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" Inherits="ADMIN_Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Administrator</div>
        <div class="panel-body">

<asp:Label ID="lblNote" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">* Mandatory field</asp:Label>

<asp:Label ID="lblMsg" runat="server" Text='Staff Name is required !' CssClass="input-sm" ForeColor="Red" Visible="false"></asp:Label>                 

<asp:GridView ID="GridView1" runat="server"  Width = "50%"
AutoGenerateColumns = "false" Font-Names = "Arial"
Font-Size = "10pt" AllowPaging ="true"  ShowFooter = "true" 
OnPageIndexChanging = "OnPaging" 
PageSize = "25" CssClass="table table-bordered table-striped input-sm">
<Columns>
                
<asp:TemplateField HeaderText = "#" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
   <ItemTemplate>
        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
        <asp:Label ID="lblID" runat="server" Text='<%# Eval("staffno")%>' CssClass="input-sm" Visible="false"></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        
    </FooterTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText = "Staff No." ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("StaffNo")%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
                                             
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText = "* Staff Name" ItemStyle-Width="60%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
    <ItemTemplate>
        <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName")%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    
    <FooterTemplate>
                
        <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#ffffcc" CssClass="form-control input-sm" AppendDataBoundItems="true" DataSourceID="SqlDataSource2" DataTextField="StaffName" DataValueField="StaffNo" Width="350">
            <asp:ListItem Text="" Value="" ></asp:ListItem>
        </asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GEDMSConn%>" SelectCommand="SELECT * FROM tblstaff ORDER BY StaffName"></asp:SqlDataSource>
                                              
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField ItemStyle-CssClass="table" ItemStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument = '<%# Eval("staffno")%>' OnClientClick = "return confirm('Are you sure you want to remove this record?')" Text = "Remove" OnClick = "DeleteRole"></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "AddNewRole" CssClass="btn btn-default btn-sm"/>
    </FooterTemplate>
</asp:TemplateField>

</Columns>
<AlternatingRowStyle BackColor="#CCCCCC"  />
</asp:GridView>

</div>
</div>

</asp:Content>

