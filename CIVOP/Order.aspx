<%@ Page Title="Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="CIVOP.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Objednávky
        </h1>
        <p>
        <asp:Button ID="AddOrderBtn" style="float: right;" runat="server" Text="Přidání objednávky" OnClick="AddOrderBtn_Click" />
        </p>
        <div class="lead">
                <div class="row">
               <asp:GridView ID = "GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" Width="1101px">  
                <Columns>  
                    <asp:TemplateField HeaderText="Hlavička" ItemStyle-Width="500">
        <ItemTemplate>
            <%# Eval("CustomerName") + ", " + Eval("CustomerAdddress")%>
        </ItemTemplate> 
       </asp:TemplateField> 
                    <asp:BoundField DataField = "CreatedDate" HeaderText="Datum vytvoření" ItemStyle-Width="250" />   
                    <asp:CommandField AccessibleHeaderText="Edit Data" HeaderText="Editace" ShowEditButton="True" />
                    <asp:CommandField AccessibleHeaderText="Delete Data" HeaderText="Smazani" ShowDeleteButton="True" />
                </Columns>  
            </asp:GridView>  
    </div>
        </div>        
    </div>
</asp:Content>
