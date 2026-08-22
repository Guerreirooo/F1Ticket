<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="EditarClassificacaoConstrutores.aspx.cs" Inherits="PAP___F1_Ticket.Admin.EditarClassificacaoConstrutores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
           .navbart{
         margin-top: -6.6%;
     }
        .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 20%;
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
        width: 25%;
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
         .lblPrimeiro{
         text-decoration: none;
    display: block;
    z-index: 1;
    position: absolute;
    margin-top: 1.1%;
    left: 42%;
    font-size: 1.11em;
    font-family: 'Tw Cen MT';
    color: black;
    }
    .PreSet{
        display: block;
        height: 30px; 
        width: 100%;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
    }
    .btnLeft {
            display: block;
            position: relative;
            margin-left: 60%;
            margin-top: -10%;
            height: 3em;
            font-size: 0.9em;
            background-color: #eeeeee;
            border: none;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
        }
         .btnLeft:hover {
            cursor: pointer;
        background-color: lightgrey;
        transition-delay: 0.1s;
        }
        .btnRight {
             display: block;
            position: relative;
            margin-left: 70%;
            margin-top: -2.9%;
            height: 3em;
            background-color: #eeeeee;
            border: none;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
            font-size: 0.9em;
        }
        .btnRight:hover {
            cursor: pointer;
        background-color: lightgrey;
        transition-delay: 0.1s;
        }
        .PontosPrimeiro{
            display: block;
            height: 6.5%;
            width: 5%;
            z-index: 1;
            position: absolute;
            background-color: #eeeeee;
            margin-top: 1.1%;
            left: 90%;
            font-size: 1.11em;
            font-family: 'Tw Cen MT';
            text-align: center;
        }
        
        .container {
            display: block;
            padding: 10px;
        }
        .containerInfo{
                margin-top: 27%;
                margin-left: 25%;
                display: block;
        }
        .containerInfo2{
                margin-top: -11%;
                margin-left: 39%;
                display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="divPistas"><h1 style="width: 100%; margin-left: 1%;">
        <label style="vertical-align: middle;">Editar Classificação</label>
    </h1></div>

     <div class="resultados">
             <h2><label>Pontos</label></h2>
     </div>

         <div id="imagemteste" class="Lugares"  runat="server">
         </div>
         
         <div class="containerInfo">
             <h4>Nome da Equipa</h4>
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
         <ContentTemplate> 
             <asp:DropDownList ID="selectEquipa" runat="server" AutoPostBack="true" style="width: 15%;">
             </asp:DropDownList>
         </ContentTemplate>
         </asp:UpdatePanel>
             <h4>Pontuação Atualizada</h4>
             <asp:TextBox ID="txtPontos" runat="server"></asp:TextBox>
         </div>

         <div class="containerInfo2">
             <h4>Melhor Resultado</h4>
             <asp:TextBox ID="txtMelhorResultado" runat="server"></asp:TextBox>
             <h4>Numero de Vezes</h4>
             <asp:TextBox ID="txtNumVezes" runat="server"></asp:TextBox>
         </div>

         <div class="container">
             <asp:button id="btnLeft" runat="server" class="btnLeft" onclick="guardarAlteracoes_Click" Text="Guardar Alterações"></asp:button>
             <asp:button id="btnRight" runat="server" class="btnRight" onclick="cancelar_Click" Text="Cancelar"></asp:button>
         </div>
</asp:Content>
