<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="CampeonatoPilotos.aspx.cs" Inherits="PAP___F1_Ticket.CampeonatoPilotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
     .navbart{
         margin-top: -6.6%;
     }
        .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 45%;
    margin-top: 6.6%;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;
    align-items: center;   
}
        .resultados {
        position: absolute;
        top: 21%;
        left: 69%;
        width: 5%;
        z-index: 2;
         }

         .Lugares {
        position: absolute;
        top: 28%;
        left:25%;
        height: 40%;
        width: 50%;
        z-index: 2;
    }
         .lblPrimeiro {
    text-decoration: none;
    display: block;
    z-index: 1;
    position: absolute;
    margin-top: 1.1%;
    left: 10%;
    font-size: 1.11em;
    font-family: 'Tw Cen MT';
    color: black;
}
         .lblPrimeiro::before {
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

.lblPrimeiro:hover::before {
    width: 100%;
}
    .lblUltimo{
        text-decoration: none;
    display: none;
    z-index: 1;
    position: absolute;
    margin-top: 1.1%;
    left: 10%;
    font-size: 1.11em;
    font-family: 'Tw Cen MT';
    color: black;
    }

    .lblUltimo::before {
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

.lblUltimo:hover::before {
    width: 100%;
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
    .btnLeft {
            display: block;
            position: relative;
            margin-left: 65%;
            margin-top: 26%;
            border-radius: 8px;
            height: 3em;
            font-size: 0.9em;
        }
         .btnLeft:hover {
            background-color: red;
            color: white;
            border: none;
            transition-delay: 0.1s;
        }
        .btnRight {
            display: block;
            position: relative;
            margin-left: 69%;
            margin-top: -2.9%;
            border-radius: 8px;
            height: 3em;
            font-size: 0.9em;
        }
        .btnRight:hover {
            background-color: red;
            color: white;
            border: none;
            transition-delay: 0.1s;
        }
        .PontosPrimeiro{
            display: block;
            z-index: 1;
            position: absolute;
            margin-top: 1.1%;
            left: 90%;
            font-size: 1.11em;
            font-family: 'Tw Cen MT';
        }
        .PontosUltimo{
            display: none;
            z-index: 1;
            position: absolute;
            margin-top: 1.1%;
            left: 90%;
            font-size: 1.11em;
            font-family: 'Tw Cen MT';
        }
        .container {
            display: block;
            justify-content: space-between;
            align-items: center;
            padding: 10px;
        }
        .botoesAdmin {
            text-decoration: none;
            height: 30px;
            width: 9%;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
            color: black;
            background-color: #eeeeee;
            border: none;
        }


        .botoesAdmin:hover {
        cursor: pointer;
        background-color: lightgrey;
        transition-delay: 0.1s;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%;">
        <img src="Images/CampeonatoPilotos/ChecoWinComTrofeu.png" style="vertical-align: middle;margin-left: 1%; height: 60px; width: 70px; margin-bottom: 1.8%;" />
        <label style="vertical-align: middle;"> Classificação Campeonato Pilotos 2023</label>
    </h1></div>

     <div class="resultados">
             <h2><label>Pontos</label></h2>
     </div>

         <div id="imagemteste" class="Lugares"  runat="server">
         </div>
    
     <div id="botoesAdmin" runat="server" Visible="false">
         <asp:Button ID="alterarClassificacao" runat="server" class="botoesAdmin" style="margin-left: 80%; width: 15%;" Text="Editar Classificacao Pilotos" OnClick="editarClassificacao_Click"/>
     </div>

     <div class="container">
         <button id="btnLeft" class="btnLeft" onclick="btnLeftClick(event)">Top 10</button>
         <button id="btnRight" class="btnRight" onclick="btnRightClick(event)">Ultimos 10</button>
     </div>
    


    <script src="../Script/CampeonatoPilotos.js"></script>
</asp:Content>
