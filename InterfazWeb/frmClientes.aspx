<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmClientes.aspx.cs" Inherits="InterfazWeb.frmClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="card-header text-center">
                        <h1>Mantenimiento de Clientes</h1>
                    </div>
                    <%if (Session["_mensaje"] != null)
                        { %>

                    <div class="alert alert-warning alert-dismissible fade show" role="alert">
                        <%=Session["_mensaje"] %>
                        <button class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                    <%
                            //Session["_mensaje"] = null;
                        }%>
                    <br />
                    <div class="mb-3">
                        <asp:Label ID="lblID" runat="server" class="form-label" Text="Label">Código</asp:Label>
                        <asp:TextBox ID="txtID" ReadOnly="true" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label2" runat="server" class="form-label" Text="Label">Nombre <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre es un campo requerido" ControlToValidate="TxtNombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator></asp:Label>
                        <asp:TextBox ID="TxtNombre" class="form-control" runat="server" ControlToValidate="TxtNombre" AutoCompleteType="Disabled"></asp:TextBox>
                        
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label3" runat="server" class="form-label" Text="Label">Teléfono</asp:Label>
                        <asp:TextBox ID="TxtTelefono" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label4" runat="server" class="form-label" Text="Label">Dirección</asp:Label>
                        <asp:TextBox ID="TxtDireccion" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" ValidationGroup="1" />
                    <asp:Button ID="btnAtras" runat="server" Text="Cancelar" class="btn btn-secondary" OnClick="btnAtras_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
                </div>
            </div>
        </div>

    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script type="text/javascript">
        
    </script>
</body>
</html>
