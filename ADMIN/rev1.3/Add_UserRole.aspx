<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Add_UserRole.aspx.cs" Inherits="ADMIN_Add_UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Add User Role</div>
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
                <asp:TableCell ColumnSpan="3">
                    <div id="errDvfldPName" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Project Name is required!
                    </div>

                    <div id="errDvfldStaffNo" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Staff Name is required!
                    </div>

                    <div id="errDvfldRole" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Role is required!
                    </div>

                    <div id="dvReset" runat="server" class="alert alert-info input-sm" role="alert">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;All field has been reset!
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label4" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Project Name</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="fldPName" runat="server" CssClass="form-control input-sm" Width="300" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label2" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Staff Name</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="fldStaffNo" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label3" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Role</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="fldRole" runat="server" CssClass="form-control input-sm" Width="160" BackColor="#ffffcc"></asp:DropDownList>  
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
                    1. <asp:Label ID="Label5" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label>  Mandatory field.
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
                
        </asp:Table>

        <hr />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default btn-sm" Width="50" OnClick="btnSave_Click" />
        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" />
     
        </div>
    </div>
    
         
</asp:Content>