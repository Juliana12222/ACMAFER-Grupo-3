<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="AppAcmafer.Vista.ListarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Usuarios</title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h2>Listado de Usuarios Registrados</h2>
            <hr />

            <asp:Repeater ID="rptUsuarios" runat="server">
                
                <HeaderTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Documento</th>
                                <th>Nombre Completo</th>
                                <th>Correo</th>
                                <th>Rol</th>
                                <th>Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdUsuario") %></td>
                        <td><%# Eval("Documento") %></td>
                        <td><%# Eval("Nombre") %> <%# Eval("Apellido") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Rol") %></td>
                        <td><%# Eval("Estado") %></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            
        </div>
    </form>
</body>
</html>