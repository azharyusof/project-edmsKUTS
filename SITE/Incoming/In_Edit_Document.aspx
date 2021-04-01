<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="In_Edit_Document.aspx.cs" Inherits="SITE_Incoming_In_Edit_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        body {
            font-family: 'Varela Round', sans-serif;
        }

        .modal-backdrop {
            z-index: -1;
        }

        .modal-login {
            width: 350px;
        }

            .modal-login .modal-content {
                padding: 20px;
                border-radius: 1px;
                border: none;
            }

            .modal-login .modal-header {
                border-bottom: none;
                position: relative;
                justify-content: center;
            }

            .modal-login h4 {
                text-align: center;
                font-size: 26px;
            }

            .modal-login .form-group {
                margin-bottom: 20px;
            }

            .modal-login .form-control, .modal-login .btn {
                min-height: 40px;
                border-radius: 30px;
                font-size: 15px;
                transition: all 0.5s;
            }

            .modal-login .form-control {
                font-size: 13px;
            }

                .modal-login .form-control:focus {
                    border-color: #a177ff;
                }

            .modal-login .hint-text {
                text-align: center;
                padding-top: 10px;
            }

            .modal-login .close {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-login .btn, .modal-login .btn:active {
                border: none;
                background: #a177ff !important;
                line-height: normal;
            }

                .modal-login .btn:hover, .modal-login .btn:focus {
                    background: #8753ff !important;
                }

            .modal-login .hint-text a {
                color: #999;
            }

        .trigger-btn {
            display: inline-block;
            margin: 100px auto;
        }
    </style>

    <form class="validate-form" runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">INCOMING</h1>
                <h3 class="font-weight-bold text-muted">EDIT PROJECT</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Incoming Details</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="70"></asp:TableCell>
                            <asp:TableCell Width="135" Height="10"></asp:TableCell>
                            <asp:TableCell Width="80"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblTrackNo" runat="server" Text="Tracking No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <a href="http://edms.str.opusbhd.com/document/<%=Request.QueryString["ID1"]%>/<%=fldCompanyCode.Text%>/incoming/<%=fldYr.Text%>/<%=fldTrackNo.Text%>.pdf" target="_blank" title="Click here">
                                        <asp:Image src="../Img/icon_pdf_small.gif" runat="server" ID="img_all" Visible="false" CssClass="form-control form-control-sm" /></a>
                                    <asp:Label ID="lblNone" runat="server" Text='None' CssClass="input-sm" Visible="false" />
                                    <asp:TextBox ID="fldYr" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="fldTrackNo" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="fldCompanyCode" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDateReceived" runat="server" Text="Date Received" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateReceived" runat="server" width="220" class="dtReceive form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblOriginator" runat="server" Text="Originator" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <div class="input-group-prepend">
                                        <asp:Label ID="lblOriginatorCode" runat="server" CssClass="form-control-sm font-weight-bold" Width="100" BackColor="LightGray"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="fldOriginator" runat="server" CssClass="form-control form-control-sm" Width="400" Enabled="false"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblRefNo" runat="server" Text="In Reference No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRefNo" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDateDoc" runat="server" Text="Date of Document" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateDocument" runat="server" width="220" class="dtDocument form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldPackage" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldPackage_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewPackage" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblTypeDoc" runat="server" Text="Type of Document" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldType" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewType" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldSubject" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblAuthor" runat="server" Text="Author" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldAuthor" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldAuthor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewAuthor" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblUrgency" runat="server" Text="Urgency" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <p class="text-left">
                                    <asp:Label ID="lblNote" runat="server" Text="Note: High - 3 days, Medium - 7 days, Low - 14 days" CssClass="font-weight-bold" />
                                </p>
                                <div class="form-group row">
                                    <asp:Button ID="btnHigh" runat="server" Text="High" CssClass="btn btn-danger btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnHigh_Click" />
                                    <asp:Button ID="btnMedium" runat="server" Text="Medium" CssClass="btn btn-primary btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnMedium_Click"/>
                                    <asp:Button ID="btnLow" runat="server" Text="Low" CssClass="btn btn-success btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnLow_Click" />
                                    <asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-light btn-sm border-dark form-control font-weight-bold" Width="100" OnClick="btnInfo_Click" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDateRequired" runat="server" Text="Date Required" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateRequired" runat="server" width="220" class="dtRequired form-control form-control-sm" readonly="readonly" />
                                    <asp:HiddenField ID="fldUrgency" runat="server" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblSubjectFile" runat="server" Text="Subject File" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldSubjectFile" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldSubjectFile_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewSubjectFile" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblConfidentiality" runat="server" Text="Type of Confidentiality" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldConfidential" runat="server" CssClass="form-control form-control-sm dropdown-toggle" Width="400"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblDCRemarks" runat="server" Text="DC Remarks" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldRemarks" CssClass="form-control form-control-sm" runat="server" Width="400" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <br />

                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Attachment</a>
                        </li>
                    </ul>

                    <br />

                    <p>
                        <asp:LinkButton ID="lbtnAddAttach" runat="server" CssClass="btn btn-default btn-sm" data-toggle="modal" data-target="#myModalAttach" OnClientClick="funcOpen();" Width="150" UseSubmitBehavior="false"><span class="glyphicon glyphicon-plus"></span>&nbsp;&nbsp;Add Attachment</asp:LinkButton>
                    </p>

                    <asp:GridView ID="GridViewAttach" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="60%" ShowHeaderWhenEmpty="true" OnRowDataBound="GridViewAttach_RowDataBound" OnRowCommand="GridViewAttach_RowCommand" OnRowDeleting="GridViewAttach_RowDeleting" OnDataBound="GridViewAttach_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Name" ItemStyle-Width="450" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Request.QueryString["ID1"] + "/" + Eval("COMPANY_CODE") + "/incoming/attachment/" + Request.QueryString["ID2"] + "/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString().ToUpper()%></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="35" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("RecID")%>' CommandName="Delete" Width="34"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Actionee</a>
                        </li>
                    </ul>

                    <br />

                    <p>
                        <asp:LinkButton ID="lbtnAddActionee" runat="server" CssClass="btn btn-default btn-sm" data-toggle="modal" data-target="#myModalActionee" OnClientClick="funcOpen1();" Width="150" UseSubmitBehavior="false"><span class="glyphicon glyphicon-plus"></span>&nbsp;&nbsp;Add Actionee</asp:LinkButton>
                    </p>

                    <asp:GridView ID="GridViewActionee" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="80%" ShowHeaderWhenEmpty="true" OnRowDataBound="GridViewActionee_RowDataBound" OnRowCommand="GridViewActionee_RowCommand" OnRowDeleting="GridViewActionee_RowDeleting" OnDataBound="GridViewActionee_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actionee" ItemStyle-Width="300" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblActionee" runat="server" Text='<%# Eval("ACTIONEEName").ToString()  != "" ? Eval("ACTIONEEName").ToString().ToUpper() : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Info?" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblInfo" runat="server" Text='<%# Eval("INFO").ToString()  != "" ? Eval("INFO") : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Image src="img/yes1.png" runat="server" ID="imgInfo" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action?" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblAction" runat="server" Text='<%# Eval("ACTION").ToString()  != "" ? Eval("ACTION") : "-"%>' CssClass="input-sm" Visible="false"></asp:Label>
                                    <asp:Image src="img/yes1.png" runat="server" ID="imgAction" Visible="false" />
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
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="35" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("RecID")%>' CommandName="Delete" Width="34"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Response Details</a>
                        </li>
                    </ul>

                    <br />

                    <asp:Table ID="Table1" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="70"></asp:TableCell>
                            <asp:TableCell Width="135" Height="10"></asp:TableCell>
                            <asp:TableCell Width="80"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label1" runat="server" Text="Date Received" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateResponse" runat="server" width="220" class="dtResponse form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label2" runat="server" Text="Out Reference No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <div class="form-group row">
                                    <p class="text-left">
                                        <asp:Label ID="Label3" runat="server" Text="[Track No]" CssClass="font-weight-bold text-muted" />
                                    </p>
                                </div>
                                <div class="form-group row">
                                    <p class="text-left">
                                        <asp:Label ID="Label4" runat="server" Text="[Ref No]" CssClass="font-weight-bold text-muted" />
                                    </p>
                                </div>
                                <div class="form-group row">
                                    <p class="text-left">
                                        <asp:Label ID="Label5" runat="server" Text="[Subject]" CssClass="font-weight-bold text-muted" />
                                    </p>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldOutTrackNo" runat="server" CssClass="form-control form-control-sm" Width="400" AppendDataBoundItems="true" OnSelectedIndexChanged="fldOutTrackNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldOutRefNo" runat="server" CssClass="form-control form-control-sm" Width="400" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldOutSubject" runat="server" CssClass="form-control form-control-sm" Width="400" TextMode="MultiLine" Rows="4" Enabled="false" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label8" runat="server" Text="Remarks" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                            </asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldActionTaken" runat="server" CssClass="form-control form-control-sm" Width="400" TextMode="MultiLine" Rows="4" Enabled="false" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <hr />

                    <asp:Table ID="Table2" runat="server" Width="100%" CssClass="table-responsive-lg">
                        <asp:TableRow>
                            <asp:TableCell Width="70"></asp:TableCell>
                            <asp:TableCell Width="135" Height="10"></asp:TableCell>
                            <asp:TableCell Width="80"></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell>
                                <p class="text-left  font-italic">
                                    <asp:Label ID="Label6" runat="server" Text="Create By" CssClass="font-weight-bold" />
                                </p>
                                <p class="text-left  font-italic">
                                    <asp:Label ID="Label7" runat="server" Text="Last Update" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell>
                                <p class="text-left  font-italic">
                                    <asp:Label ID="lblCreatedBy" runat="server" Text='None' Width="400"></asp:Label>
                                </p>
                                <p class="text-left  font-italic">
                                    <asp:Label ID="lblLastUpdate" runat="server" Text='None' Width="400"></asp:Label>
                                </p>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <br />

                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <asp:Button ID="btnTransForm" runat="server" Text="Transmittal Form" class="btn btn-secondary btn-sm border-dark center-block font-weight-bold" Width="200" ></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnUpdate_Click"></asp:Button>
                            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100"></asp:Button>
                            <asp:Button ID="btnDeleteDoc" runat="server" Text="Delete Scanned Doc" class="btn btn-secondary btn-sm border-dark center-block font-weight-bold" Width="200" OnClick="btnDeleteScanDoc_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModalAttach" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title font-weight-bold" id="myModalLabel">
                            <span class="fa fa-plus-circle"></span>
                            <asp:Label ID="Label9" runat="server" Text=' Add Attachment' Width="400"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </h5>
                    </div>
                    <div class="modal-body">
                        <asp:Table ID="Table6" runat="server" Width="100%" CssClass="input-sm">
                            <asp:TableRow>
                                <asp:TableCell Width="20"></asp:TableCell>
                                <asp:TableCell Width="135" Height="10"></asp:TableCell>
                                <asp:TableCell Width="20"></asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <p class="text-left">
                                        <asp:Label ID="Label10" runat="server" Text="Tracking No." CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                        <p class="text-left">
                                        <asp:Label ID="lblTNoAttach" runat="server" CssClass="font-weight-bold" Width="300" Enabled="false"></asp:Label>
                                        <asp:HiddenField ID="hidYear" runat="server" />
                                            </p>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label11" runat="server" Text="File Name" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="300" CssClass="form-control form-control-sm" />
                                        <asp:Label ID="lblMessage" runat="server" CssClass="form-control form-control-sm" ViewStateMode="Inherit" ForeColor="Green" Visible="false"></asp:Label>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <hr />

                        <asp:Table ID="Table8" runat="server" Width="100%" CssClass="input-sm">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3" Height="2">
                                    <p class="text-left">
                                        <span class="fa fa-info-circle"></span>
                                        <asp:Label ID="Label12" runat="server" Text=" Notes:" CssClass="font-weight-bold" />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label14" runat="server" Text="1. Click on the " />
                                        <asp:Label ID="Label13" runat="server" Text="Choose File " CssClass="font-weight-bold" />
                                        <asp:Label ID="Label15" runat="server" Text="button and select your file (maximum file size is 3MB)." />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label16" runat="server" Text="2. Click on the " />
                                        <asp:Label ID="Label17" runat="server" Text="Save " CssClass="font-weight-bold" />
                                        <asp:Label ID="Label18" runat="server" Text="button to upload the document." />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label19" runat="server" Text="3. Click on the " />
                                        <asp:Label ID="Label20" runat="server" Text="Cancel " CssClass="font-weight-bold" />
                                        <asp:Label ID="Label21" runat="server" Text="button to return to the previous screen." />
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <hr />

                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <asp:Button ID="btnAddNewAttach" runat="server" Text="Save" class="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnAddNewAttach_Click" />
                                <asp:Button ID="btnCloseAttach" runat="server" Text="Cancel" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" data-dismiss="modal" OnClick="btnCloseAttach_Click" UseSubmitBehavior="false" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModalActionee" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title font-weight-bold" id="myModalLabel1">
                            <span class="fa fa-user-circle-o"></span>
                            <asp:Label ID="Label22" runat="server" Text=' Add Actionee' Width="400"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </h5>
                    </div>
                    <div class="modal-body">
                        <asp:Table ID="Table11" runat="server" Width="100%" CssClass="input-sm">
                            <asp:TableRow>
                                <asp:TableCell Width="20"></asp:TableCell>
                                <asp:TableCell Width="135" Height="10"></asp:TableCell>
                                <asp:TableCell Width="20"></asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label23" runat="server" Text="Tracking No." CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:Label ID="lblTNoActionee" runat="server" CssClass="font-weight-bold input-group-sm" Width="300" Enabled="false"></asp:Label>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label24" runat="server" Text="Actionee" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldActionee" runat="server" CssClass="form-control form-control-sm" Width="300" EnableViewState="true"></asp:DropDownList>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label25" runat="server" Text=" Info?" CssClass="font-weight-bold fa fa-info-circle"
                                            ToolTip="For Info?, Action Required field is not required" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:RadioButton ID="chkInfo" GroupName="type" runat="server" Width="300"></asp:RadioButton>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label27" runat="server" Text="Action?" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:RadioButton ID="chkAction" GroupName="type" runat="server" Width="300" />
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label28" runat="server" Text="Action Required" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:TextBox ID="fldActionReq" runat="server" CssClass="form-control form-control-sm" Width="300" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <hr />

                        <asp:Table ID="Table12" runat="server" Width="100%" CssClass="input-sm">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3" Height="2">
                                    <p class="text-left">
                                        <span class="fa fa-info-circle"></span>
                                        <asp:Label ID="Label26" runat="server" Text=" Notes:" CssClass="font-weight-bold" />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label30" runat="server" Text="1. Click on the " />
                                        <asp:Label ID="Label29" runat="server" Text="Add " CssClass="font-weight-bold" />
                                        <asp:Label ID="Label31" runat="server" Text="button to add an actionee." />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label32" runat="server" Text="2. Email notification will be sent to the " />
                                        <asp:Label ID="Label33" runat="server" Text="Actionee " CssClass="font-weight-bold" />
                                    </p>
                                    <p class="text-left">
                                        <asp:Label ID="Label34" runat="server" Text="3. Click on the " />
                                        <asp:Label ID="Label35" runat="server" Text="Cancel " CssClass="font-weight-bold" />
                                        <asp:Label ID="Label36" runat="server" Text="button to return to the previous screen." />
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <hr />

                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <asp:Button ID="btnAddNewActionee" runat="server" Text="Save" CssClass="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnAddNewActionee_Click" />
                                <asp:Button ID="btnCloseActionee" runat="server" Text="Cancel" CssClass="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" data-dismiss="modal" OnClick="btnCloseActionee_Click" UseSubmitBehavior="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script>
            $('.dtReceive').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtDocument').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtRequired').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtResponse').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });
        </script>

        <script type="text/javascript">
            function funcOpen() {
                $('#myModalAttach').modal('toggle');
                $('#myModalAttach').modal('show');
            }

            function funcClose() {
                $('#myModalAttach').modal('hide');
            }

            function funcOpen1() {
                $('#myModalActionee').modal('toggle');
                $('#myModalActionee').modal('show');
            }

            function funcClose1() {
                $('#myModalActionee').modal('hide');
            }
        </script>
    </form>
</asp:Content>

