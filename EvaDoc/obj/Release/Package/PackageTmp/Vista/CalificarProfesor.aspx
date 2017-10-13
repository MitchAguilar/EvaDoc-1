<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="CalificarProfesor.aspx.cs" Inherits="EvaDoc.Vista.CalificarProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Calificar Documento</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView AutoGenerateColumns="False" ID="GridView1" CssClass="table table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Calificar" />
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="TITULO" HeaderText="TITULO" />
                                    <asp:HyperLinkField Text="Abrir Documento" DataNavigateUrlFields="URL" DataNavigateUrlFormatString="~/Documento/{0}" ControlStyle-CssClass="btn btn-success" HeaderText="URL"></asp:HyperLinkField>
                                    <asp:BoundField DataField="AUTOR_1" HeaderText="AUTOR 1" />
                                    <asp:BoundField DataField="AUTOR_2" HeaderText="AUTOR 2" />
                                    <asp:BoundField DataField="NOTA" HeaderText="NOTA" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
