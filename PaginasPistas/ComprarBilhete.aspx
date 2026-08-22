<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="ComprarBilhete.aspx.cs" Inherits="PAP___F1_Ticket.ComprarBilhete" %>
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
        .divBilhetes {
    height: 100%;
    width: 40%;
    margin-top: 0.5%;
    overflow-y: scroll;
    border-style: solid;
    border-color: red;
    border-radius: 8px;
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
    background-color: #eeeeee;
    justify-content: space-between;
    align-items: center;
    padding: 10px;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.3);
}

.divBilhetes::-webkit-scrollbar {
    width: 3px;
    background-color: white;
}

.divBilhetes::-webkit-scrollbar-thumb {
    background-color: black;
}

.btnComprar {
    display: block;
    text-align: center;
    border-radius: 8px;
    height: 40%;
    width: 17%;
    color: black;
    background-color: #eeeeee;
}

    .btnComprar:hover {
        background-color: red;
        color: white;
        border: none;
    }
    .option{
        width: 100%;
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .btnAdicionar{
        float: right; 
        font-size: 80%;
        margin-top: 1%; 
        border-radius: 8px;
        height: 2em;
    }
    .btnAdicionar:hover {
        background-color: red;
        color: white;
        border: none;
        transition-delay: 0.1s;
    }
    .rotate {
        transform: rotate(90deg);
    }
    .option {
        transition: transform 0.3s ease-in-out;
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
        left: 36%;
        right: 0;
        border-radius: 8px;
        display: flex;
        flex-direction: column;
    }
    .btnCarrinho{
        border-radius: 8px;
        font-size: 85%;
        height: 3em;
        position: fixed;
        bottom: 30%;
        right: 5%;
    }
    .btnCarrinho:hover {
        background-color: red;
        color: white;
        border: none;
        transition-delay: 0.1s;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%;">
        <asp:Image ID="imgBandeira" runat="server" Style="vertical-align: middle;" />
        <label id="lblNomeCorrida" runat="server" style="vertical-align: middle;"></label>
    </h1></div>
    
    
    
    
    <div class="divisor">
     <!--Imagem Lado Esquerdo -->
    <div style ="width: 54%; text-align: center; display: flex; justify-content: center; align-items: center; height: 60vh;"><asp:Image ID="imgBancadas" runat="server" Style="margin-left: 1%; max-width: 100%; height: auto; object-fit: contain;"/></div> <br />
    <!--Div Legenda Embaixo -->
    <div class="legenda">
        <b style="margin-left: 1%;">LEGENDA</b>
        <div style="display: flex;">
        <img src="ImagensLegenda/Bancada.png" / style="height: 10px; width: 35px; margin-top: 11%; padding: 0px 8px;"> <h5> - Bancadas</h5>
        </div>
        <div style="display: flex;">
        <img src="ImagensLegenda/EcraGigante.png" style="height: 5px; width: 23px; margin-top: 3%; padding: 0px 8px;" /> <h5 style="margin-top: -0.1%;"> - Ecrãs Gigantes</h5>
        </div>
    </div>

     <!--Tabela Bilhetes Lado Direito -->
    <div class="divBilhetes">
        <div class="box">

            <div class="option" id="treinos" style="font-weight: bold; font-size: 1.5em;">
                Treinos 
            </div>
        </div>
        
<!--Compra Bilhete Treinos -->
      <div class="box" id="treinos-content" style="font-size: 1.2em;">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
          <ContentTemplate> 
          <asp:Button id="maisT" runat="server" Text="+" OnClick="MaisT_Click"/>
          <label id="contadorT" runat="server"></label> 
          <asp:Button id="menosT" runat="server" Text="-" OnClick="MenosT_Click"/>
          <label>Bilhetes</label>  
          <asp:Button class="btnAdicionar" id="btnAdicionarT" runat="server" Text="Adicionar ao Carrinho" OnClick="btnAtualizarT_Click"/> <br /> 

                Bancada
                 <asp:DropDownList ID="selectElementT" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectElementT_SelectedIndexChanged">
                 </asp:DropDownList>
        
                 <label id="lblLugaresT" style="display: block; margin-top: -3.5%; margin-left: 20%;" runat="server"></label>
                 <label id="lblValorT" style="text-align: center; display: block; margin-top: -8%; margin-left: 27%;" runat="server"></label> <br />

          </ContentTemplate>
        </asp:UpdatePanel>
       </div>
         
        <div class="box">

            <div class="option" id="qualificacao" style="font-weight: bold; font-size: 1.5em;">
                Qualificação
            </div>
        </div>

<!--Compra Bilhete Qualificação -->
         <div class="box" id="qualificacao-content" style="font-size: 1.2em;">

          <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

              <asp:Button id="maisQ" runat="server" Text="+" OnClick="MaisQ_Click"/> 
              <label id="contadorQ" runat="server"></label> 
              <asp:Button id="menosQ" runat="server" Text="-" OnClick="MenosQ_Click"/> 
              <label>Bilhetes</label>
              <asp:Button id="btnAdicionarQ" class="btnAdicionar" OnClick="btnAtualizarQ_Click" runat="server" Text="Adicionar ao Carrinho"/> <br />
            
                    Bancada
                     <asp:DropDownList ID="selectElementQ" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectElementQ_SelectedIndexChanged">
                     </asp:DropDownList>
                        
                     <label id="lblLugaresQ" style="display: block; margin-top: -3.5%; margin-left: 20%;" runat="server"></label>
                     <label id="lblValorQ" style="text-align: center; display: block; margin-top: -8%; margin-left: 27%;" runat="server"></label> <br />    
    
             </ContentTemplate>
            </asp:UpdatePanel>
          </div>

        <div class="box">
            
            <div class="option" id="corrida" style="font-weight: bold; font-size: 1.5em;">
                Corrida
            </div>  
        </div>

<!--Compra Bilhete Corrida -->
         <div class="box" id="corrida-content" style="font-size: 1.2em;">

          <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
           <ContentTemplate>

             <asp:Button id="maisC" runat="server" Text="+" OnClick="MaisC_Click"/>
             <label id="contadorC" runat="server"></label> 
             <asp:Button id="menosC" runat="server" Text="-" OnClick="MenosC_Click"/>
             <label>Bilhetes</label>
             <asp:Button id="btnAdicionarC" class="btnAdicionar" OnClick="btnAtualizarC_Click" runat="server" Text="Adicionar ao Carrinho"/> <br />

                    Bancada 
                     <asp:DropDownList ID="selectElementC" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectElementC_SelectedIndexChanged">
                     </asp:DropDownList>
                         
                     <label id="lblLugaresC" style="display: block; margin-top: -3.5%; margin-left: 20%;" runat="server"></label>
                     <label id="lblValorC" style="text-align: center; display: block; margin-top: -8%; margin-left: 27%;" runat="server"></label> <br />
    
            </ContentTemplate>
           </asp:UpdatePanel>
         </div>

        <div class="box">
           
              <div class="option" id="fim-de-semana" style="font-weight: bold; font-size: 1.5em;">
                  Fim de semana Completo
              </div>   
        </div>

<!--Compra Bilhete Fim de Semana -->
         <div class="box" id="fim-de-semana-content" style="font-size: 1.2em;"> 

          <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
           <ContentTemplate>

             <asp:Button id="maisFDS" runat="server" Text="+" OnClick="MaisFDS_Click"/> 
             <label id="contadorFDS" runat="server">0</label> 
             <asp:Button id="menosFDS" runat="server" Text="-" OnClick="MenosFDS_Click"/>  
             <label>Bilhetes</label>
             <asp:Button id="btnAdicionarFDS" class="btnAdicionar" OnClick="btnAtualizarFDS_Click" runat="server" Text="Adicionar ao Carrinho"/> <br />

                    Bancada
                     <asp:DropDownList ID="selectElementFDS" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectElementFDS_SelectedIndexChanged">
                     </asp:DropDownList>
                         
                     <label id="lblLugaresFDS" style="display: block; margin-top: -3.5%; margin-left: 20%;" runat="server"></label>
                     <label id="lblValorFDS" style="text-align: center; display: block; margin-top: -8%; margin-left: 27%;" runat="server"></label> <br />
 
             </ContentTemplate>
            </asp:UpdatePanel>
          </div>

    </div>
        <input type="hidden" id="hiddenNomePista" runat="server"/>

    <script src="../Script/Bilhetes.js"></script>
    </div>
</asp:Content>