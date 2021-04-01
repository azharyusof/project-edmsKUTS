<%@ Page Title="" Language="C#" MasterPageFile="../EDMS_BlankMasterPage.master" AutoEventWireup="true" CodeFile="In_Action_Document.aspx.cs" Inherits="SITE2_Incoming_In_Action_Document" %>
<%@ Register Assembly="ZebraDatePickerDotNet" TagPrefix="CF" Namespace="ZebraDatePickerDotNet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">[Project : <%= txtCode.Text%>] Incoming Document</div>
        <div class="panel-body">
                               
            <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Incoming Details</a>
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
                    <div id="errDvfldActionDt" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Action Taken Date is required!
                    </div>

                    <div id="errDvfldAction" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Action Taken is required!
                    </div>

                    <div id="dvStatus" runat="server" class="alert alert-success input-sm" role="alert">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;&nbsp;Successfully updated!
                    </div>
                    <div id="dvErrUpload" runat="server" class="alert alert-info input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;&nbsp;No scanned document found!
                    </div>
                </asp:TableCell>
            </asp:TableRow>                    

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" Height="25"><b>Tracking No.</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <a href="http://192.168.50.41/document/<%=txtCode.Text%>/incoming/<%=txtYr.Text%>/<%=txtTrackNo.Text%>.pdf" target="_blank" title="Click here"><asp:Image src="../Img/icon_pdf_small.gif" runat="server" id="img_all" Visible="false"/></a>

                    
                    &nbsp;<asp:Label ID="Label1" runat="server" Text='None' CssClass="input-sm" Visible="false"></asp:Label>     
                                        
                    <asp:TextBox ID="txtYr" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtTrackNo" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtCode" runat="server" Visible="false"></asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Date Received</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldDateReceived" runat="server" CssClass="form-control input-sm" Width="100" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                            
            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Reference No.</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldRefNo" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Date of Document</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldDateDocument" runat="server" CssClass="form-control input-sm" Width="100" BackColor="#ffffcc" Enabled="false"></asp:TextBox>                    
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Package</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldPackage" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><b>Subject</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldSubject" runat="server" CssClass="form-control input-sm" Width="400" TextMode="MultiLine" Rows="4" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Author</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldAuthor" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>  
            </asp:TableRow>
                            
            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Company</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldCompany" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>  
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell Height="10"></asp:TableCell>
            </asp:TableRow>     
            </asp:Table>
            

            <div runat="server">

                <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Attachment</a>
                        </li>                
                </ul>

                <asp:Table ID="Table7" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell Height="5"></asp:TableCell>
                </asp:TableRow>     
                </asp:Table>


                <asp:GridView ID="GridViewAttachment" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="80%" ShowHeaderWhenEmpty="true" OnDataBound="GridViewAttachment_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" ItemStyle-Width="450" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://192.168.50.41/document/" + Eval("PROJECT_CODE") + "/incoming/attachment/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString()%></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" ItemStyle-Width="450" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("FLD_ATCH_TITLE").ToString()  != "" ? Eval("FLD_ATCH_TITLE") : "-"%>' CssClass="input-sm"></asp:Label>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Copy" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCopy" runat="server" Text='<%# Eval("FLD_ATCH_COPY").ToString()  != "" ? Eval("FLD_ATCH_COPY") : "-"%>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>                                
                </asp:GridView>
            </div>
             
            <asp:Table ID="Table9" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell Height="5"></asp:TableCell>
            </asp:TableRow>     
            </asp:Table>
                  
            <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Action Required</a>
                        </li>                
            </ul>
                               
            <asp:Table ID="Table4" runat="server" Width="100%" CssClass="input-sm">            
            <asp:TableRow>
                <asp:TableCell Width="175" Height="10"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Urgency</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnHigh" runat="server" Text="High" CssClass="btn btn-default btn-sm" ForeColor="Red" Enabled="false"/>
                        &nbsp;<asp:Button ID="btnMedium" runat="server" Text="Medium" CssClass="btn btn-default btn-sm" ForeColor="Blue" Enabled="false"/>
                        &nbsp;<asp:Button ID="btnLow" runat="server" Text="Low" CssClass="btn btn-default btn-sm" ForeColor="Green" Enabled="false"/>
                        &nbsp;<asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-default btn-sm" Enabled="false"/>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" Height="25"><b></b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b></b></asp:TableCell>
                <asp:TableCell>
                    <b>Note :</b> High - 3 days, Medium - 7 days, Low - 14 days
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Date Required</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldDateRequired" runat="server" CssClass="form-control input-sm" Width="100" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell Height="10"></asp:TableCell>
            </asp:TableRow>     
            </asp:Table>

            <div runat="server">

                <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Actionee</a>
                        </li>                
                </ul>

                <asp:Table ID="Table1" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell Height="5"></asp:TableCell>
                </asp:TableRow>     
                </asp:Table>

                <asp:GridView ID="GridViewActionee" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="80%" ShowHeaderWhenEmpty="true" OnRowDataBound="GridViewActionee_RowDataBound" OnDataBound="GridViewActionee_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Actionee" ItemStyle-Width="300" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblActionee" runat="server" Text='<%# Eval("ACTIONEEName").ToString()  != "" ? Eval("ACTIONEEName") : "-"%>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                  
                    <asp:TemplateField HeaderText="Info?" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblInfo" runat="server" Text='<%# Eval("INFO").ToString()  != "" ? Eval("INFO") : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                            <asp:Image src="img/yes1.png" runat="server" id="imgInfo" Visible="false"/>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action?" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblAction" runat="server" Text='<%# Eval("ACTION").ToString()  != "" ? Eval("ACTION") : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                            <asp:Image src="img/yes1.png" runat="server" id="imgAction" Visible="false"/>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action Required" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Label ID="lblActionReq" runat="server" Text='<%# Eval("REQUIRED_ACTION").ToString()  != "" ? Eval("REQUIRED_ACTION") : "-"%>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action Taken" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Label ID="lblActionTaken" runat="server" Text='<%# Eval("ACTION_TAKEN").ToString()  != "" ? Eval("ACTION_TAKEN") : "-"%>' CssClass="input-sm"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>            
                </asp:GridView>
            </div>
             
            <asp:Table ID="Table10" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell Height="5"></asp:TableCell>
            </asp:TableRow>     
            </asp:Table>
                        
            <ul class="nav nav-tabs" role="tablist" style="overflow:hidden; vertical-align:top;">                          
                        <li class='active'>
                             <a href="#" style="color:blue; Background:#E5E5E5">Response Taken</a>
                        </li>                
            </ul>
                              
            <asp:Table ID="Table5" runat="server" Width="100%" CssClass="input-sm">            
            <asp:TableRow>
                <asp:TableCell Width="175" Height="10"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Actionee</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldActionee" runat="server" CssClass="form-control input-sm" Width="300" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Type</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldType" runat="server" CssClass="form-control input-sm" Width="200" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><b>Action Required</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldActionRequired" runat="server" CssClass="form-control input-sm" Width="400" TextMode="MultiLine" Rows="3" BackColor="#ffffcc" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                  
            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label4" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Action Taken Date</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <CF:ZDatePicker DefaultConfiguration="custom_DefaultDate" ID="fldDateResponse" runat="server" CssClass="form-control input-sm" Width="100" />   
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell VerticalAlign="Top"><asp:Label ID="Label3" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> <b>Action Taken</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldActionTaken" runat="server" CssClass="form-control input-sm" Width="400" TextMode="MultiLine" Rows="4" BackColor="#eeeeee"></asp:TextBox>
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
                    1. <asp:Label ID="Label5" runat="server" Text="Label" CssClass="input-sm" ForeColor="Red">*</asp:Label> Mandatory field.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on <img src="../Img/icon_pdf_small.gif"/> for scanned document.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    3. Click on the <b>Update</b> button to update the record.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    4. Click on the <b>Close Window</b> to close the window.
                </asp:TableCell>
            </asp:TableRow>                
            </asp:Table>            

            <hr />

            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default btn-sm" Width="62" OnClick="btnUpdate_Click"/>    
            <asp:Button ID="btnBack" runat="server" Text="Close Window" CssClass="btn btn-default btn-sm" OnClientClick="javascript:window.close();"/>
            

        </div>
    </div>
    
    
    
</asp:Content>
