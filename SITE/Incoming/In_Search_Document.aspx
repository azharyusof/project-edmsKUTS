<%@ Page Title="" Language="C#" MasterPageFile="../EDMS_MasterPage.master" AutoEventWireup="true" CodeFile="In_Search_Document.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Incoming_In_Search_Document" %>
<%@ Register Assembly="ZebraDatePickerDotNet" TagPrefix="CF" Namespace="ZebraDatePickerDotNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="panel panel-primary">
        <div class="panel-heading">[Project : <%= Request.QueryString["ID1"]%>] Incoming - Search Document</div>
        <div class="panel-body">

            <asp:HiddenField ID="hid_Year" runat="server" />
                        
            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>    

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Tracking No.</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:TextBox ID="fldTrackNo" runat="server" CssClass="form-control input-sm" Width="85" BackColor="#ffffcc"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                                            
            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Originator</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldOriginator" CssClass="form-control input-sm" Width="400" runat="server" AppendDataBoundItems="true" BackColor="#ffffcc">
                        </asp:DropDownList>
                </asp:TableCell>  
            </asp:TableRow>    
            
            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>In Reference No.</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:TextBox ID="fldRefNo" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Date of Document</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <table>
                        <tr>
                            <td align="left">(From) &nbsp;&nbsp;</td>
                            <td align="left">
                                <CF:ZDatePicker DefaultConfiguration="xyz" ID="fldDate1" runat="server" CssClass="form-control input-sm" Width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">(To)</td>
                            <td align="left">
                                <CF:ZDatePicker DefaultConfiguration="abc" ID="fldDate2" runat="server" CssClass="form-control input-sm" Width="100" />
                            </td>
                        </tr>
                    </table>                
                </asp:TableCell>
            </asp:TableRow>
            
           <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Package</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldPackage" CssClass="form-control input-sm" Width="350" runat="server" AppendDataBoundItems="true" BackColor="#ffffcc">
                        </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Type of Document</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldType" runat="server" CssClass="form-control input-sm" Width="165" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Subject</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:TextBox ID="fldSubject" runat="server" CssClass="form-control input-sm" Width="400" TextMode="MultiLine" Rows="4" BackColor="#ffffcc"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Author</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldAuthor" CssClass="form-control input-sm" Width="350" runat="server" AppendDataBoundItems="true" BackColor="#ffffcc">
                        </asp:DropDownList>
                </asp:TableCell>  
            </asp:TableRow> 
                
            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Subject File</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldSubjectFile" runat="server" CssClass="form-control input-sm" Width="250" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Year</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldYear" runat="server" CssClass="form-control input-sm" Width="170" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow> 
                
            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Attachment's Title</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:TextBox ID="fldAttach" runat="server" CssClass="form-control input-sm" Width="350" TextMode="SingleLine" BackColor="#ffffcc"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>              
            </asp:Table>
            
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
                    1. You may enter more than one search criteria and click on the <b>Search</b> button.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Reset</b> button to clear the data.
                </asp:TableCell>
            </asp:TableRow>         
            </asp:Table>  
        
            <asp:Table ID="tblResultNote" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    3. Click on <u>Tracking No.</u> to view details or click <img src="../Img/icon_pdf_small.gif"/> for scanned document. 
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    4. Click on <img src="../Img/logo_excel.png"/> to print out search result in Excel format. 
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>                      

        <hr />

        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default btn-sm" Width="61" OnClick="btnSearch_Click"/>
        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" />

            <asp:Table ID="Table2" runat="server" Width="100%" CssClass="input-sm" Visible="false">
            <asp:TableRow>            
                <asp:TableCell HorizontalAlign="Left" Height="35">
                    <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Img/logo_excel.png" AlternateText="Excel" CssClass="input-sm" Width="20" Height="20" OnClick="btnExcel_Click"/> &nbsp;<b>Incoming Search Result</b>
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>

            <asp:GridView ID="GridViewResult" runat="server" CssClass="table-bordered input-sm" AutoGenerateColumns="False" DataKeyNames="ID" ShowHeaderWhenEmpty="true" OnRowCommand="GridViewResult_RowCommand" OnRowDataBound="GridViewResult_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                        <asp:Label ID="lblScanDoc" runat="server" Text='' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="30" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Eval("PROJECT_CODE") + "/" + Eval("COMPANY_CODE") + "/incoming/" + Eval("FLD_IN_DATE", "{0:yyyy}") + "/" + Eval("FLD_IN_SERIAL") + ".pdf" %>' Target="_blank"><asp:Image style="cursor: pointer" src="../Img/icon_pdf_small.gif" runat="server" id="img_all" Visible="false"/></asp:HyperLink>   
                        <asp:HyperLink ID="HyperLinkPNC" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Eval("PROJECT_CODE") + "/" + Eval("COMPANY_CODE") + "/incoming/" + Eval("FLD_IN_DATE", "{0:yyyy}") + "/" + Eval("ID") + "/" + Eval("FLD_IN_SERIAL") + ".pdf" %>' Target="_blank"><asp:Image style="cursor: pointer" src="../Img/security.jpg" runat="server" id="imgSecure" Visible="false"/></asp:HyperLink>     
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tracking No." HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Wrap="false">
                    <ItemTemplate>   
                        <a href='In_Edit_Document.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%= Request.QueryString["ID1"] %>&ID2=<%# Eval("ID")%>&url=S'" target="_blank"><asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm"></asp:Label></a>
                        
                        <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                        <asp:Label ID="COMPANY_CODE" runat="server" Text='<%# Eval("COMPANY_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>
                        <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>                        
                        <asp:Label ID="FLD_IN_SERIAL" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm" Visible="false"></asp:Label>
                        <asp:Label ID="ID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tracking No." HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Wrap="false">
                    <ItemTemplate>   
                        <asp:Label ID="track_no" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-sm" Visible="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Originator" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("FLD_COMPANY").ToString() != "" ? Eval("FLD_COMPANY").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date Received" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblRcvdDt" runat="server" Text='<%# Eval("FLD_IN_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Reference No." HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblRefNo" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString().ToUpper().HighlightKeyWords(search_Word1, "yellow", false) %>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date of Document" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblDtDoc" runat="server" Text='<%# Eval("FLD_CORR_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Package" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblPackage" runat="server" Text='<%# Eval("FLD_PACKAGE").ToString() != "" ? Eval("FLD_PACKAGE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type of Document" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("FLD_TYPE").ToString() != "" ? Eval("FLD_TYPE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Subject" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="250" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("FLD_TITLE").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) %>' />                                              
                        <asp:Label ID="lblConfidential" runat="server" Text='<%# Eval("FLD_CONFIDENTIAL").ToString() != "" ? Eval("FLD_CONFIDENTIAL").ToString().ToUpper() : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Author" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("FLD_AUTHOR").ToString() != "" ? Eval("FLD_AUTHOR").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Attachment" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>                        
                        
                        <asp:GridView ID="GridViewAttach" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Request.QueryString["ID1"] + "/" + Eval("COMPANY_CODE") + "/incoming/attachment/" + Eval("ID") + "/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString().ToUpper().HighlightKeyWords(search_Word2, "yellow", false)%></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("FILENAME").ToString() == "" ? Eval("FLD_ATCH_TITLE").ToString().ToUpper().HighlightKeyWords(search_Word2, "yellow", false) : ""%>' CssClass="input-sm" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            
                         </asp:GridView>

                         <asp:Label ID="lblAttach" runat="server" CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
            <br />

            <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblMessage1" runat="server" Text="Label" Visible="false"></asp:Label>

        </div>
    </div>

    <script type="text/javascript">
        var xyz = {
            format: 'd-M-Y',
            pair: $('#<%= fldDate2.ClientID%>')
        };

        var abc = {
            format: 'd-M-Y',
        };
    </script>

</asp:Content>
