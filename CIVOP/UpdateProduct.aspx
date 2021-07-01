<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="CIVOP.updateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1 class="lead"><asp:Label ID="Heade" runat="server" Text="Editace produktu"></asp:Label></h1>
            <p class="lead">
                <asp:Label ID="Label1" runat="server" Text="Kód produktu"></asp:Label>
                <asp:TextBox ID="TxtProductCode" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="Label2" runat="server" Text="Název"></asp:Label>
                <asp:TextBox ID="TxtProductName" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="Label3" runat="server" Text="Cena"></asp:Label>
                <asp:TextBox ID="TxtProductPrice" type="number" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Button ID="SaveBtn" runat="server" OnClick="SaveBtn_Click" Text="Uložit" />
                <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Zrušit" />
            </p>       
    </div>
</asp:Content>
