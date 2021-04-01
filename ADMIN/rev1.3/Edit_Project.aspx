<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Edit_Project.aspx.cs" Inherits="ADMIN_Edit_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Edit Project</div>
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
                <asp:TableCell VerticalAlign="Top"><b>Project Code</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">

                        <asp:Label ID="lblPCode" runat="server" Text='None' CssClass="input-sm"></asp:Label>
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control input-sm" Width="20" Visible="false"></asp:TextBox>

                    </div>
                </asp:TableCell>
            </asp:TableRow>
                            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Project Description</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                        <asp:TextBox ID="fldPDesc" runat="server" CssClass="form-control input-sm" Width="450" BackColor="#ffffcc"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Project Manager</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                        <asp:TextBox ID="fldPMgr" runat="server" CssClass="form-control input-sm" Width="300" BackColor="#ffffcc"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
                            
            </asp:Table>

            <asp:Table ID="tblNote" runat="server" Width="100%" CssClass="input-sm">
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
                    1. Click on the <b>Update</b> button to update the changes.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Back</b> to return to the previous screen.
                </asp:TableCell>
            </asp:TableRow>
                
            </asp:Table>
            
            <hr />

            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="true" CssClass="btn btn-default btn-sm" Width="62" OnClick="btnUpdate_Click" />            
            <asp:Button ID="btnBack" runat="server" text="Back" CssClass="btn btn-default btn-sm" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:Button>
            <asp:Button ID="btnDelete" runat="Server" text="Delete" CssClass="btn btn-default btn-sm" OnCommand="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?');" Enabled="false"/>
                        
            <hr />  

        </div>
    </div>
        
</asp:Content>
