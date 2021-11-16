<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFacturar.aspx.cs" Inherits="InterfazWeb.frmFacturar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title>Facturar Reserva</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card-header">
                <h1>Detalle de reserva</h1>
            </div>
            <div class="card mt-3" style="width: 100%;">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Literal ID="ltlReserva" runat="server"></asp:Literal>
                </h5>
                <h6 class="card-subtitle mb-2 text-muted">
                    <asp:Literal ID="ltlCliente" runat="server"></asp:Literal>
                </h6>
                <p class="card-text">Fecha de Ingreso: <asp:Literal ID="ltlingreso" runat="server"></asp:Literal></p>
                <p class="card-text">Fecha de Salida: <asp:Literal ID="ltlsalida" runat="server"></asp:Literal></p>
                <p class="card-text"># de Noches: <asp:Literal ID="ltlnoches" runat="server"></asp:Literal></p>
                <p class="card-text"># de huéspedes: <asp:Literal ID="ltlpersonas" runat="server"></asp:Literal></p>
                <p class="card-text">Tipo de habitación: <asp:Literal ID="ltltipo" runat="server"></asp:Literal></p>
                <p class="card-text">Precio por noche: $ <asp:Literal ID="ltlprecio" runat="server"></asp:Literal></p>
                <p class="card-text">Subtotal: $ <asp:Literal ID="ltlSubtotal" runat="server"></asp:Literal></p>
                <p class="card-text">Impuesto ICT: $ <asp:Literal ID="ltlICT" runat="server"></asp:Literal></p>
                <p class="card-text">I.V.A: $ <asp:Literal ID="ltliva" runat="server"></asp:Literal></p>
                <h6 class="card-text">Total: $ <asp:Literal ID="ltlTotal" runat="server"></asp:Literal></h6>
                <br />
                <asp:LinkButton ID="btnFacturar" runat="server" CssClass="btn btn-primary" OnClick="btnFacturar_Click">Facturar</asp:LinkButton>
                <asp:LinkButton ID="btnAtrás" runat="server" CssClass="btn btn-secondary" OnClick="btnAtrás_Click">Regresar a la lista</asp:LinkButton>
            </div>
        </div>
        </div>
        
    </form>
</body>
</html>
