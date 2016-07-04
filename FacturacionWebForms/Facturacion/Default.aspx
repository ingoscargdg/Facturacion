<%@ Page Title="" Language="C#" MasterPageFile="~/Esquema.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Facturacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctpHolder" runat="server">
    <h2>Hola mundo</h2>
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
</asp:Content>
