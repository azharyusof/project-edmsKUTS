<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Manage_UserRole.aspx.cs" Inherits="ADMIN_Manage_UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
    <div class="panel-heading">Manage User Role</div>
    <div class="panel-body">

    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">           
            <asp:TableRow>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="8"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Project Name</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                    <div class="form-inline">
                        <asp:DropDownList ID="fldPName" CssClass="form-control input-sm" Width="300" runat="server" AppendDataBoundItems="true" BackColor="#ffffcc">
                        </asp:DropDownList>
                    </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Staff Name</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                    <div class="form-inline">
                        <asp:DropDownList ID="fldSName" CssClass="form-control input-sm" Width="350" runat="server" AppendDataBoundItems="true" BackColor="#ffffcc">
                        </asp:DropDownList>
                    </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
                    
            </asp:Table>
            
            <asp:Table ID="tblOutNote" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="100" Height="10"></asp:TableCell>
                <asp:TableCell Width="20"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <b>Note : </b>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="2"></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    1. Click on the <b>Submit</b> button to search for record.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Reset</b> button to clear the data.
                </asp:TableCell>
            </asp:TableRow>
                 
            </asp:Table>

            <hr />

            <asp:Button ID="btnSearch" runat="server" Text="Submit" CssClass="btn btn-default btn-sm" Width="61" OnClick="btnSearch_Click"/>
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" /> 
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="err" runat="server" Text='Project Name or Staff Name is required !' CssClass="input-sm" ForeColor="Red"></asp:Label>
                        <asp:Label ID="err1" runat="server" Text='Please select either Project Name or Staff Name!' CssClass="input-sm" ForeColor="Red"></asp:Label>

            <br /><br />

<asp:GridView ID="GridView1" runat="server"  Width = "100%" AutoGenerateColumns = "false" onrowediting="EditModel" onrowupdating="UpdateModel"  onrowcancelingedit="CancelEdit" CssClass="table table-bordered table-striped input-sm" OnRowDataBound="GridView1_RowDataBound">
<HeaderStyle ForeColor="White"/>
    <Columns>
                
<asp:TemplateField HeaderText="#" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" ItemStyle-HorizontalAlign="Center">
   <ItemTemplate>
        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Project Code" ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPCode" runat="server" Text='<%# Eval("PROJECT_CODE").ToString() != "" ? Eval("PROJECT_CODE") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
</asp:TemplateField>      
        
<asp:TemplateField HeaderText="Project Description" ItemStyle-Width="200" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPDesc" runat="server" Text='<%# Eval("DESCRIPTION").ToString() != "" ? Eval("DESCRIPTION") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
</asp:TemplateField>                 

<asp:TemplateField HeaderText="Staff No." ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("STAFFNO").ToString() != "" ? Eval("STAFFNO") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Staff Name" ItemStyle-Width="200" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("STAFFNAME").ToString() != "" ? Eval("STAFFNAME") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Email" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMAIL").ToString() != "" ? Eval("EMAIL") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Role" ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>                                                    
        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type").ToString() %>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        
        <asp:DropDownList ID="dropType" CssClass="form-control input-sm" Width="80" BackColor="#ffffcc" runat="server" SelectedValue='<%# Bind("Type") %>'>
                    <asp:ListItem Value="PM" Text="PM" ></asp:ListItem>
                    <asp:ListItem Value="DC" Text="DC" ></asp:ListItem>
                    <asp:ListItem Value="PT" Text="PT" ></asp:ListItem>
                </asp:DropDownList>

    </EditItemTemplate> 
</asp:TemplateField>

        <asp:TemplateField HeaderText="Initial" ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>                                                    
        <asp:Label ID="lblInitial" runat="server" Text='<%# Eval("Staff_Initial").ToString() != "" ? Eval("Staff_Initial").ToString() : "-"%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        
        <asp:TextBox ID="fldInitial" runat="server" CssClass="form-control input-sm" Width="100" BackColor="#ffffcc" MaxLength="20" Text='<%# Bind("Staff_Initial")%>'></asp:TextBox> 
        
    </EditItemTemplate> 
</asp:TemplateField>

<asp:TemplateField HeaderText="Sorting" ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>                                                    
        <asp:Label ID="lblSorting" runat="server" Text='<%# Eval("Sorting").ToString() != "" ? Eval("Sorting").ToString() : "-"%>' CssClass="input-sm"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        
        <asp:TextBox ID="fldSorting" runat="server" CssClass="form-control input-sm" Width="100" BackColor="#ffffcc" MaxLength="20" Text='<%# Bind("Sorting")%>'></asp:TextBox> 
        
    </EditItemTemplate> 
</asp:TemplateField>

<asp:TemplateField HeaderText="" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument = '<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to delete this record?')" Text = "Delete" OnClick = "DeleteModel"></asp:LinkButton>
    </ItemTemplate>    
</asp:TemplateField>

<asp:CommandField ShowEditButton="True" HeaderText="" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" ItemStyle-HorizontalAlign="Center"/>

</Columns>
<AlternatingRowStyle BackColor="#CCCCCC"  />
</asp:GridView>

</div>
</div>

</asp:Content>

