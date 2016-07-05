<%@ Page Title="" Language="C#" MasterPageFile="~/Esquema.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Facturacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctpHolder" runat="server">
        <div class="card card-block">
          <h4 class="card-title">Datos Generales</h4>
         
            <div class="md-form">
                    

                <div class="col-lg-6">
                    <label for="i5p" class="control-label">Nombre:</label><asp:TextBox ID="txtNameCustomer" class="form-control" runat="server"></asp:TextBox>
                    <label for="form1" class="">RFC Emisor:</label><asp:TextBox ID="txtRfc" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <label for="form1" class="control-label">Dirección Emisor:</label><asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                    <label for="form1" class="control-label">RFC Receptor:</label><asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <label for="form1" class="">Dirección Receptor:</label><asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                    <asp:Button class="btn btn-flat btn-warning" ID="btnSave" runat="server"  OnClick="btnSave_Click" Text="Save" />
                </div>
            </div>
        </div>

        <asp:GridView ID="Items" runat="server" 
            AutoGenerateColumns="False" 
            CssClass="table table-bordered bs-table"
            DataKeyNames="ClienteID" 
            allowpaging="true">

            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
            <emptydatatemplate>
                ¡No hay clientes con los �metros seleccionados!  
            </emptydatatemplate>  

            <%--Paginador...--%>        
            <pagertemplate>
            <div class="row" style="margin-top:20px;">
                <div class="col-lg-1" style="text-align:right;">
                    <h5><asp:label id="MessageLabel" text="Ir a la pág." runat="server" /></h5>
                </div>
                <div class="col-lg-10" style="text-align:right;">
                    <h3><asp:label id="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                </div>
            </div>        
            </pagertemplate> 

            <Columns>

                <%--CheckBox para seleccionar varios registros...--%>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEliminar" runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>  

                <%--botones de acción sobre los registros...--%>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <%--Botones de eliminar y editar cliente...--%>
                        <asp:Button ID="btnDelete" runat="server" Text="Quitar" CssClass="btn btn-danger" CommandName="Delete" />
                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                    </ItemTemplate>
                    <edititemtemplate>
                        <%--Botones de grabar y cancelar la edición de registro...--%>
                        <asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
                    </edititemtemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Category" HeaderText="Departamento" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Precio" />
                <asp:BoundField DataField="Quantity" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
</asp:Content>
