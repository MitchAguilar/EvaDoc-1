<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleEvaluar.aspx.cs" Inherits="EvaDoc.Vista.DetalleEvaluar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" action="./DocumentoCalificar.aspx" runat="server">
        <br />
        <div class="row">
            <div class="col-md-12 text-center">
                <h3 id="titulo" runat="server"></h3>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                Autor 1: <label id="autor1" runat="server"></label>
            </div>
            <div class="col-md-6">
                Autor 2: <label id="autor2" runat="server"> Ninguno</label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                <label>Descargar el documento</label>
                <a class="btn btn-success" id="descarga" runat="server"><i class="material-icons">file_download</i> Descargar</a>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <table class="table">
                        <thead class="text-danger">
                            <tr>
                                <th>ID</th>
                                <th>CRITERIO</th>
                                <th>Justificación</th>
                                <th style="width:30px">CALIFICACIÓN</th>
                            </tr>
                        </thead>
                        <tbody id="TB" runat="server">

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <hr />
        <div class="row text-center" id="boton" runat="server">
        </div>
    </form>
</body>
</html>
