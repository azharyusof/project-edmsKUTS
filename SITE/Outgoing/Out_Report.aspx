<%@ Page Title="" Language="C#" MasterPageFile="../EDMS_MasterPage.master" AutoEventWireup="true" CodeFile="Out_Report.aspx.cs" Inherits="Outgoing_Out_Report"  EnableEventValidation="false" %>
<%@ Register Assembly="ZebraDatePickerDotNet" TagPrefix="CF" Namespace="ZebraDatePickerDotNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="panel panel-primary">
        <div class="panel-heading">[Project : <%= Request.QueryString["ID1"]%>] Outgoing - Report</div>
        <div class="panel-body">

            <asp:Table ID="Table1" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell Width="125"></asp:TableCell>
                <asp:TableCell Width="25"></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4">
                    <div id="dvErrDate" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;&nbsp;Please select Date (To) field
                    </div>
                    <div id="dvErrMsg" runat="server" class="alert alert-danger input-sm" role="alert">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;&nbsp;Please select Date/Tracking No.
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell ColumnSpan="3"><b>Outgoing Listing By Date Of Document :</b></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25">&nbsp;</asp:TableCell>
                <asp:TableCell>Date (From)</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <CF:ZDatePicker DefaultConfiguration="xyz" ID="fldDateFm" runat="server" CssClass="form-control input-sm" Width="100" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25">&nbsp;</asp:TableCell>
                <asp:TableCell>Date (To)</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <CF:ZDatePicker DefaultConfiguration="abc" ID="fldDateTo" runat="server" CssClass="form-control input-sm" Width="100" />
                </asp:TableCell>
            </asp:TableRow>                          

            <asp:TableRow>
                <asp:TableCell ColumnSpan="4" Height="8"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25"><span class="glyphicon glyphicon-plus"></span></asp:TableCell>
                <asp:TableCell ColumnSpan="3"><b>Outgoing Listing By Tracking No. :</b></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="25">&nbsp;</asp:TableCell>
                <asp:TableCell VerticalAlign="Top">Tracking No.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top">:</asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox ID="fldTNo" runat="server" CssClass="form-control input-sm" SelectionMode="Multiple" Width="120" Height="145" BackColor="#ffffcc"></asp:ListBox>
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
                    1. Please select parameter and click on the <b>Preview</b> button.
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" ForeColor="#666666">
                    2. Click on the <b>Reset</b> button to clear the data.
                </asp:TableCell>
            </asp:TableRow>         
            </asp:Table>  
            
            <hr />

            <asp:Button ID="btnPreview" runat="server" Text="Preview" CssClass="btn btn-default btn-sm" Width="70" OnClick="btnPreview_Click" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-sm" Width="55" OnClick="btnReset_Click" />

            <asp:Table ID="Table2" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow> 
                <asp:TableCell HorizontalAlign="Left" Height="35">
                    <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Img/logo_excel.png" AlternateText="Excel" CssClass="input-sm" Width="20" Height="20" OnClick="btnExcel_Click"/> &nbsp;<b>Outgoing Listing Report</b>
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>

            <asp:GridView ID="GridViewResult" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="id" OnRowCreated="GridViewResult_RowCreated" OnRowDataBound="GridViewResult_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="10" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tracking No" ItemStyle-Width="100" SortExpression="ID" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_OUT_SERIAL")%>' CssClass="input-sm"></asp:Label>
                        <asp:Label ID="id" runat="server" Text='<%# Eval("id")%>' CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Booked Date" SortExpression="FLD_BOOK_DATE" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkDate" runat="server" Text='<%# Eval("FLD_BOOK_DATE").ToString()  != "" ? Convert.ToDateTime(Eval("FLD_BOOK_DATE")).ToString("dd-MMM-yyyy") : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Reference No" SortExpression="FLD_REFERENCE" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblRN" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString()  != "" ? Eval("FLD_REFERENCE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Document" SortExpression="FLD_DOC_DATE" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("FLD_DOC_DATE").ToString()  != "" ? Convert.ToDateTime(Eval("FLD_DOC_DATE")).ToString("dd-MMM-yyyy") : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Package" SortExpression="FLD_PACKAGE" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblPack" runat="server" Text='<%# Eval("FLD_PACKAGE").ToString()  != "" ? Eval("FLD_PACKAGE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject" SortExpression="FLD_TITLE1" ItemStyle-Width="150" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblSub" runat="server" Text='<%# Eval("FLD_TITLE1").ToString()  != "" ? Eval("FLD_TITLE1").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Originator" SortExpression="OriginatorName" ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblOri" runat="server" Text='<%# Eval("OriginatorName").ToString()  != "" ? Eval("OriginatorName").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        
                         <asp:GridView ID="GridViewCompany" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%#Container.DataItemIndex + 1%>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Company" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("FLD_COMPANY").ToString()  != "" ? Eval("FLD_COMPANY").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        <asp:Label ID="lblCompany" runat="server" CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



<asp:TemplateField HeaderText="Addressee" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#2E5B89" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        
                        <asp:GridView ID="GridViewAddressee" runat="server" AutoGenerateColumns="false" Width="50%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>)        
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Addressee" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddressee" runat="server" Text='<%# Eval("FLD_ADDRESSEE").ToString()  != "" ? Eval("FLD_ADDRESSEE").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        <asp:Label ID="lblAddressee" runat="server" CssClass="input-sm" Visible="false"></asp:Label>
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

