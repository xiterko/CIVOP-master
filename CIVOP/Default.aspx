<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CIVOP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Produkty
        </h1>
        <p>
        <asp:Button ID="AddProductBtn" style="float: right;" runat="server" Text="Přidání produktu" OnClick="AddProductBtn_Click" />
        </p>
        <div class="lead">
                <div class="row">
               <asp:GridView ID = "GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" Width="1101px">  
                <Columns>  
                    <asp:BoundField DataField = "Code" HeaderText="Kód" ItemStyle-Width="200"  />  
                    <asp:BoundField DataField = "Name" HeaderText="Název" ItemStyle-Width="250" />  
                    <asp:BoundField DataField = "Price" HeaderText="Cena" ItemStyle-Width="250" />  
                    <asp:CommandField AccessibleHeaderText="Edit Data" HeaderText="Editace" ShowEditButton="True" />
                    <asp:CommandField AccessibleHeaderText="Delete Data" HeaderText="Smazani" ShowDeleteButton="True" />
                </Columns>  
            </asp:GridView>  
    </div>
    </div>        
    </div>
</asp:Content>
