<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Add_Project.aspx.cs" Inherits="ADMIN_Add_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Add Project</div>
        <div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <div id="errDvfldPCode" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Project Code is required!
                    </div>

                    <div id="errDvfldPDesc" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Project Description is required!
                    </div>

                    <div id="errDvfldPMgr" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Project Manager is required!
                    </div>

                    <div id="dvReset" runat="server" class="alert alert-info input-sm" role="alert">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;All field has been reset!
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label4" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Project Code</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldPCode" runat="server" CssClass="form-control input-sm" Width="100" MaxLength="15" BackColor="#ffffcc"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label2" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Project Description</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldPDesc" runat="server" CssClass="form-control input-sm" Width="450" BackColor="#ffffcc"></asp:TextBox>                    
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label5" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Project Manager</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldPMgr" runat="server" CssClass="form-control input-sm" Width="300" BackColor="#ffffcc"></asp:TextBox>
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
                    1. <asp:Label ID="Label1" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label>  Mandatory field.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Save</b> button to add new record.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    3. Click on the <b>Reset</b> button to clear the data.
                </asp:TableCell>
            </asp:TableRow>
              
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    4. To configure setting for each project, go to <b>Project</b> >> <b>Project Listing</b>, click &nbsp;<asp:Image src="Img/setup.jpg" runat="server" AlternateText="Click here"/>&nbsp; to enable or disable field(s) by module.
                </asp:TableCell>
            </asp:TableRow>
              
        </asp:Table>

        <hr />

        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default btn-sm" Width="50" OnClick="btnSave_Click" />
        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" />
        
        </div>
    </div>
           
</asp:Content>