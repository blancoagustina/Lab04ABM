<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaUsuarios.aspx.cs" Inherits="ListaUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdUsuarios" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsUsuarios" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario" />
                    <asp:BoundField DataField="FechaNac" HeaderText="FechaNac" SortExpression="FechaNac" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ListaUsuarios.aspx?id={0}" Text="Editar" />
                </Columns>
            </asp:GridView>
            <table style="width:100%;">
                <tr>
                    <td style="text-align: right">&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lblAccion" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo de Documento"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblTipoDoc" runat="server">
                            <asp:ListItem>DNI</asp:ListItem>
                            <asp:ListItem>LC / LE</asp:ListItem>
                            <asp:ListItem>Cédula Identidad</asp:ListItem>
                            <asp:ListItem>Pasaporte</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblNroDoc" runat="server" Text="Nro de Documento"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroDoc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de nacimiento"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpFechaNacDia" runat="server">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpFechaNacMes" runat="server">
                            <asp:ListItem>Enero</asp:ListItem>
                            <asp:ListItem>Febrero</asp:ListItem>
                            <asp:ListItem>Marzo</asp:ListItem>
                            <asp:ListItem>Abril</asp:ListItem>
                            <asp:ListItem>Mayo</asp:ListItem>
                            <asp:ListItem>Junio</asp:ListItem>
                            <asp:ListItem>Julio</asp:ListItem>
                            <asp:ListItem>Agosto</asp:ListItem>
                            <asp:ListItem>Septiembre</asp:ListItem>
                            <asp:ListItem>Octubre</asp:ListItem>
                            <asp:ListItem>Noviembre</asp:ListItem>
                            <asp:ListItem>Diciembre</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtFechaNacAnio" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
                    </td>
                    <td>
                        <textarea id="txaDireccion" cols="20" name="S1" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblCelular" runat="server" Text="Celular"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblConfirmarClave" runat="server" Text="Confirmar clave"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:ObjectDataSource ID="odsUsuarios" runat="server" DataObjectTypeName="Negocio.Usuario" DeleteMethod="BorrarUsuario" SelectMethod="GetAll" TypeName="Negocio.ManagerUsuarios"></asp:ObjectDataSource>
    </form>
</body>
</html>
