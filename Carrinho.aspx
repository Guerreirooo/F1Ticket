<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="PAP___F1_Ticket.Carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
     .navbart{
         margin-top: -6%;
     }
     .carrinho {
         height: 15%;
         width: 40%;
         box-shadow: 8px;
         position: fixed;
         align-items: center;
         vertical-align: middle;
         border-color: black;
         border-style: solid;
         border-bottom-width: 3px;
         border-top-width: 3px;
         border-right-width: 3px;
         border-left-width: 3px;
         margin-top: 5%;
         margin-left: 1%;
     }
     .carrinho td {
         text-align: center;
     }
    .divPistas{
    margin-left: 1%;
    display:flex;
    height: 50px;
    width: 20%;
    margin-top: 6%;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;  
    align-items: center;
    }
    .btnCompra{
    position: absolute;
    top: 260px; 
    left: 900px;
    float: right; 
    font-size: 80%;
    border-radius: 8px;
    height: 3em;
    }
        .btnCompra:hover {
    background-color: red;
    color: white;
    border: none;
    transition-delay: 0.1s;
    }
        .btnLimpar{
            position: absolute;
    top: 260px; 
    left: 780px;
    float: right; 
    font-size: 80%;
    border-radius: 8px;
    height: 3em;
        }
        .btnLimpar:hover {
    background-color: red;
    color: white;
    border: none;
    transition-delay: 0.1s;
    }
        .LBLTotal{
            position: absolute;
    top: 220px; 
    left: 740px;
    float: right; 
    font-size: 80%;
    border-radius: 8px;
    height: 3em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%;">
    <i class="fa-regular fa-cart-shopping" style="color:black; height:1em; width:1em; padding:0px 5px;"></i>
    <label style="margin-left: 1%;"> Carrinho</label>
    </h1></div>

    <asp:GridView class="carrinho" ID="GVCarrinho" runat="server" Visible="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" OnRowDataBound="GVCarrinho_RowDataBound"></asp:GridView>

    <h1><label id="lblTotal" runat="server" class="LBLTotal"></label></h1>

    
    <asp:Button ID="btnLimpar" runat="server" Text="Limpar Carrinho" Class="btnLimpar" OnClick="btnLimpar_Click" />
    <asp:Button ID="btnCompra" runat="server" Text="Finalizar Compra" Class="btnCompra" OnClick="btnComprar_Click" />

</asp:Content>
