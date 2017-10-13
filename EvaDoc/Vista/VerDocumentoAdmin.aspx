<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="VerDocumentoAdmin.aspx.cs" Inherits="EvaDoc.Vista.VerDocumentoAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Documentos Subidos</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <h3>Documento Subido</h3>
                        </div>
                        <div class="col-md-12">
                             <asp:GridView AutoGenerateColumns="False" ID="GridView1" CssClass="table table-bordered"  runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:BoundField DataField="TITULO" HeaderText="Titulo" />
                                    <asp:HyperLinkField Text="Abrir Documento" DataNavigateUrlFields="URL" DataNavigateUrlFormatString="~/Documento/{0}" ControlStyle-CssClass="btn btn-success" HeaderText="Documento"></asp:HyperLinkField>
                                    <asp:BoundField DataField="AUTOR_1" HeaderText="Autor 1" />
                                    <asp:BoundField DataField="AUTOR_2" HeaderText="Autor 2" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <h3>Documento Subido como resultado de Corrección</h3>
                        </div>
                        <div class="col-md-12">
                             <asp:GridView AutoGenerateColumns="False" ID="GridView2" CssClass="table table-bordered"  runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:BoundField DataField="TITULO" HeaderText="Titulo" />
                                    <asp:HyperLinkField Text="Abrir Documento" DataNavigateUrlFields="URL" DataNavigateUrlFormatString="~/Documento/{0}" ControlStyle-CssClass="btn btn-success" HeaderText="Documento"></asp:HyperLinkField>
                                    <asp:BoundField DataField="EVALUADOR" HeaderText="Evaluador" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
