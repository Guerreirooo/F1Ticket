<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="PAP___F1_Ticket.FinalizarCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>F1 Ticket</title>
    <link href="Themes/Login.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            display: block;
            padding: 0;
            margin: 0;
            height: 100vh;
            overflow: hidden;
            background-image: url('../Images/Login/F1Login.png');
            background-size: 100%;
        }
        .container {
    position: relative;
    margin-top: 10%;
    margin-left: 35%;
    background-color: #EEE;
    border-radius: 10px;
    width: 400px;
    height: 300px;
    padding: 1%;
    display: flex;
    justify-content: center;
}
    .txt3
    {
        max-width: 18ch;
    }
    .txt4
    {
        max-width: 6ch;
    }
    .txt5
    {
        max-width: 3ch;
    }
    .error-message
    {
        color: red;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
       <ContentTemplate> 
         <div class="container" runat="server" id="divContainer">
          <div id="idInfo" runat="server" style="height: 100%; width: 100%;">
             <p>
               <asp:label id="lblConfirma" style="display: block; font-size: 1.5em;" runat="server"></asp:label>
             </p>
             <p>
               <asp:label id="lblTC" runat="server">Titular do cartão</asp:label>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="error-message" runat="server" ErrorMessage="Tem de preencher todos os campos" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
             </p>
             <p>
               <asp:label id="lblNC" runat="server">Numero do cartão</asp:label>
               <asp:TextBox ID="TextBox2" class = "txt3" runat="server"></asp:TextBox> <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="error-message" runat="server" ErrorMessage="Tem de preencher todos os campos" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
             </p>
             <p>
               <asp:label id="lblDV" runat="server">Data Validade</asp:label>
               <asp:TextBox ID="TextBox3" class = "txt4" runat="server"></asp:TextBox> <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" class="error-message" runat="server" ErrorMessage="Tem de preencher todos os campos" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
             </p>
             <p>
               <asp:label id="lblCVV" runat="server">CVV</asp:label>
               <asp:TextBox ID="TextBox4" class = "txt5" runat="server"></asp:TextBox> <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" class="error-message" runat="server" ErrorMessage="Tem de preencher todos os campos" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
             </p>
             <p>
               <asp:Button style="font-size: 1em;" runat="server" Text="Pagar" ID="btnConfirma" Height="15%" Width="20%" OnClick="btnConfirma_Click"></asp:Button> <asp:Button  ID="btnCancelar" style="font-size: 1em;" runat="server" Text="Cancelar" PostBackUrl="Carrinho.aspx" Height="15%" Width="20%" OnClick="btnCancelar_Click"></asp:Button>
             </p>
          </div>
        </div>
      </ContentTemplate>
     </asp:UpdatePanel> 
    </form>
</body>
</html>
