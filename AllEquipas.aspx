<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="AllEquipas.aspx.cs" Inherits="PAP___F1_Ticket.AllEquipas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .navbart{
            margin-top: -6.6%;
        }

        .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 35%;
    margin-top: 6.6%;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;
    align-items: center;   
}
         .linkRedirecionamento {
        color: black;
        display: inline-block;
        transition: transform 0.3s ease-in-out;
        margin-left: 2%
    }

    .linkRedirecionamento:hover {
        transform: scale(1.2);
    }
    .divPrincipalFoto {  
    position: absolute;
    flex-direction: column;
    top: 56%;
    left: 40%;
    transform: translate(-50%, -50%);
    display: flex;
    height: 400px;
    width: 17%;
    margin-left: 1%;
    margin-top: 2%;
    border-top: 3px solid black;
    border-left: 3px solid black;
    border-right: 3px solid black;
    border-bottom: 3px solid black;
    z-index: 1;
}
    .divPrincipalInfo{
        position: absolute;
        flex-wrap: wrap;
    top: 56%;
    left: 60.25%;
    flex-direction: column;
    transform: translate(-50%, -50%);
    display: flex;
    height: 500px;
    width: 27%;
    margin-left: 1%;
    margin-top: 2%;
    border-top: 3px solid black;
    border-right: 3px solid black;
    border-bottom: 3px solid black;
    align-content: center;
    }
    .FotoEquipa{
        position: absolute;
        top: 45%;
        transform: translate(-50%, -50%);
        max-width: 100%;
        max-height: 100%;
        object-fit: contain;
        height: 190px;
    }
    .divFoto{
        margin-top: 6%;
        height: 70%;
        width: 100%;
        position: relative;
        text-align: center;
        float: left;
    }
    .bandeira{
        height: 23px; 
        width: 40px;
    }



    .divNomeEquipa {
        font-family: "Tw Cen MT";
        font-size: 1.4em;
        height: 10%;
        width: 100%;
        text-align: center;
        padding-bottom: 40%;
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
}
    .divPaisOrigem{
        font-family: "Tw Cen MT";
        font-size: 1.4em;
        padding-top: 13%;
        height: 11%;
        width: 100%;
        text-align: center;
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
    }
    .divResto{
 font-family: "Tw Cen MT";
  float: right;
  margin-left: auto;
        font-size: 1.4em;
        height: 11%;
        width: 100%;
        text-align: center;
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
    }

    .divResto .bandeira {
  max-height: 100%;
  margin-right: auto;
  max-width: 100%;
  margin-right: 5px;
}

.divPaisOrigem .bandeira {
  max-height: 100%;
  max-width: 100%;
  margin-right: 10px;
}

.divPaisOrigem .palavra {
  display: flex;
  align-items: center;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="divPistas"><h1 style="width: 100%;">
        <a href="#" class="linkRedirecionamento" id="linkRedirecionamento" runat="server">
            <i class="fa-regular fa-arrow-left"></i>
        </a>
        <asp:Label id="lblNomeCima" runat="server" style="vertical-align: middle; margin-left: 2%;" Text=""></asp:Label>
    </h1></div>

    <div id="divPrincipalFoto" runat="server" class="divPrincipalFoto">    
        <div id="divFoto" runat="server" class="divFoto">
        </div>
        <div id="divNomeEquipa" runat="server" class="divNomeEquipa">
        </div>
    </div>
    <div id="divPrincipalInfo" runat="server" class="divPrincipalInfo">  
        <div id="divPaisOrigem" runat="server" class="divPaisOrigem ">
        </div>
        <div id="divPodios" runat="server" class="divResto">
        </div>
        <div id="divVitorias" runat="server" class="divResto">
        </div>
        <div id="divCorridasFeitas" runat="server" class="divResto">
        </div>
        <div id="divAnoDebut" runat="server" class="divResto">
        </div>
        <div id="divNomePilotos" runat="server" class="divResto">
        </div>
        <div id="divNomePilotos2" runat="server" class="divResto">
        </div>
    </div>

    <script>
    var fotoEquipa = document.getElementById("FotoEquipa");
  
  // Verifica se a imagem precisa ser reajustada
  if (fotoEquipa.width > 250) {
      fotoEquipa.width = 190;
      fotoEquipa.height = 115;// Define o novo tamanho desejado
        }
    </script>
</asp:Content>
