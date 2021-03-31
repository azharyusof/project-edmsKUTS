<%@ Page Title="" Language="C#" MasterPageFile="../EDMS_MasterPage.master" AutoEventWireup="true" CodeFile="Out_Search_Document.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Outgoing_Out_Search_Document" EnableEventValidation="false" %>
<%@ Register Assembly="ZebraDatePickerDotNet" TagPrefix="CF" Namespace="ZebraDatePickerDotNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">[Project : <%= Request.QueryString["ID1"]%>] Outgoing - Search Document</div>
        <div class="panel-body">

            <asp:Table ID="Table1" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell Width="175"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4">
                    <div id="dvErrDate" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;&nbsp;Please select Date (To) field.
                    </div>
                </asp:TableCell>
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
                <asp:TableCell VerticalAlign="Top"><b>Reference No.</b></asp:TableCell>
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
                                <CF:ZDatePicker DefaultConfiguration="xyz" ID="fldDateFm" runat="server" CssClass="form-control input-sm" Width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">(To)</td>
                            <td align="left">
                                <CF:ZDatePicker DefaultConfiguration="abc" ID="fldDateTo" runat="server" CssClass="form-control input-sm" Width="100" />
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
                    <asp:DropDownList ID="fldPackage" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:DropDownList>
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
                <asp:TableCell VerticalAlign="Top"><b>Originator</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldOriginator" runat="server" CssClass="form-control input-sm" Width="300" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>File Index</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="dropIndex" runat="server" CssClass="form-control input-sm" Width="200" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Company</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25" VerticalAlign="Top"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>Addressee</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><b>:</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <asp:DropDownList ID="fldAddressee" runat="server" CssClass="form-control input-sm" Width="350" BackColor="#ffffcc"></asp:DropDownList>
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
            </asp:Table>
            
            <asp:Table ID="tblOutNote" runat="server" Width="100%" CssClass="input-sm">
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

            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default btn-sm" Width="61" OnClick="btnSearch_Click" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" />

            <asp:Table ID="Table2" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>            
                <asp:TableCell HorizontalAlign="Left" Height="35">
                    <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Img/logo_excel.png" AlternateText="Excel" CssClass="input-sm" Width="20" Height="20" OnClick="btnExcel_Click"/> &nbsp;<b>Outgoing Search Result</b>
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
            
            <asp:GridView ID="GridViewResult" runat="server" CssClass="table-bordered input-sm" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="ID" AllowSorting="true" OnSorting="GridViewResult_Sorting" OnRowDataBound="GridViewResult_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ShowHeader="false" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "http://192.168.50.41/document/" + Eval("PROJECT_CODE") + "/outgoing/" + Eval("FLD_DOC_DATE", "{0:yyyy}") + "/" + Eval("TRACK_NO") + ".pdf" %>' Target="_blank"><asp:Image style="cursor: pointer" src="../Img/icon_pdf_small.gif" runat="server" id="img_all" /></asp:HyperLink>                        
                                                                     
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tracking No." ItemStyle-Width="100" SortExpression="ID" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <a href='Out_Edit_Document.aspx?ID=<%= Request.QueryString["ID"] %>&ID1=<%= Request.QueryString["ID1"] %>&ID2=<%# Eval("ID")%>&url=OSD'><asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_OUT_SERIAL")%>' CssClass="input-sm"></asp:Label></a>                        
                        <asp:Label ID="FLD_OUT_SERIAL" runat="server" Text='<%# Eval("FLD_OUT_SERIAL")%>' CssClass="input-sm" Visible="true"></asp:Label>
                        <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>

                        <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>
                        <asp:Label ID="TRACK_NO" runat="server" Text='<%# Eval("TRACK_NO")%>' CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tracking No." ItemStyle-Width="100" SortExpression="ID" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblTrackNo" runat="server" Text='<%# Eval("FLD_OUT_SERIAL").ToString()  != "" ? Eval("FLD_OUT_SERIAL") : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Reference No." SortExpression="FLD_REFERENCE" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblRN" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString()  != "" ? Eval("FLD_REFERENCE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date of Document" SortExpression="FLD_DOC_DATE" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("FLD_DOC_DATE").ToString()  != "" ? Convert.ToDateTime(Eval("FLD_DOC_DATE")).ToString("dd-MMM-yyyy") : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Package" SortExpression="FLD_PACKAGE" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblPack" runat="server" Text='<%# Eval("FLD_PACKAGE").ToString()  != "" ? Eval("FLD_PACKAGE").ToString().ToUpper() : "-"%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type of Document" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("FLD_TYPE").ToString() != "" ? Eval("FLD_TYPE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Subject" SortExpression="FLD_TITLE1" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblSub" runat="server" Text='<%# Eval("FLD_TITLE1").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) %>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Originator" SortExpression="StaffName" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblOri" runat="server" Text='<%# Eval("StaffName").ToString()  != "" ? Eval("StaffName").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="File Index" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblIndex" runat="server" Text='<%# Eval("FLD_INDEX").ToString() != "" ? Eval("FLD_INDEX").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        
                         <asp:GridView ID="GridViewCompany" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None" DataKeyNames="ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%#Container.DataItemIndex + 1%>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Company" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("FLD_COMPANY").ToString()  != "" ? Eval("FLD_COMPANY").ToString().ToUpper().HighlightKeyWords(search_Word1, "yellow", false) : "-"%>' CssClass="input-sm"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Addressee" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        
                        <asp:GridView ID="GridViewAddressee" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None" DataKeyNames="ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Addressee" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddressee" runat="server" Text='<%# Eval("FLD_ADDRESSEE").ToString()  != "" ? Eval("FLD_ADDRESSEE").ToString().ToUpper().HighlightKeyWords(search_Word2, "yellow", false) : "-"%>' CssClass="input-sm"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Attachment" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>                        
                        
                        <asp:GridView ID="GridViewAttachment" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://192.168.50.41/document/" + Request.QueryString["ID1"] + "/outgoing/attachment/" + Eval("ID") + "/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString().ToUpper()%></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                         </asp:GridView>

                         <asp:Label ID="lblAttachment" runat="server" CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        var xyz = {
            format: 'd-M-Y',
            pair: $('#<%= fldDateTo.ClientID%>')
        };

        var abc = {
            format: 'd-M-Y', 
        };
    </script>

</asp:Content>

