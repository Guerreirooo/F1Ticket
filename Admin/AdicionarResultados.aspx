<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="AdicionarResultados.aspx.cs" Inherits="PAP___F1_Ticket.Admin.AdicionarPista" %>
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
        .containerDropDown{
            margin-left: 10%;
            margin-top: 2%;
        }

        .containerResultados {
            margin-top: 1%;
            margin-left: 17%;
        }

        .containerResultados2{
            margin-top: -18%;
            margin-left: 50%;
        }

        .txtInfos{
            margin-left: 2%;
            width: 9%;
            margin-top: 0.5%;
        }

        .txtInfos2{
            margin-left: 1.35%;
            width: 9%;
            margin-top: 0.5%;
        }

        .txtInfos3{
            margin-left: 2%;
            width: 15%;
            margin-top: 0.8%;
        }

        .botoesConfirmar{
            display: block;
            padding: 10px;
        }

        .btnLeft {
            display: block;
            position: relative;
            margin-left: 38%;
            margin-top: 20%;
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
        .Voltar {
            text-decoration: none;
            text-align: center;
            color: black;
            line-height: 2.7em;
            display: block;
            position: relative;
            width: 5%;
            margin-left: 44%;
            margin-top: -2.9%;
            height: 2.7em;
            background-color: #eeeeee;
            border: none;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
            font-size: 1em;
        }
        .Voltar:hover {
            cursor: pointer;
        background-color: lightgrey;
        transition-delay: 0.1s;
        }

        .containerVoltaRapida{
            margin-left: 76%;
            margin-top: -20%;
        }

        .lblPiloto{
            margin-left: 24%;
            margin-top: 2%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%; margin-left: 1%;">
        <label style="vertical-align: middle;">Adicionar Resultados</label>
    </h1></div>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

     <div class="containerDropDown">
         <asp:DropDownList ID="selectPista" runat="server" AutoPostBack="true" style="width: 12%; height: 30px;">
         </asp:DropDownList>
     </div>

     <div class="lblPiloto">
         <label style="font-size: 19px; margin-left: 1%;"><b>Piloto</b></label>
         <label style="font-size: 19px; margin-left: 8%;"><b>Tempo</b></label>

         <label style="font-size: 19px; margin-left: 25.5%;"><b>Piloto</b></label>
         <label style="font-size: 19px; margin-left: 7.2%;"><b>Tempo</b></label>
     </div>

     <div id="divLugares" runat="server" class="containerResultados">

         <label>1 Lugar</label>
         <asp:TextBox type='text' id='Piloto1' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo1' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>2 Lugar</label>
         <asp:TextBox type='text' id='Piloto2' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo2' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>3 Lugar</label>
         <asp:TextBox type='text' id='Piloto3' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo3' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>4 Lugar</label>
         <asp:TextBox type='text' id='Piloto4' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo4' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>5 Lugar</label>
         <asp:TextBox type='text' id='Piloto5' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo5' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>6 Lugar</label>
         <asp:TextBox type='text' id='Piloto6' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo6' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>7 Lugar</label>
         <asp:TextBox type='text' id='Piloto7' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo7' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>8 Lugar</label>
         <asp:TextBox type='text' id='Piloto8' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo8' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>9 Lugar</label>
         <asp:TextBox type='text' id='Piloto9' runat='server' class='txtInfos'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo9' runat='server' class='txtInfos'></asp:TextBox>
         <br/>

         <label>10 Lugar</label>
         <asp:TextBox type='text' id='Piloto10' runat='server' class='txtInfos2'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo10' runat='server' class='txtInfos'></asp:TextBox>
         <br/>
     </div> 

     <div id="divLugares2" runat="server" class="containerResultados2">

         <label>11 Lugar</label>
         <asp:TextBox type='text' id='Piloto11' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo11' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>12 Lugar</label>
         <asp:TextBox type='text' id='Piloto12' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo12' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>13 Lugar</label>
         <asp:TextBox type='text' id='Piloto13' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo13' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>14 Lugar</label>
         <asp:TextBox type='text' id='Piloto14' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo14' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>15 Lugar</label>
         <asp:TextBox type='text' id='Piloto15' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo15' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>16 Lugar</label>
         <asp:TextBox type='text' id='Piloto16' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo16' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>17 Lugar</label>
         <asp:TextBox type='text' id='Piloto17' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo17' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>18 Lugar</label>
         <asp:TextBox type='text' id='Piloto18' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo18' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>19 Lugar</label>
         <asp:TextBox type='text' id='Piloto19' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo19' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>

         <label>20 Lugar</label>
         <asp:TextBox type='text' id='Piloto20' runat='server' class='txtInfos3'></asp:TextBox>
         <asp:TextBox type='text' id='Tempo20' runat='server' class='txtInfos3'></asp:TextBox>
         <br/>
     </div> 

     <div runat="server" class="containerVoltaRapida">
         <label style="margin-left: 20%;">Volta Mais Rápida</label> <br /> <br />
         <asp:TextBox ID="txtPilotoVoltaRapida" runat="server" style="width: 34%;"></asp:TextBox>
         <asp:TextBox ID="txtTempoVoltaRapida" runat="server" style="width: 34%;"></asp:TextBox>
     </div>

     <div id="botoesConfirmar" class="botoesConfirmar">
          <asp:button id="btnLeft" runat="server" class="btnLeft" OnClick="Adicionar_OnClick" Text="Adicionar"></asp:button>
          <a id="Voltar" href="~/PaginaInicial.aspx" runat="server" class="Voltar">Voltar</a>
     </div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
