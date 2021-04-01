<%@ Page Title="" Language="C#" MasterPageFile="../EDMS_MasterPage.master" AutoEventWireup="true" CodeFile="In_Actionee_Document.aspx.cs" Inherits="Incoming_In_Actionee_Document" %>
<%@ Register Assembly="ZebraDatePickerDotNet" TagPrefix="CF" Namespace="ZebraDatePickerDotNet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">[Project : <%= Request.QueryString["ID1"]%>] Incoming - Edit Document</div>
        <div class="panel-body">
                               
            <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Actionee Details</a>
                        </li>                
            </ul>
                     
            <asp:Table ID="Table3" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="175" Height="10"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>            
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <div id="dvStatus" runat="server" class="alert alert-success input-sm" role="alert">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;&nbsp;Successfully updated!
                    </div>
                </asp:TableCell>
            </asp:TableRow>  
                
            <asp:TableRow>
                <asp:TableCell Height="25"><b>Tracking No.</b></asp:TableCell>
                <asp:TableCell><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTNo" runat="server" Text='None' CssClass="input-sm"></asp:Label>
                </asp:TableCell>
            </asp:TableRow> 

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Actionee</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="fldActionee" runat="server" CssClass="form-control input-sm" Width="350" EnableViewState="true" BackColor="#ffffcc"></asp:DropDownList>                    
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Info?</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton ID="chkInfo" GroupName="type" runat="server"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<em>(* For Info, <u>Action Required</u> field is not required)</em>                  
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Action?</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton ID="chkAction" GroupName="type" runat="server"/>     
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Action Required</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldActionReq" runat="server" CssClass="form-control input-sm" Width="400" TextMode="MultiLine" Rows="4" BackColor="#ffffcc"></asp:TextBox>       
                </asp:TableCell>
            </asp:TableRow>  
            </asp:Table>

            <hr />

            <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="100" Height="10"></asp:TableCell>
                <asp:TableCell Width="20"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="2">
                    <b>Note : </b>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    1. Click on the <b>Update</b> button to update the record.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    &nbsp;&nbsp;&nbsp;&nbsp;<em>(** Email notification will be sent to the <u><b>Actionee</b></u>)</em>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Back</b> to return to the previous screen.
                </asp:TableCell>
            </asp:TableRow>                 
            </asp:Table>            

            <hr />

            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default btn-sm" Width="62" OnClick="btnUpdate_Click"/>    
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default btn-sm" OnClick="btnBack_Click"/>
            

        </div>
    </div>
    
</asp:Content>
