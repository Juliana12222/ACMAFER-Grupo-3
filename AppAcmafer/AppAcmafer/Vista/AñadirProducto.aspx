<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Añadir Producto</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Estilos personalizados -->
    <style>
        body {
            background: #2b2b2b url('https://i.imgur.com/1ZQZ1T8.jpg') center/cover no-repeat fixed;
            font-family: 'Segoe UI', sans-serif;
            color: #ddd;
        }

        .card {
            background: rgba(30, 30, 30, 0.96);
            border: 1px solid #555;
            border-radius: 10px;
        }

        h3 {
            color: #e0e0e0;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        label {
            font-weight: 600;
            color: #cfcfcf;
        }

        .form-control {
            background-color: #3b3b3b;
            border: 1px solid #666;
            color: #fff;
        }
        .form-control:focus {
            border-color: #ff9800;
            box-shadow: 0 0 5px #ff9800;
        }

        .btn-success {
            background-color: #ff9800;
            border-color: #ff9800;
            font-weight: bold;
        }
        .btn-success:hover {
            background-color: #e68a00;
            border-color: #e68a00;
        }

        .shadow {
            box-shadow: 0 0 25px rgba(0,0,0,0.7) !important;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" class="container" style="max-width:650px;margin-top:50px;">

        <div class="card shadow p-4">
            <h3 class="text-center mb-4">
                <span style="color:#ff9800;">&#9889;</span> Añadir Nuevo Producto
            </h3>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

            <div class="form-group">
                <label>Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Estado</label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem>Disponible</asp:ListItem>
                    <asp:ListItem>Agotado</asp:ListItem>
                    <asp:ListItem>Descontinuado</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto"
                CssClass="btn btn-success btn-block" OnClick="btnGuardar_Click" />
        </div>

    </form>
</body>
</html>