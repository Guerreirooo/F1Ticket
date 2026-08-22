<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="EditarPista.aspx.cs" Inherits="PAP___F1_Ticket.Admin.EditarPista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .navbart{
         margin-top: -6.6%;
     }
        .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 22%;
    margin-top: 6.6%;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 0px;
    border-left-width: 0px;
    border-right-width: 0px;
    align-items: center;   
}
        .containerAdicionar,
        .containerEditar,
        .containerRemover {
            display: inline-block;
            width: 30%;
            vertical-align: top;
        }
        .containerAdicionar{
            margin-left: 2%;
        }
        .containerEditar {
            margin-left: 2%;
        }

        .containerRemover {
            margin-left: 4%;
        }

        .botoesConfirmar{
            display: block;
            padding: 10px;
        }

       .btnInfos {
            position: relative;
            height: 3em;
            font-size: 0.9em;
            background-color: #eeeeee;
            border: none;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
        }
         .btnInfos:hover {
            cursor: pointer;
        background-color: lightgrey;
        transition-delay: 0.1s;
        }
        .botoesRemover {
        display: flex;
        justify-content: center;
        margin-top: 10px;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divPistas"><h1 style="width: 100%; margin-left: 1%;">
        <label style="vertical-align: middle;">Editar Lista de Pistas</label>
    </h1></div>
     
     <div runat="server" id="divAdicionar" class="containerAdicionar">
         <h2>Adicionar Pista</h2>

         <h4>Nome Simplificado</h4>
         <asp:TextBox ID="txtNomeSimples" runat="server"></asp:TextBox>

         <h4>Nome Completo (Tudo CAPS LOCK)</h4>
         <asp:TextBox ID="txtNomeCompletoAdicionar" runat="server"></asp:TextBox>
         
         <h4>Começa a : </h4>
         <asp:TextBox ID="dataInicioAdicionar" runat="server" CssClass="data" TextMode="Date"></asp:TextBox>
   
         <h4>Acaba a : </h4>
         <asp:TextBox ID="dataFimAdicionar" runat="server" CssClass="data" TextMode="Date"></asp:TextBox>

         <h4>Bandeira País (62x40)</h4>
         <asp:FileUpload ID="fileBandeiraAdicionar" runat="server" />

         <h4>Imagem Bancadas</h4>
         <asp:FileUpload ID="fileBancadaAdicionar" runat="server" />

         <asp:label id="lblSucessoAdicionar" runat="server" style="color: green;" visible="false" Text="Pista Adicionada com Sucesso" Font-Size="9pt"></asp:label>

         <br />
         <br />

         <asp:button id="btnGuardarAdd" runat="server" class="btnInfos" onclick="guardarAdd_Click" Text="Adicionar" style="margin-left: 22%;"></asp:button>
        
     </div>

     <div runat="server" id="divEditar" class="containerEditar">
          <h2>Editar Pista</h2>

         <h4>Qual Pista deseja editar ?</h4>
         <asp:DropDownList ID="SelectPistaEditar" runat="server" AutoPostBack="true" style="width: 25%; height: 30px;">
         </asp:DropDownList>

         <h4>Nome Completo (Tudo CAPS LOCK)</h4>
         <asp:TextBox ID="txtNomeCompletoEditar" runat="server" style="width: 40%;"></asp:TextBox>

         <h4>Começa a : </h4>
         <asp:TextBox ID="dataInicioEditar" runat="server" TextMode="Date"></asp:TextBox>
   
         <h4>Acaba a : </h4>
         <asp:TextBox ID="dataFimEditar" runat="server" TextMode="Date"></asp:TextBox>

         <h4>Bandeira País (62x40)</h4>
         <asp:FileUpload ID="fileBandeiraEditar" runat="server" />

         <h4>Imagem Bancadas</h4>
         <asp:FileUpload ID="fileBancadaEditar" runat="server" />
         
         <asp:label id="lblSucessoEditar" runat="server" style="color: green; margin-left: 5%;" visible="false" Text="Pista Editada com Sucesso" Font-Size="9pt"></asp:label>
         <br />
         <br />
         
         <asp:button id="btnGuardarEdit" runat="server" class="btnInfos" onclick="guardarEdit_Click" Text="Editar" style="margin-right: 5%; width: 15%;"></asp:button>
         <asp:button id="btnCenter" runat="server" class="btnInfos" onclick="cancelar_Click" Text="Cancelar"></asp:button>
     </div>

     <div runat="server" id="divRemover" class="containerRemover">
          <h2>Remover Pista</h2>

         <h4>Qual Pista deseja remover ?</h4>
         <asp:DropDownList ID="SelectPistaRemover" runat="server" AutoPostBack="true" style="width: 25%; height: 30px;">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Label runat="server" id="confirmaPista" ForeColor="Red" Font-Size="12pt"></asp:Label>
         <br />
         
         <asp:button id="btnLeft" runat="server" class="btnInfos" onclick="guardarRemover_Click" Text="Remover"></asp:button>
     </div>
</asp:Content>
