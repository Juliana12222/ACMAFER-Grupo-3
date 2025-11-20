<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" 
    Inherits="AppAcmafer.Vista.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ACMAFER - Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />

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

        h3 {
            color: #ff9800;
            font-weight: 700;
            letter-spacing: 1px;
            text-transform: uppercase;
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
            box-shadow: 0 0 5px #ff9800;
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
    <form id="form1" runat="server">
        <div class="container" style="max-width:420px; margin-top:70px;">
            <div class="card p-4">
                <div class="card-body">
                    <h3 class="mb-4 text-center">ACMAFER | Ingreso</h3>

                    <asp:ValidationSummary ID="vs" runat="server" CssClass="text-danger" />

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Correo</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Correo es obligatorio"
                            CssClass="text-danger"
                            Display="Dynamic" />
                    </div>

                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvPass" runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="Contraseña es obligatoria"
                            CssClass="text-danger"
                            Display="Dynamic" />
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary"
                            Text="Ingresar" OnClick="btnLogin_Click" />
                    </div>

                    <div class="mt-3 text-center">
                        <a href="Recover.aspx">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
