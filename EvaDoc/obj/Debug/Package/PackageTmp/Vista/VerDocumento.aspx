<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="VerDocumento.aspx.cs" Inherits="EvaDoc.Vista.VerDocumento" %>
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
                            <h3>Documento Subido A calificar</h3>
                        </div>
                        <div class="col-md-12">
                             <asp:GridView AutoGenerateColumns="False" ID="GridView1" CssClass="table table-bordered" runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:BoundField DataField="DOC_TITULO" HeaderText="TITULO" />
                                    <asp:HyperLinkField Text="Abrir Documento" DataNavigateUrlFields="DOC_URL" DataNavigateUrlFormatString="~/Documento/{0}"  ControlStyle-CssClass="btn btn-success" HeaderText="URL"></asp:HyperLinkField>
                                    <asp:HyperLinkField Text="Eliminar" DataNavigateUrlFields="IDDOCUMENTO" DataNavigateUrlFormatString="~/Vista/EliminarDocumento.aspx?id={0}"  ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar"></asp:HyperLinkField>
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
                                    <asp:BoundField DataField="TITULO" HeaderText="TITULO" />
                                    <asp:HyperLinkField Text="Abrir Documento" DataNavigateUrlFields="RES_URL" DataNavigateUrlFormatString="~/Documento/{0}" ControlStyle-CssClass="btn btn-success" HeaderText="URL"></asp:HyperLinkField>
                                    <asp:HyperLinkField Text="Eliminar"  DataNavigateUrlFields="IDRESULTADO" DataNavigateUrlFormatString="~/Vista/EliminarRevision.aspx?id={0}" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar"></asp:HyperLinkField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
