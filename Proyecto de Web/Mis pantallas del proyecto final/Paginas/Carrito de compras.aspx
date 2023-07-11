<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito de compras.aspx.cs" Inherits="Mis_pantallas_del_proyecto_final.Paginas.Carrito_de_compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="font-size: 0px; background-color: #2E86AB; background-image: url('https://localhost:44353/Paginas/Imagenes/Carrito de compras.png'); width: 1920px; height: 1080px;">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" BackColor="#FAFDF6" BorderColor="#FAFDF6" BorderStyle="None" Font-Bold="True" Font-Names="Roboto Black" Font-Size="Large" style="margin-left: 1599px; margin-top: 103px" Text="Cuenta" />
            <asp:Button ID="Button3" runat="server" BackColor="#FAFDF6" BorderColor="#FAFDF6" BorderStyle="None" Font-Bold="True" Font-Names="Roboto Black" Font-Size="Large" Height="25px" style="margin-left: 120px; margin-top: 18px" Text="Carrito" />
        </div>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" BackColor="#FFBA08" BorderColor="#FFBA08" BorderStyle="None" Font-Names="Roboto Black" Font-Size="XX-Large" style="margin-left: 1489px; margin-top: 555px" Text="Comprar" OnClick="Button2_Click1" />
    </form>
</body>
</html>
