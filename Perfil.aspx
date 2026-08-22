<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="PAP___F1_Ticket.Perfil" %>
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
        .divPerfil {
    height: 450px;
    width: 60%;
    margin-top: 3%;
    box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
    background-color: #C1CDCD;
    position: absolute;
    left: 23.5%;
    align-content:center;
    }
         .btnAlterarPP{
    float: right; 
    font-size: 80%;
    border: none;
    margin-right: 3%; 
    vertical-align: bottom;
    cursor: pointer;
    background-color: #eeeeee;
    box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
    height: 3em;
    }
        .btnAlterarPP:hover{
    background-color:lightgrey;
    }
        .labels{
    font-size: 22px;
    display: block;
    text-align: center;
    margin-right: 5%;
    margin-top: 2%;
    }
        .labels2{
            font-size: 18px;
    display: block;
    text-align: center;
    margin-right: 5%;
    margin-top: 2%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%;">
    <i class="fa-solid fa-circle-user" style="color:black; height:1em; width:1em; padding:0px 5px;"></i>
    <label style="margin-left: 1%;"> Perfil</label>
    </h1></div>

    <div class="divPerfil">
        <img src="Images/Perfil/capacetePerfil.png" style="margin-top: 2%; margin-left: 42%;"/>
        <br />
        <b><label class="labels">Nome</label></b><label runat="server" id="lblUserName" class="labels2"></label>
        <br />
        <b><label class="labels">Email</label></b><label runat="server" id="lblEmail" class="labels2"></label>
        <br />
        <b><label class="labels">Connosco Desde</label></b><label runat="server" id="lblData" class="labels2"></label>
        <asp:Button class="btnAlterarPP" ID="Button2" PostBackUrl="AlterarPP.aspx" runat="server" Text="Alterar Password"/> 
    </div>
</asp:Content>
