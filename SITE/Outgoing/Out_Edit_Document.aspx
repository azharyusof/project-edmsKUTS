<%@ Page Title="" Language="C#" MasterPageFile="~/EDMS_Masterpage.master" AutoEventWireup="true" CodeFile="Out_Edit_Document.aspx.cs" Inherits="SITE_Outgoing_Out_Edit_Document" %>

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
                <h1 class="font-weight-bold text-muted">OUTGOING</h1>
                <h3 class="font-weight-bold text-muted">EDIT DOCUMENT</h3>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <ul class="nav nav-tabs font-weight-bold" role="tablist" style="overflow: hidden; vertical-align: top;">
                        <li class="nav-item nav-link active">
                            <a href="#">Outgoing Details</a>
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
                                    <asp:Label ID="lblTrackN" runat="server" Text="Tracking No." CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <a href="http://edms.str.opusbhd.com/document/<%=Request.QueryString["ID1"]%>/<%=fldCompanyCode.Text%>/Outgoing/<%=fldYr.Text%>/<%=fldTrackNo.Text%>.pdf" target="_blank" title="Click here">
                                        <asp:Image src="../Img/icon_pdf_small.gif" runat="server" ID="img_all" Visible="false" CssClass="form-control form-control-sm" /></a>
                                    <asp:Label ID="lblTrackNo" runat="server" Text='None' CssClass="input-sm" Visible="false" />
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
                                    <asp:Label ID="lblfldDateTaken" runat="server" Text="Date Taken / Draft" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <input id="fldDateTaken" runat="server" width="220" class="dtTaken form-control form-control-sm" readonly="readonly" />
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblAddressee" runat="server" Text="Addressee" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <div class="input-group-prepend">
                                        <asp:Label ID="lblAddresseeCode" runat="server" CssClass="form-control-sm font-weight-bold" Width="100" BackColor="LightGray"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="fldAddressee" runat="server" CssClass="form-control form-control-sm" Width="400" Enabled="false"></asp:DropDownList>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="lblRefNo" runat="server" Text="Out Reference No." CssClass="font-weight-bold" />
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
                                    <asp:Label ID="Label1" runat="server" Text="Originator" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldOriginator" runat="server" CssClass="form-control form-control-sm" Width="400"></asp:TextBox>
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
                                    <input id="fldDocDate" runat="server" width="220" class="dtDocument form-control form-control-sm" readonly="readonly" />
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
                                    <asp:Label ID="Label2" runat="server" Text="Department" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldDepartment" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewDepartment" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
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
                                    <asp:Label ID="lblTypeDoc" runat="server" Text="File Index" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:DropDownList ID="fldIndex" runat="server" CssClass="form-control form-control-sm" Width="400" OnSelectedIndexChanged="fldIndex_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                </div>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldNewIndex" runat="server" CssClass="form-control form-control-sm" Width="400" Visible="false"></asp:TextBox>
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

                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <p class="text-left">
                                    <asp:Label ID="Label3" runat="server" Text="Sent To" CssClass="font-weight-bold" />
                                </p>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top"></asp:TableCell>
                            <asp:TableCell>
                                <div class="form-group row">
                                    <asp:TextBox ID="fldSentTo" CssClass="form-control form-control-sm" runat="server" Width="400"></asp:TextBox>
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
                        <asp:LinkButton ID="lbtnAddAttach" runat="server" CssClass="btn btn-default btn-sm" data-toggle="modal" data-target="#myModal1" OnClientClick="funcOpen1();" Width="150" UseSubmitBehavior="false"><span class="glyphicon glyphicon-plus"></span>&nbsp;&nbsp;Add Attachment</asp:LinkButton>
                    </p>

                    <asp:GridView ID="GridViewAttachment" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="60%" ShowHeaderWhenEmpty="true" OnRowDataBound="GridViewAttachment_RowDataBound" OnRowCommand="GridViewAttachment_RowCommand" OnRowDeleting="GridViewAttachment_RowDeleting" OnDataBound="GridViewAttachment_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Name" ItemStyle-Width="450" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://edms.str.opusbhd.com/document/" + Request.QueryString["ID1"] + "/outgoing/attachment/" + Request.QueryString["ID2"] + "/" + Eval("FILENAME") + "" %>' Target="_blank"><%# Eval("FILENAME").ToString()  != "" ? Eval("FILENAME") : "-"%></asp:HyperLink>
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
                            <a href="#">Addressee</a>
                        </li>
                    </ul>

                    <br />

                    <p>
                        <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="btn btn-default btn-sm" data-toggle="modal" data-target="#myModal" OnClientClick="funcOpen();" Width="150" UseSubmitBehavior="false"><span class="glyphicon glyphicon-plus"></span>&nbsp;&nbsp;Add Actionee</asp:LinkButton>
                    </p>

                    <asp:GridView ID="GridViewAddressee" runat="server" CssClass="table table-bordered input-sm" AutoGenerateColumns="False" Width="70%" ShowHeaderWhenEmpty="true" OnRowDataBound="GridViewAddressee_RowDataBound" OnRowCommand="GridViewAddressee_RowCommand" OnRowDeleting="GridViewAddressee_RowDeleting" OnDataBound="GridViewAddressee_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="#" ShowHeader="false" ItemStyle-Width="20" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Addressee" ItemStyle-Width="215" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("FLD_ADDRESSEE").ToString()  != "" ? Eval("FLD_ADDRESSEE") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Company" ItemStyle-Width="230" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblComp" runat="server" Text='<%# Eval("FLD_COMPANY").ToString()  != "" ? Eval("FLD_COMPANY") : "-"%>' CssClass="input-sm"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="35" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("RecID")%>' CommandName="Delete" Width="34"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

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
                            <asp:Button ID="btnCancelTrack" runat="server" Text="cancel Tracking No." class="btn btn-secondary btn-sm border-dark center-block font-weight-bold" Width="200"></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnUpdate_Click"></asp:Button>
                            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100"></asp:Button>
                            <asp:Button ID="btnDeleteDoc" runat="server" Text="Delete Scanned Doc" class="btn btn-secondary btn-sm border-dark center-block font-weight-bold" Width="200" OnClick="btnDeleteScanDoc_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title font-weight-bold" id="myModalLabel1">
                            <span class="fa fa-mail-forward"></span>
                            <asp:Label ID="Label9" runat="server" Text=' Add Addressee' Width="400"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </h5>
                    </div>
                    <div class="modal-body">
                        <asp:Table ID="Table3" runat="server" Width="100%" CssClass="input-sm">
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
                                        <asp:Label ID="lblTNo" runat="server" CssClass="font-weight-bold" Width="300" Enabled="false"></asp:Label>
                                        <asp:HiddenField ID="hidYear" runat="server" />
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label24" runat="server" Text="Addressee" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldAddressee1" runat="server" CssClass="form-control form-control-sm" Width="300"
                                            OnSelectedIndexChanged="fldAddressee1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group row">
                                        <asp:TextBox ID="fldNewAddressee" runat="server" CssClass="form-control form-control-sm" Width="300" Visible="false"></asp:TextBox>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell Height="25">
                                    <p class="text-left">
                                        <asp:Label ID="Label4" runat="server" Text="Company" CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group row">
                                        <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control form-control-sm" Width="300" OnSelectedIndexChanged="fldCompany_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                                    </div>
                                    <div class="form-group row">
                                        <asp:TextBox ID="fldNewCompany" runat="server" CssClass="form-control form-control-sm" Width="300"></asp:TextBox>
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
                                <asp:Button ID="btnAddNew" runat="server" Text="Save" CssClass="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnAddNew_Click" />
                                <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" data-dismiss="modal" OnClientClick="funcClose();" OnClick="btnClose_Click" UseSubmitBehavior="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title font-weight-bold" id="myModalLabel">
                            <span class="fa fa-plus-square"></span>
                            <asp:Label ID="Label5" runat="server" Text=' Add Attachment' Width="400"></asp:Label>
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
                                        <asp:Label ID="Label8" runat="server" Text="Tracking No." CssClass="font-weight-bold" />
                                    </p>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <p class="text-left">
                                        <asp:Label ID="lblTNo1" runat="server" CssClass="font-weight-bold" Width="300" Enabled="false"></asp:Label>
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
                                <asp:Button ID="btnAddNewAttachment" runat="server" Text="Save" CssClass="btn btn-primary btn-sm border-dark center-block font-weight-bold" Width="100" OnClick="btnAddNewAttachment_Click" />
                                <asp:Button ID="btnClose2" runat="server" Text="Cancel" CssClass="btn btn-success btn-sm border-dark center-block font-weight-bold" Width="100" data-dismiss="modal" OnClientClick="funcClose1();" UseSubmitBehavior="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script>
            $('.dtTaken').datepicker({
                uiLibrary: 'bootstrap4', header: true, format: 'dd/mm/yyyy'
            });

            $('.dtDocument').datepicker({
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

