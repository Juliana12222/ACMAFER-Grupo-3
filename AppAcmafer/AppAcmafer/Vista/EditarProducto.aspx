<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="AppAcmafer.Vista.EditarProducto" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edición de Producto (Encargado)</title>
    <style>
        .campo { margin-bottom: 10px; }
        .etiqueta { display: inline-block; width: 120px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2> Edición de Producto</h2>
            
            <div class="campo">
                <asp:Label ID="Label1" runat="server" Text="ID del Producto:" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtIdProducto" runat="server" Enabled="True"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
            
            <hr />

            <div class="campo">
                <asp:Label ID="Label_ID" runat="server" Text="ID (No editable):" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtIdEncontrado" runat="server" Enabled="False"></asp:TextBox>
            </div>
            
            <div class="campo">
                <asp:Label ID="Label2" runat="server" Text="Nombre:" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            
            <div class="campo">
                <asp:Label ID="Label3" runat="server" Text="Descripción:" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            
            <div class="campo">
                <asp:Label ID="Label4" runat="server" Text="Precio:" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </div>
            
            <div class="campo">
                <asp:Label ID="Label5" runat="server" Text="Stock Actual:" CssClass="etiqueta"></asp:Label>
                <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Enabled="False" />
            
            <hr />
            
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Blue"></asp:Label>
            
        </div>
    </form>
</body>
</html>
