<%@ Page Title="" Language="C#" MasterPageFile="ADMIN_MasterPage.master" AutoEventWireup="true" CodeFile="Setup_Project.aspx.cs" Inherits="ADMIN_Setup_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">Setup Project</div>
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
                        <asp:TextBox ID="txtCode" runat="server" CssClass="form-control input-sm" Width="20" Visible="false"></asp:TextBox>

                    </div>
                </asp:TableCell>
            </asp:TableRow>
                            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Project Description</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                        <asp:Label ID="lblPDesc" runat="server" Text='None' CssClass="input-sm"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Project Manager</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                        <asp:Label ID="lblPMgr" runat="server" Text='None' CssClass="input-sm"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Template</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <div class="extraneous-non-semantic-markup">
                        <asp:Label ID="lblTemplate" runat="server" Text='None' CssClass="input-sm"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" Height="5"></asp:TableCell>
            </asp:TableRow>

            </asp:Table>
                
                    <ul class="nav nav-tabs" role="tablist">
            
                         <li <% if (Request.QueryString["mode"]==null) Response.Write("class='active'");%>>
                             <a href="Setup_Project.aspx?ID=<%= Request.QueryString["ID"]%>&ID1=<%= Request.QueryString["ID1"]%>">Incoming Module</a>
                         </li>
           
                    
                         <li <% if (Request.QueryString["mode"]=="out") Response.Write("class='active'");%>>
                             <a href="Setup_Project.aspx?ID=<%= Request.QueryString["ID"]%>&ID1=<%= Request.QueryString["ID1"]%>&mode=out">Outgoing Module</a>
                         </li>
           
                    </ul>

            <br />

            <% //---------------------------------------------------- Incoming Module ---------------------------------------------------- %>

            <asp:Table ID="tblIncoming" runat="server" Width="50%" CssClass="table table-bordered table-striped input-sm">

            <asp:TableRow>
                <asp:TableCell BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>#</b></asp:TableCell>
                <asp:TableCell BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Field Name</b></asp:TableCell>
                <asp:TableCell Wrap="false" BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Enable?</b></asp:TableCell>
            </asp:TableRow> 

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >1.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Reference No.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInRefNo" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >2.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Date of Document</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInDateDocument" runat="server" /></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >3.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Package</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInPackage" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >4.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Author</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInAuthor" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >5.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Company</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInCompany" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >6.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;DC Remarks</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInRemarks" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >7.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Attachment</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInAttach" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >8.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Urgency</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInUrgency" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >9.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Status<br /><em>&nbsp;(It will appear in the listing only)</em></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInStatus" runat="server" /></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >10.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Date Required</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInDateReq" runat="server" /></asp:TableCell>
            </asp:TableRow>
                            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >11.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Actionee</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInActionee" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >12.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;<asp:Label ID="Label6" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">**</asp:Label> Email Notification<br /><em>&nbsp;(Please ensure email of actionee is not null)</em></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInEmail" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >13.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Response Date</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInResponDate" runat="server" /></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >14.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Out Reference No.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInOutRefNo" runat="server" /></asp:TableCell>
            </asp:TableRow>    
             
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >15.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Remarks</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInActionTaken" runat="server" /></asp:TableCell>
            </asp:TableRow> 

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >16.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Transmittal Form<br /><em>&nbsp;(Please update initial of each team member at User Role -> Manage User Role)</em></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkInTransmittal" runat="server" /></asp:TableCell>
            </asp:TableRow>   
                                
            </asp:Table>

            <asp:Table ID="tblInNote" runat="server" Width="100%" CssClass="input-sm">
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
                    1. <u>Tracking No.</u>, <u>Date Received</u> and <u>Subject</u> are the mandatory fields.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. <asp:Label ID="Label1" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Able to add multiple records in the field.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    3. <asp:Label ID="Label7" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">**</asp:Label> Able to generate an email notification to the <u>Actionee</u>.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    4. Tick on <u>Enabled?</u> checkbox to enable the field name in the module.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    5. Click on the <b>Update</b> button to update the changes.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    6. Click on the <b>Back</b> to return to the previous screen.
                </asp:TableCell>
            </asp:TableRow>
                
            </asp:Table>
            
            <% //---------------------------------------------------- Outgoing Module ---------------------------------------------------- %>

            <asp:Table ID="tblOutgoing" runat="server" Width="40%" CssClass="table table-bordered table-striped input-sm">

            <asp:TableRow>
                <asp:TableCell BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>#</b></asp:TableCell>
                <asp:TableCell BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Field Name</b></asp:TableCell>
                <asp:TableCell Wrap="false" BackColor="#808080" HorizontalAlign="Center" ForeColor="#ffffff"><b>Enable?</b></asp:TableCell>
            </asp:TableRow> 

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >1.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Reference No.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutRefNo" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >2.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Date of Document</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutDateDocument" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >3.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Package</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutPackage" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >4.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Subject</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutTitle" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >5.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;Remarks</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutRemarks" runat="server" /></asp:TableCell>
            </asp:TableRow>
                
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >6.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Addressee</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkAddressee" runat="server" /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" >7.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" ForeColor="#cc0000">&nbsp;<asp:Label ID="Label8" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Attachment</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center"><asp:CheckBox ID="chkOutAttach" runat="server" /></asp:TableCell>
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
                    1. <u>Originator</u> is the mandatory fields.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. <asp:Label ID="Label2" runat="server" Text="Label" CssClass="input-sm" ForeColor="Blue">*</asp:Label> Able to add multiple records in the field.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    3. Tick on <u>Enabled?</u> checkbox to enable the field name in the module.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    4. Click on the <b>Update</b> button to update the changes.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    5. Click on the <b>Back</b> to return to the previous screen.
                </asp:TableCell>
            </asp:TableRow>
                
            </asp:Table>

            <hr />
                        
            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="true" CssClass="btn btn-default btn-sm" Width="62" OnClick="btnUpdate_Click" />            
            <asp:Button ID="btnBack" runat="server" text="Back" CssClass="btn btn-default btn-sm" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:Button>
                       
                   
        </div>
    </div>
      
</asp:Content>
