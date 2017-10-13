<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="CriterioModificar.aspx.cs" Inherits="EvaDoc.Vista.CriterioModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Gestionar Criterio</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group label-floating">
                                <label class="control-label">ID</label>
                                <asp:TextBox ID="TextBoxId" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group label-floating">
                                <label class="control-label">Ingresar Criterio</label>
                                <asp:TextBox ID="TextBoxCriterio" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-3">
                            <div class="form-group label-floating">
                                <label class="control-label">Ingresar Porcentaje</label>
                                <asp:TextBox ID="TextBoxPorcentaje" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group label-floating">
                                <asp:Button ID="ButtonModificar" CssClass="btn btn-success" OnClick="ButtonRegistrar_Click"  runat="server" Text="Modificar" />
                            </div>
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
                     <div class="row">
                        <div class="col-md-12">
                            <a href="CriterioGestionar.aspx" class="btn btn-danger"><i class="material-icons">keyboard_backspace</i> Volver</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
