<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReserva.aspx.cs" Inherits="InterfazWeb.frmReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reservaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        function AbrirModal() {
            $("#btnbuscarCliente").click();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="card-header text-center">
                        <h1>Reservaciones</h1>
                    </div>

                    <%if (Session["_mensaje"] != null)
                        { %>

                    <div class="alert alert-warning alert-dismissible fade show mt-3" role="alert">
                        <%=Session["_mensaje"] %>
                        <button class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                    <%
                            //Session["_mensaje"] = null;
                        }%>
                    
                    <div class="row mt-3">
                        <div class="col-2 mb-3">
                            <asp:Label ID="lblNumReserva" runat="server" class="form-label" Text="Label"># Reserva</asp:Label>
                            <asp:TextBox ID="txtnumreserva" ReadOnly="true" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                        <div class="col-2 mb-3">
                            <asp:Label ID="Label6" runat="server" class="form-label" Text="Label">Fecha</asp:Label>
                            <asp:TextBox ID="txtfechaActual" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-8">
                            <asp:Label ID="Label3" runat="server" class="form-label" Text="Label">Cliente
                                <asp:RequiredFieldValidator ID="rfvCliente" runat="server"
                                ErrorMessage="Debe seleccionar un cliente"
                                ControlToValidate="txtcliente" Text="*" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtidseleccionado" ReadOnly="true" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtcliente" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                <input id="btnbuscarCliente" type="button" value="Buscar Cliente" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#clienteModal"/>
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="Label2" runat="server" class="form-label" Text="Label">Fecha Ingreso 
                            <asp:RequiredFieldValidator ID="rfvFechaI" runat="server" 
                                ErrorMessage="La fecha de ingreso es obligatoria" 
                                ControlToValidate="txtfechaI" Text="*" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvFechaI" runat="server" 
                                ErrorMessage="La fecha de Inicio debe ser mayor o igual a la fecha actual" 
                                ControlToCompare="txtfechaActual" 
                                ControlToValidate="txtfechaI" 
                                Display="Dynamic" Type="Date" 
                                ValidationGroup="1" 
                                Operator="GreaterThanEqual" Text="*"></asp:CompareValidator>
                            </asp:Label>
                        <asp:TextBox ID="txtfechaI" CssClass="form-control" runat="server" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <asp:Label ID="Label1" runat="server" class="form-label" Text="Label">Fecha Salida 
                            <asp:CompareValidator ID="cvFechas" runat="server"
                                ControlToCompare="txtfechaI" CultureInvariantValues="true"
                                Display="Dynamic" EnableClientScript="true"
                                ControlToValidate="txtfechaF"
                                ErrorMessage="La fecha de inicio debe ser menor a la fecha de fin"
                                Type="Date" SetFocusOnError="true" Operator="GreaterThan"
                                Text="*" ValidationGroup="1"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvFechaf" runat="server"
                                ErrorMessage="La fecha de salida es obligatoria"
                                ControlToValidate="txtfechaF"  Text="*" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                        </asp:Label>
                        <asp:TextBox ID="txtfechaF" CssClass="form-control"  runat="server"  AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                        
                            
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label4" runat="server" class="form-label" Text="Label">Cantidad de huéspedes 
                            <asp:RequiredFieldValidator ID="rfvPersonas" runat="server"
                                ErrorMessage="La cantidad de personas es obligatorio"
                                ControlToValidate="txtpersonas" Text="*" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                        </asp:Label>
                        <asp:TextBox ID="txtpersonas" class="form-control" runat="server"  AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
                        
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label5" runat="server" class="form-label" Text="Label">Tipo de Habitación </asp:Label>
                        <asp:DropDownList ID="cbotipo" runat="server" class="form-select">
                            <asp:ListItem Selected="True" Value="Standard"> Standard -> $80 </asp:ListItem>
                            <asp:ListItem Value="Junior"> Junior -> $120 </asp:ListItem>
                            <asp:ListItem Value="Deluxe"> Deluxe -> $180 </asp:ListItem>
                            
                        </asp:DropDownList>
                        
                    </div>
                    <asp:Button ID="btnReservar" runat="server" Text="Reservar" class="btn btn-primary" ValidationGroup="1" OnClick="btnReservar_Click" />
                    <%--<asp:Button ID="btnAtras" runat="server" Text="Cancelar" class="btn btn-secondary" OnClick="btnAtras_Click" />--%>
                    <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
                </div>
            </div>
        </div>
        <%--buscar cliente--%>
        <div class="modal fade" id="clienteModal" tabindex="-1" aria-labelledby="ClienteModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ClienteModalLabel">Buscar Cliente</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row ">
                            <div class="col">

                                <div class="row mt-3">
                                    <div class="col-auto">
                                        <asp:Label ID="Label7" runat="server" Text="Label" class="col-form-label">Nombre</asp:Label>
                                    </div>
                                    <div class="col-auto">
                                        <asp:TextBox ID="txtnombrecliente" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                                    </div>
                                </div>
                                <br />

                                <br />
                                <asp:GridView ID="grdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdLista_PageIndexChanging" Width="100%" PagerSettings-PageButtonCount="4">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton  ID="lnkSeleccionar" runat="server" CommandArgument='<%# Eval("ID_CLIENTE").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionar_Command">Seleccionar</asp:LinkButton>

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
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
       
    </form>
    
    
</body>
</html>
