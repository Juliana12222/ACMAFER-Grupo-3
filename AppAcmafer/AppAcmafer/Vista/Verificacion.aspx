<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verificacion.aspx.cs" Inherits="AppAcmafer.Vista.Verificacion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verificar Código - ACMAFER</title>

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
            text-align: center;
            letter-spacing: 1px;
        }

        label {
            font-weight: 600;
            color: #e0e0e0;
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

        .btn-success {
            background-color: #ff9800;
            border-color: #ff9800;
            font-weight: bold;
        }
        .btn-success:hover {
            background-color: #e68700;
            border-color: #e68700;
        }

        .btn-link {
            color: #ff9800;
            font-weight: 500;
        }
        .btn-link:hover {
            color: #ffa733;
            text-decoration: underline;
        }
    </style>
</head>

<body>
    <form runat="server" class="container" style="max-width:520px;margin-top:50px;">
        <div class="card p-4">

            <h4 class="mb-3">Verificación de Correo</h4>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

            <div class="form-group mt-3">
                <label>Código (6 dígitos)</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" MaxLength="6" />
            </div>

            <div class="form-group mt-4">
                <asp:Button ID="btnVerificar" runat="server" CssClass="btn btn-success" 
                            Text="Verificar" OnClick="btnVerificar_Click" />

                <asp:Button ID="btnReenviar" runat="server" CssClass="btn btn-link"
                            Text="Reenviar código" OnClick="btnReenviar_Click" />
            </div>

        </div>
    </form>
</body>
</html>
