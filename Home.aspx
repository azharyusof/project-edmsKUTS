<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="project-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <hgroup>
                <h1 class="font-weight-bold text-muted">PROJECT</h1>
            </hgroup>
        </div>

        <div class="container card-deck mb-3 text-center">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="card mb-4 shadow-sm">
                        <div class="card-header">
                            <h4 class="my-0 font-weight-bold">
                                <asp:Label ID="lblProjectCode" runat="server" Text='<%#Eval("PROJECT_CODE")%>' /></h4>
                        </div>
                        <div class="card-body">
                            <h1 class="card-title"><small class="text-muted font-weight-bold">
                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("DESCRIPTION")%>' /></small></h1>
                            <ul class="list-unstyled mt-3 mb-4">
                                <li>
                                    <p class="font-weight-bold">Project Manager</p>
                                    <p class="font-weight-light">
                                        <asp:Label ID="lblPM" runat="server" Text='<%#Eval("PROJECT_MANAGER")%>' />
                                    </p>
                                </li>
                            </ul>
                            <asp:Button class="btn btn-lg btn-block btn-primary" OnClick="btnGoProject_Click" runat="server" ID="btnGoProject" Text="Go to Project" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <footer class="pt-4 my-md-5 pt-md-5 border-top">
            <div class="row">
                <div class="col-12 col-md">
                    <small class="d-block mb-3 text-muted">© 2021 Copyright - UEM Edgenta Bhd</small>
                </div>
            </div>
        </footer>
    </form>
</asp:Content>

