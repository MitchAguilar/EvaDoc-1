<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="DarNota.aspx.cs" Inherits="EvaDoc.Vista.DarNota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Ingresar Nota</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <label class="control-label">Documento</label>
                            <asp:TextBox ID="TextBoxId" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label class="control-label">Titulo</label>
                            <asp:TextBox ID="TextBoxTitulo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="control-label">Ingresar Nota</label>
                            <asp:TextBox ID="TextBoxNota"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="ButtonActualizar" CssClass="btn btn-warning" OnClick="ButtonActualizar_Click" runat="server" Text="Actualizar" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <asp:Panel ID="Alerta" Visible="false" runat="server" CssClass="alert alert-danger">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                <asp:Label ID="Alert" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
