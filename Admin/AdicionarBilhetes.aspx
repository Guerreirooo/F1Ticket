<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="AdicionarBilhetes.aspx.cs" Inherits="PAP___F1_Ticket.Admin.RemoverPista" %>
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

        .containerDropDown2{
            margin-left: 45%;
            margin-top: -22%;
        }

        .txtInfos{
            margin-left: 2%;
            margin-top: 0.5%;
        }
        .btnLeft {
            display: block;
            position: relative;
            margin-left: 80%;
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
            margin-left: 86%;
            width: 5%;
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
        .botoesConfirmar {
            display: block;
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="divPistas"><h1 style="width: 100%; margin-left: 1%;">
        <label style="vertical-align: middle;">Adicionar Bilhetes</label>
    </h1></div>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

     <div class="containerDropDown">
         <asp:DropDownList ID="selectPista" runat="server" AutoPostBack="true" style="width: 12%; height: 30px;" OnSelectedIndexChanged="selectPista_SelectedIndexChanged">
         </asp:DropDownList>
         <br />
         <br />

         <asp:Label ID="lblNumBancadas" runat="server"></asp:Label><br />
         <asp:TextBox ID="txtNumBancadas" runat="server" AutoPostBack="true" OnTextChanged="txtNumBancadas_TextChanged"></asp:TextBox>
         <br />
         <br />
         
         <asp:Label ID="lblPrecoBancadas" runat="server" Text="Insira o preço dos bilhetes por bancada, e a quantidade de acentos por bancada"></asp:Label>
         <br />
         <asp:DropDownList ID="selectTipo" runat="server" style="width: 12%; height: 30px;">
             <asp:ListItem Text="Treinos" Value="1"></asp:ListItem>
             <asp:ListItem Text="Qualificação" Value="2"></asp:ListItem>
             <asp:ListItem Text="Corrida" Value="3"></asp:ListItem>
             <asp:ListItem Text="Fim de Semana Completo" Value="4"></asp:ListItem>
         </asp:DropDownList>
     </div>
    

     <div id="botoesConfirmar" runat="server" class="botoesConfirmar">
         <asp:button id="btnLeft" runat="server" class="btnLeft" OnClick="adicionar_Click" Text="Adicionar"></asp:button>
         <asp:button id="btnRight" runat="server" class="btnRight" onclick="cancelar_Click" Text="Voltar"></asp:button>
     </div>

     <div id="divBilhetes1" runat="server" class="containerDropDown">
         <Label runat="server">Bancada A</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco1' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar1' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada B</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco2' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar2' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada C</Label>
        <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco3' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar3' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada D</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco4' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar4' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada E</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco5' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar5' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada F</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco6' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar6' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada G</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco7' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar7' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada H</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco8' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar8' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada I</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco9' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar9' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada J</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco10' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar10' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada K</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco11' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar11' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada L</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco12' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar12' class='txtInfos' ></asp:TextBox>
     </div>
    
     <div id="divBilhetes2" runat="server" class="containerDropDown2">
         <Label runat="server">Bancada M</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco13' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar13' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada N</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco14' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar14' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada O</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco15' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar15' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada P</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco16' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar16' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada Q</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco17' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar17' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada R</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco18' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar18' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada S</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco19' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar19' class='txtInfos' ></asp:TextBox>
         <br/>

         <Label runat="server">Bancada T</Label>
         <asp:TextBox type='text' runat="server" placeholder='Preço' id='Preco20' class='txtInfos' ></asp:TextBox>
         <asp:TextBox type='text' runat="server" placeholder='Lugares' id='Lugar20' class='txtInfos' ></asp:TextBox>
     </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
