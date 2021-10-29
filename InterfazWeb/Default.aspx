<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InterfazWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Buscar Clientes</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row ">
                <div class="col">
                    <div class="card-header text-center">
                        <h1>Búsqueda de clientes</h1>
                    </div>
                     <%--g-3 align-items-center mt-3--%>
                    <div class="row mt-3">
                        <div class="col-auto">
                            <asp:Label ID="Label1" runat="server" Text="Label" class="col-form-label">Nombre</asp:Label>
                        </div>
                        <div class="col-auto">
                            <asp:TextBox ID="txtnombre" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnAgregar" runat="server" class="btn btn-secondary" Text="Agregar Nuevo" OnClick="btnAgregar_Click" />
                        </div>
                        
                    </div>
                    <br />
                    <%if (Session["_mensaje"] != null)
                        { %>
                    
                    <div class="alert alert-warning alert-dismissible fade show" role="alert">
                        <%=Session["_mensaje"] %>
                        <button class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                    <%
                            Session["_mensaje"] = null;
                        }%>
                    <br />
                    <asp:GridView ID="grdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdLista_PageIndexChanging" Width="100%" PagerSettings-PageButtonCount="4">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_CLIENTE").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command" ToolTip="Modificar"><i class="bi bi-pencil-fill"></i></asp:LinkButton>
                       
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBorrar" runat="server" CommandArgument='<%# Eval("ID_CLIENTE").ToString() %>' CommandName="Eliminar" OnCommand="lnkBorrar_Command" ToolTip="Eliminar"><i class="bi bi-person-x-fill"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<PagerSettings PageButtonCount="4"></PagerSettings>

                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>

            </div>
            
            <div class="form-g">
               
                
                
                
            </div>
            
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script type="text/javascript">
        
    </script>
</body>
</html>
