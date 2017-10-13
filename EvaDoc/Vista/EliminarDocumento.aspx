<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="EliminarDocumento.aspx.cs" Inherits="EvaDoc.Vista.EliminarDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Alerta</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row" id="arleta" runat="server">
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-right">
                           <a href="VerDocumento.aspx" class="btn btn-warning"><i class="material-icons">undo</i>Volver</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
