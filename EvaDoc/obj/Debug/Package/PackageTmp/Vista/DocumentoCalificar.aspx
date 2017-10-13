<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="DocumentoCalificar.aspx.cs" Inherits="EvaDoc.Vista.DocumentoCalificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header" data-background-color="red">
                    <h2 class="title text-center">Calificar Documentos</h2>
                </div>
                <div class="card-content">
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card card-nav-tabs">
                                <div class="card-header" data-background-color="purple">
                                    <div class="nav-tabs-navigation">
                                        <div class="nav-tabs-wrapper">
                                            <ul class="nav nav-tabs" data-tabs="tabs" id="menu" runat="server"></ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-content" id="criterios">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
