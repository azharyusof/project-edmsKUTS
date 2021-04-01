<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="View_UserRole.aspx.cs" Inherits="ADMIN_View_UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">User Role Listing</div>
        <div class="panel-body">            
            
            <asp:Table ID="Table1" runat="server" Width="70%" CssClass="table table-bordered table-striped input-sm" >
                            <asp:TableRow>
                                <asp:TableCell BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Role</b></asp:TableCell>
                                <asp:TableCell Wrap="false" BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Description</b></asp:TableCell>
                            </asp:TableRow>  
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center" Wrap="false">Document Controller (DC)</asp:TableCell>
                                <asp:TableCell Wrap="false" HorizontalAlign="Center" >DC will be able to process incoming and outgoing document.</asp:TableCell>
                            </asp:TableRow>  
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center" Wrap="false">Project Manager (PM)</asp:TableCell>
                                <asp:TableCell Wrap="false" HorizontalAlign="Center" >PM will be able to assign task to the project team member.</asp:TableCell>
                            </asp:TableRow>  
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center" Wrap="false">Project Team (PT)</asp:TableCell>
                                <asp:TableCell Wrap="false" HorizontalAlign="Center" >PT will be able to receive email notification (optional) and response to the task given by the PM.</asp:TableCell>
                            </asp:TableRow>  
            </asp:Table>

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="8"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><b>Note : Click &nbsp;<img src="img/plus.png"/>&nbsp; or &nbsp;<img src="img/minus.png"/>&nbsp; to expand/collapse the user listing.</b></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="8"></asp:TableCell>
            </asp:TableRow>
                    
            </asp:Table>

            <asp:GridView ID="GridViewProject" runat="server" CssClass="table table-bordered table-striped input-sm" AutoGenerateColumns="False" Width="500%" DataKeyNames="PROJECT_CODE" ShowHeaderWhenEmpty="true" OnRowDataBound="OnRowDataBound" >
            <Columns>

                <asp:TemplateField HeaderText="#" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#f23d00" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#f23d00" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image style="cursor: pointer" src="img/plus.png" runat="server" id="img_expand"/>
                        
                        
                        <asp:Panel ID="PanelAttach" AutoGenerateColumns="False" runat="server" Style="display: none">
                            <asp:GridView ID="GridViewUser" runat="server" CssClass="table table-bordered table-striped input-sm" AutoGenerateColumns="false" Width="80%" >
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-Width="25" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>                                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Staff No." ItemStyle-Width="30" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("STAFFNO").ToString() != "" ? Eval("STAFFNO") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Staff Name" ItemStyle-Width="250" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("STAFFNAME").ToString() != "" ? Eval("STAFFNAME") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Email" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMAIL").ToString() != "" ? Eval("EMAIL") : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Role" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("TYPE").ToString() != "" ? Eval("TYPE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Code" ItemStyle-Width="40" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#f23d00" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPCode" runat="server" Text='<%# Eval("PROJECT_CODE").ToString() != "" ? Eval("PROJECT_CODE") : "-"%>' CssClass="input-sm"></asp:Label>      
                    </ItemTemplate>
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Project Description" ItemStyle-Width="280" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#f23d00" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblPDesc" runat="server" Text='<%# Eval("DESCRIPTION").ToString() != "" ? Eval("DESCRIPTION") : "-"%>' CssClass="input-sm"></asp:Label>      
                    </ItemTemplate>
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Project Manager" ItemStyle-Width="120" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#f23d00" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblPMgr" runat="server" Text='<%# Eval("PROJECT_MANAGER").ToString() != "" ? Eval("PROJECT_MANAGER") : "-"%>' CssClass="input-sm"></asp:Label>      
                    </ItemTemplate>
                </asp:TemplateField>  
                           
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>

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

</asp:Content>



