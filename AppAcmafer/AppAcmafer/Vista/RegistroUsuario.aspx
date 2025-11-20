<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro - ACMAFER</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background: #232323 url('https://i.imgur.com/1ZQZ1T8.jpg') center/cover no-repeat fixed;
            font-family: 'Segoe UI', sans-serif;
            color: #ddd;
        }

        .card {
            background: rgba(25, 25, 25, 0.95);
            border: 1px solid #555;
            border-radius: 12px;
            box-shadow: 0 0 25px rgba(0, 0, 0, .8);
        }

        h4 {
            color: #ff9800;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        label {
            color: #e0e0e0;
            font-weight: 600;
        }

        .form-control {
            background-color: #3b3b3b;
            border: 1px solid #666;
            color: #fff;
        }
        .form-control:focus {
            border-color: #ff9800;
            box-shadow: 0 0 6px #ff9800;
            background-color: #444;
        }

        .btn-primary {
            background-color: #ff9800;
            border-color: #ff9800;
            font-weight: bold;
        }
        .btn-primary:hover {
            background-color: #e68700;
            border-color: #e68700;
        }

        a {
            color: #ff9800;
            font-weight: 500;
        }
        a:hover {
            color: #ffa733;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" class="container" style="max-width:600px;margin-top:40px;">
        <div class="card p-4">

            <h4 class="mb-3 text-center">Registro de Usuario</h4>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>

            <div class="form-group">
                <label>Documento</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label>Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
            </div>

            <div class="form-group">
                <label>Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" />
            </div>

            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary btn-block" 
                        Text="Registrar" OnClick="btnRegistrar_Click" />

            <div class="mt-3 text-center">
                ¿Ya tienes cuenta? <a href="Login.aspx">Inicia sesión</a>
            </div>

        </div>
    </form>
</body>
</html>
