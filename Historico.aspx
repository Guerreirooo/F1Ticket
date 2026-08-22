<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="PAP___F1_Ticket.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
     .navbart{
         margin-top: -6%;
     }
        .divPistas {
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
        .historico {
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
        .historico td {
         text-align: center;
     }
        .btnApagar{
    position: absolute;
    top: 260px; 
    left: 900px;
    float: right; 
    font-size: 80%;
    border-radius: 8px;
    height: 3em;
    }
        .btnApagar:hover {
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
    <i class="fa-solid fa-clock-rotate-left" style="color:black; height:1em; width:1em; padding:0px 5px;"></i>
    <label style="margin-left: 1%;"> Histórico</label>
    </h1></div>

    <asp:GridView class="historico" ID="GVHistórico" runat="server" Visible="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" OnRowDataBound="GVHistorico_RowDataBound"></asp:GridView>

    <h1><label id="lblTotal" runat="server" class="LBLTotal"></label></h1>

    <asp:Button class="btnApagar" ID="btnApagar" runat="server" Text="Apagar histórico" OnClick="btnApagar_Click"/>

    <h4 style="margin-left: 2%; margin-top: 20%;">Caso queira cancelar alguma compra de bilhete, contacte-nos:  <b>123@email.com</b> .</h4>
</asp:Content>