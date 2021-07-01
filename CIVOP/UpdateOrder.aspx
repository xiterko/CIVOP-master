<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="CIVOP.UpdateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1 class="lead"><asp:Label ID="Heade" runat="server" Text="Editace objednávky"></asp:Label></h1>
            <p class="lead">
                <asp:Label ID="Label1" runat="server" Text="Jméno zákazníka"></asp:Label>
                <asp:TextBox ID="TxtCustomerName" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="Label2" runat="server" Text="Adresa zákazníka"></asp:Label>
                <asp:TextBox ID="TxtCustomerAddress" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="Label3" runat="server" Text="Datum Vytvoření objednávky"></asp:Label>
                <asp:TextBox ID="TxtCreatedDate" type="date" runat="server"></asp:TextBox>
            </p>
            <p class="lead">
                <asp:Label ID="TotalValue" runat="server" Text="Celková cena objednávky: "></asp:Label>
            </p>
            <h1 class="lead"><asp:Label ID="Label4" runat="server" Text="Produkty přiřazené k objednávce" Visible ="false"></asp:Label></h1>
             <div class="row">
               <asp:GridView ID = "GridView1" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" Width="1101px">  
                <Columns>  
                    <asp:BoundField DataField = "ProductId" HeaderText="Id" ItemStyle-Width="250" />
                    <asp:BoundField DataField = "Code" HeaderText="Kód" ItemStyle-Width="200"  />  
                    <asp:BoundField DataField = "Name" HeaderText="Název" ItemStyle-Width="250" />  
                    <asp:BoundField DataField = "Price" HeaderText="Cena" ItemStyle-Width="250" />  
                    <asp:CommandField AccessibleHeaderText="Delete Data" HeaderText="Odebrání z objednávky" ShowDeleteButton="True" />
                </Columns>  
            </asp:GridView>  
            </div>
            <p class="lead">
                <asp:Button ID="Button1" runat="server" OnClick="BtnAddProducts_Click" Text="Přidat produkty k objednávce" />
            </p>
            <div class="row">
               <asp:GridView ID = "GridView2" runat="server" AutoGenerateColumns="false" Width="1101px" Visible ="false" OnRowEditing="GridView1_RowEditing" >  
                <Columns>  
                    <asp:BoundField DataField = "ProductId" HeaderText="Id" ItemStyle-Width="250" />
                    <asp:BoundField DataField = "Code" HeaderText="Kód" ItemStyle-Width="200"  />  
                    <asp:BoundField DataField = "Name" HeaderText="Název" ItemStyle-Width="250" />  
                    <asp:BoundField DataField = "Price" HeaderText="Cena" ItemStyle-Width="250" />  
                    <asp:CommandField AccessibleHeaderText="Insert Data" HeaderText="Přidání k objednávce" EditText="Přidat" ShowEditButton="True" />
                </Columns>  
            </asp:GridView>  
            </div>
            <p class="lead">
                <asp:Button ID="SaveBtn" runat="server" OnClick="SaveBtn_Click" Text="Uložit" />
                <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Zrušit" />
            </p>       
    </div>
</asp:Content>
