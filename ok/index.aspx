<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ok.index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Conversor de Divisas</title>
    <!-- Asegúrate de tener Bootstrap en tu proyecto -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Conversor de Divisas</h1>

            <!-- Botón que abre el modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                Abrir Conversor
            </button>

            <!-- Modal -->
            <div class="modal" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Conversor de Divisas</h4>
                            <button type="button" class="close" data-dismiss="modal">×</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <label for="ddlMonedaOrigen">Moneda de Origen:</label>
                            <asp:DropDownList ID="ddlMonedaOrigen" runat="server"></asp:DropDownList>

                            <label for="ddlMonedaDestino">Moneda de Destino:</label>
                            <asp:DropDownList ID="ddlMonedaDestino" runat="server"></asp:DropDownList>

                            <label for="txtCantidad">Cantidad a Convertir:</label>
                            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>

                            <asp:Button ID="btnConvertir" runat="server" Text="Calcular" OnClick="btnConvertir_Click" />

                            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Asegúrate de tener jQuery y Bootstrap JS en tu proyecto -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
