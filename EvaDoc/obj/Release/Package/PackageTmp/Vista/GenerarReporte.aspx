<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="GenerarReporte.aspx.cs" Inherits="EvaDoc.Vista.GenerarReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Generar Reporte</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Button ID="ButtonGenerar" CssClass="btn btn-warning" OnClick="ButtonGenerar_Click" runat="server" Text="Generar Reporte" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
