<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EvaDoc.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar</title>
    <!-- Bootstrap core CSS     -->
    <link href="Estilo/assets/css/bootstrap.min.css" rel="stylesheet" />
    <!--  Material Dashboard CSS    -->
    <link href="Estilo/assets/css/material-dashboard.css?v=1.2.0" rel="stylesheet" />
    <!--  CSS for Demo Purpose, don't include it in your project     -->
    <link href="Estilo/assets/css/demo.css" rel="stylesheet" />
    <!--     Fonts and icons     -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,700,300|Material+Icons' rel='stylesheet' type='text/css' />
    <script>
        function nobackbutton() {
            window.location.hash = "no-back-button";
            window.location.hash = "Again-No-back-button" //chrome
            window.onhashchange = function () { window.location.hash = "no-back-button"; }
        }
    </script>
</head>
<body onload="nobackbutton()">
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <div class="content">
                <div class="container-fluid">
                    <div class="row">
                        <br />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="card">
                                <div class="card-header" data-background-color="blue">
                                    <h4 class="title text-center">Iniciar Sesión</h4>
                                </div>
                                <div class="card-content">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-2">
                                            <div class="form-group label-floating">
                                                <label class="control-label">Usuario</label>
                                                <asp:TextBox ID="TextBoxUsurio" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-2">
                                            <div class="form-group label-floating">
                                                <label class="control-label">Contraseña</label>
                                                <asp:TextBox ID="TextBoxPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
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
                                    <br />
                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1">
                                            <a href="PersonaRegistrar.aspx" class="text-success"><i class="material-icons">person_add</i> Registrar Usuario</a>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row text-center">
                                        <asp:Button ID="ButtonIngresar" CssClass="btn btn-info" OnClick="ButtonIngresar_Click" runat="server" Text="Ingresar" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <footer class="footer">
                <div class="container-fluid">
                    <p class="copyright pull-right">
                        &copy;
                       
                        <script>
                            document.write(new Date().getFullYear())
                        </script>
                        <a href="http://191.102.85.226/">Giecom</a>
                    </p>
                </div>
            </footer>
        </div>
    </form>
    <!--   Core JS Files   -->
    <script src="Estilo/assets/js/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="Estilo/assets/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="Estilo/assets/js/material.min.js" type="text/javascript"></script>
    <!--  Charts Plugin -->
    <script src="Estilo/assets/js/chartist.min.js"></script>
    <!--  Dynamic Elements plugin -->
    <script src="Estilo/assets/js/arrive.min.js"></script>
    <!--  PerfectScrollbar Library -->
    <script src="Estilo/assets/js/perfect-scrollbar.jquery.min.js"></script>
    <!--  Notifications Plugin    -->
    <script src="Estilo/assets/js/bootstrap-notify.js"></script>
    <!--  Google Maps Plugin    -->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
    <!-- Material Dashboard javascript methods -->
    <script src="Estilo/assets/js/material-dashboard.js?v=1.2.0"></script>
    <!-- Material Dashboard DEMO methods, don't include it in your project! -->
    <script src="Estilo/assets/js/demo.js"></script>
</body>
</html>
