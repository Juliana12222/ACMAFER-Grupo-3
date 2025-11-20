<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buscar Producto</title>

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
            background: rgba(30, 30, 30, 0.95);
            border: 1px solid #555;
            border-radius: 10px;
        }

        h3 {
            color: #ff9800;
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

        .btn-primary {
            background-color: #ff9800;
            border-color: #ff9800;
            font-weight: bold;
        }
        .btn-primary:hover {
            background-color: #e68a00;
            border-color: #e68a00;
        }

        /* Diseño tabla industrial */
        .table {
            background: rgba(20, 20, 20, 0.95);
            color: #eee;
        }
        .table thead th {
            background-color: #444;
            color: #ff9800;
            font-weight: bold;
            text-transform: uppercase;
            border-bottom: 2px solid #ff9800;
        }
        .table-striped tbody tr:nth-of-type(odd) {
            background-color: #2f2f2f;
        }
        .table-striped tbody tr:hover {
            background-color: #3c3c3c;
        }
        .table-bordered td, .table-bordered th {
            border: 1px solid #555 !important;
        }

        .shadow {
            box-shadow: 0 0 25px rgba(0,0,0,0.7) !important;
        }
    </style>

</head>

<body>
    <form runat="server" class="container" style="margin-top:40px; max-width:750px;">

        <div class="card shadow p-4">
            <h3 class="text-center mb-4">
                🔍 Buscar Producto
            </h3>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

            <div class="form-group">
                <label>Buscar por código o nombre:</label>
                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-block"
                Text="Buscar" OnClick="btnBuscar_Click" />
        </div>

        <div class="mt-4">
            <asp:GridView ID="gvResultados" runat="server"
                CssClass="table table-bordered table-striped"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
