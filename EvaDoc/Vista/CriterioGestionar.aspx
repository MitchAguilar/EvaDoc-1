<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="CriterioGestionar.aspx.cs" Inherits="EvaDoc.Vista.CriterioGestionar" %>

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
                        <div class="col-md-6">
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
                                <asp:Button ID="ButtonRegistrar" CssClass="btn btn-success" OnClick="ButtonRegistrar_Click" runat="server" Text="Registrar" />
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
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" CssClass="table table-bordered" AutoGenerateColumns="False" runat="server">
                                <HeaderStyle CssClass="text-danger" />
                                <Columns>
                                    <asp:HyperLinkField Text="Selecionar" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Vista/CriterioModificar.aspx?id={0}"  ControlStyle-CssClass="text-primary" HeaderText="Seleccionar"></asp:HyperLinkField>
                                    <asp:BoundField DataField="CRITERIO" HeaderText="Criterio" />
                                    <asp:BoundField DataField="PORCENTAJE" HeaderText="Porcentaje" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
