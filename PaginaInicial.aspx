<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="PAP___F1_Ticket.PaginaInicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .navbart{
        margin-top: -7%;
    }

.divPistas {
    height: 450px;
    width: 40%;
    margin-top: 1%;
    overflow-y: scroll;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 3px;
    border-right: 0px;
    border-left-width: 3px;
    border-image: linear-gradient(to right, red 100%, white 0%) 1;
}

.box {
    height: 20%;
    margin: 10px;
    border: none;
    display: flex;
    background-color: #eeeeee;
    justify-content: space-between;
    align-items: center;
    padding: 10px;
    border-radius: 8px;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.3);
}

.divPistas::-webkit-scrollbar {
    width: 3px;
    background-color: white;
}

.divPistas::-webkit-scrollbar-thumb {
    background-color: black;
}

.DataCorridas {
    margin-top: 69px;
}

.btnComprar {
    text-decoration: none;
    display: flex;
    justify-content: center;
    align-items: center;
    vertical-align: middle;
    border-radius: 8px;
    height: 40%;
    width: 17%;
    color: black;
    background-color: #eeeeee;
    border: 3px solid black;
}

    .btnComprar:hover {
        background-color: red;
        color: white;
        border: none;
        transition-delay: 0.1s;
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
         margin-left: 50%;
     }
        .historico td {
         text-align: center;
     }
        .lblHistorico{
            margin-top: 7%;
            margin-left: 63%;
            display: flex;
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
.PreSet{
        display: block;
        height: 30px; 
        width: 100%;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
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
.divCampP {
        position: absolute;
        top: 68%;
        left:45%;
        height: 13%;
        width: 50%;
        z-index: 2;
    }

        .lblCampP{
            position: absolute;
        top: 62%;
        left:63%;
        height: 3%;
        width: 18%;
        z-index: 2;
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
    <h3><label class="lblHistorico">Ultimas Transações Guardadas</label></h3>
    <asp:GridView class="historico" ID="GVHistórico" runat="server" Visible="true" AllowPaging="true" PageSize="5" OnRowDataBound="GVHistorico_RowDataBound">
         <PagerSettings Visible="false" />
    </asp:GridView>

    <div id="divPistas" runat="server" class="divPistas">
    </div>

    <h3><label class="lblCampP">Classificação Campeonato Pilotos</label></h3>
    <div id="divCampP" runat="server" class="divCampP">
    </div>

    <div id="botoesAdmin" runat="server" Visible="false">
         <asp:Button ID="adicionarPista" runat="server" class="botoesAdmin" style="margin-left: 12%;" Text="Adicionar Resultados" OnClick="adicionarResultados_Click"/>
         <asp:Button ID="editarPista" runat="server" class="botoesAdmin" Text="Editar Lista" OnClick="editarPista_Click"/>
         <asp:Button ID="removerPista" runat="server" class="botoesAdmin" Text="Adicionar Bilhetes" OnClick="adicionarBilhetes_Click"/>
         <asp:Button ID="alterarClassificacao" runat="server" class="botoesAdmin" style="margin-left: 6%; width: 15%;" Text="Editar Classificacao Pilotos" OnClick="editarClassificacao_Click"/>
         <asp:Button ID="alterarClassificacaoConstrutores" runat="server" class="botoesAdmin" style="width: 15%;" Text="Editar Classificacao Construtores" OnClick="editarClassificacaoConstrutores_Click"/>
    </div>
</asp:Content>
