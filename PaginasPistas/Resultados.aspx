<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="PAP___F1_Ticket.Resultados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
     .navbart{
         margin-top: -6%;
     }
        .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 80%;
    margin-top: 6%;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;
    align-items: center;   
}
        .divisor{
            display: flex;
        }
        .legenda{
        border-style: solid;
        border-color: #333;
        border-bottom-width: 3px;
        border-top-width: 3px;
        border-right-width: 3px;
        border-left-width: 3px;
        width: 15%; 
        height: 15%; 
        position: fixed;
        bottom: 5%;
        left: 40%;
        right: 0;
        border-radius: 8px;
        display: flex;
        flex-direction: column;
    }
        .resultados {
        position: absolute;
        top: 21%;
        left: 70%;
        width: 25%;
        z-index: 2;
         }

         .voltaRapida{
             position: absolute;
        top: 75%;
        left: 70%;
        width: 25%;
        z-index: 2;
         }

         .Lugares {
        position: absolute;
        top: 29%;
        left: 56%;
        height: 36%;
        width: 43%;
        z-index: 2;
    }

         .container {
            display: block;
            justify-content: space-between;
            align-items: center;
            padding: 10px;
        }
         #btnLeft {
            display: block;
            position: fixed;
            left: 89%;
            top: 73%;
            border-radius: 8px;
            height: 3em;
            font-size: 0.9em;
        }
         #btnLeft:hover {
            background-color: red;
            color: white;
            border: none;
            transition-delay: 0.1s;
        }
        #btnRight {
            display: block;
            position: fixed;
            right: 1%;
            top: 73%;
            border-radius: 8px;
            height: 3em;
            font-size: 0.9em;
        }
        #btnRight:hover {
            background-color: red;
            color: white;
            border: none;
            transition-delay: 0.1s;
        }
        
        .lblPrimeiroNome{
            display: block;
            text-decoration: none;
            z-index: 1;
            top: 22.8%;
            position: absolute;
            left: 10%;
            font-size: 1.03em;  
            font-family: 'Tw Cen MT'; 
            color: black;
        }
        .lblPrimeiro{
            display: block;
            z-index: 1;
            top: 20.6%;
            position: absolute;
            left: 0.8%;
            font-size: 1.1em;
            color: black;
        }
        .lblPrimeiroNome::before {
            content: "";
            position: absolute;
            bottom: 0;
            left: 50%;
            transform: translateX(-50%);
            width: 0;
            height: 2px;
            background-color: black;
            transition: width 0.3s;
        }

        .lblPrimeiroNome:hover::before {
            width: 100%;
        }
        .lblPrimeiroTempo{
            display: block;
            z-index: 1;
            top: 25%;
            position: absolute;
            left: 83%;
            font-size: 1em;
            background-color: #eee;
        }
        .lblDecimoPrimeiro{
            display: none;
            z-index: 1;
            top: 20.6%;
            position: absolute;
            left: 0.1%;
            font-size: 1.1em;
            color: black;
        }
         .lblDecimoPrimeiroNome::before {
            content: "";
            position: absolute;
            bottom: 0;
            left: 50%;
            transform: translateX(-50%);
            width: 0;
            height: 2px;
            background-color: black;
            transition: width 0.3s;
        }

        .lblDecimoPrimeiroNome:hover::before {
            width: 100%;
        }
        .lblDecimoPrimeiroNome{
            display: none;
            text-decoration: none;
            z-index: 1;
            top: 22.8%;
            position: absolute;
            left: 10%;
            font-size: 1.03em;
            font-family: 'Tw Cen MT'; 
            color: black;
        }
        .lblDecimoPrimeiroTempo{
            display: none;
            z-index: 1;
            top: 25%;
            position: absolute;
            left: 83%;
            font-size: 1em;
            background-color: #eee;
        }
        .lblPilotoVoltaRapida{
            display: block;
            text-decoration: none;
            z-index: 1;
            top: 22.8%;
            position: absolute;
            left: 10%;
            font-size: 1.03em;
            font-family: 'Tw Cen MT'; 
            color: black;
        }
        .lblPilotoVoltaRapida::before {
            content: "";
            position: absolute;
            bottom: 0;
            left: 50%;
            transform: translateX(-50%);
            width: 0;
            height: 2px;
            background-color: black;
            transition: width 0.3s;
        }

        .lblPilotoVoltaRapida:hover::before {
            width: 100%;
        }
        .lblTempoVoltaRapida{
            display: block;
            z-index: 1;
            top: 25%;
            position: absolute;
            left: 83%;
            font-size: 1em;
            background-color: #eee;
        }
        .lblOutros{
            display: block;
            z-index: 1;
            top: 4.6%;
            position: absolute;
            left: 0.8%;
            font-size: 1.1em;
        }
       
        .PreSet{
        display: block;
        height: 30px; 
        width: 100%;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
    }
    .PreSetEscondido{
        display: none;
        height: 30px; 
        width: 100%;  
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
    }
        .VoltaRapida{
        position: absolute;
        top: 75%;
        left: 56%;
        width: 43%;
        height: 3%;
        z-index: 2;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
        }
        .lblVoltaRapida{
        position: absolute;
        top: 75%;
        left: 56%;
        width: 30%;
        height: 3%;
        z-index: 2;
        text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblErro" style="display:flex; margin-top:6%;" ForeColor="Red" runat="server" Font-Size="15pt" Text="Esta pista ainda não tem resultados, volte novamente mais tarde" Visible="false"></asp:Label>

    <div id="divPistas" runat="server" class="divPistas" visible="false"><h1 style="width: 100%;">
        <asp:Image ID="imgBandeira" runat="server" Style="vertical-align: middle;" />
        <label id="lblNomeCorrida" runat="server" style="vertical-align: middle;"></label>
    </h1></div>


<div class="divisor">
     <!--Imagem Lado Esquerdo -->
    <div style ="width: 54%; text-align: center; display: flex; justify-content: center; align-items: center; height: 60vh;"><asp:Image ID="imgBancadas" runat="server" Style="margin-left: 1%; max-width: 100%; height: auto; object-fit: contain;"/></div> <br />
    <!--Div Legenda Embaixo -->
    <div id="lblLegenda" runat="server" class="legenda" visible="false">
        <b style="margin-left: 1%;">LEGENDA</b>
        <div style="display: flex;">
        <img src="ImagensLegenda/Bancada.png" / style="height: 10px; width: 35px; margin-top: 11%; padding: 0px 8px;"> <h5> - Bancadas</h5>
        </div>
        <div style="display: flex;">
        <img src="ImagensLegenda/EcraGigante.png" style="height: 5px; width: 23px; margin-top: 3%; padding: 0px 8px;" /> <h5 style="margin-top: -0.1%;"> - Ecrãs Gigantes</h5>
        </div>
    </div>

     <div id="lblresultados" runat="server" class="resultados" Visible="false">
             <h2><label>Resultados Corrida 2023</label></h2>
         </div>

         <div id="divLugares" class="Lugares" runat="server">
         </div>

         <div id="divcontainer" runat="server" class="container" visible="false">
            <button id="btnLeft" onclick="btnLeftClick(event)">Top 10</button>
            <button id="btnRight" onclick="btnRightClick(event)">Ultimos 10</button>
         </div>

         <div id="lblVoltaRapida" runat="server" class="lblVoltaRapida" visible="false">
             <h2><label>Volta Mais Rápida</label></h2>
         </div>

         <div id="divVoltaRapida" class="VoltaRapida" style="margin-top: 5%;" runat="server" visible="false">
         </div>
     
    <script src="../Script/ResultadosCorridas.js"></script>     

    </div>
</asp:Content>
