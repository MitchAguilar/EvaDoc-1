<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="EvaluadorAsignar.aspx.cs" Inherits="EvaDoc.Vista.EvaluadorAsignar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Asignar Evaluador</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label">Seleccionar Documentos</label>
                            <asp:DropDownList ID="DropDownDocumento" CssClass="form-control select2" OnSelectedIndexChanged="DropDownDocumento_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-10">
                            <label class="control-label">Seleccionar Evaluador</label>
                            <asp:DropDownList ID="DropDownListEvaluador" CssClass="form-control select2" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:Button ID="ButtonAgregar" CssClass="btn btn-success" OnClick="ButtonAgregar_Click" runat="server" Text="Agregar" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <asp:Panel ID="Alerta" Visible="false" runat="server" CssClass="alert alert-danger">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                <asp:Label ID="Alert" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" CssClass="table table-bordered" Visible="true" runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Titulo" />
                                    <asp:HyperLinkField Text="Eliminar"  DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Vista/EliminarEvaluador.aspx?id={0}" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar"></asp:HyperLinkField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
