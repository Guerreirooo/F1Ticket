<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="EditarPilotos.aspx.cs" Inherits="PAP___F1_Ticket.Admin.EditarPilotos" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="divPistas"><h1 style="width: 100%; margin-left: 1%;">
        <label style="vertical-align: middle;">Editar Lista de Pilotos</label>
    </h1></div>
     
     <div runat="server" id="divAdicionar" class="containerAdicionar">
         <h4>Nome</h4>
         <asp:TextBox ID="txtNomeAdicionar" runat="server"></asp:TextBox>

         <h4>Nacionalidade</h4>
         <asp:TextBox ID="txtNacionalidadeAdicionar" runat="server"></asp:TextBox>

         <h4>Piloto na :</h4>
         <asp:DropDownList ID="selectEquipaAdicionar" runat="server" AutoPostBack="true" style="width: 60%; height: 30px;">
         </asp:DropDownList>

         <h4>Idade</h4>
         <asp:TextBox ID="txtIdadeAdicionar" runat="server"></asp:TextBox>
         
         <h4>Pódios</h4>
         <asp:TextBox ID="txtPodiosAdicionar" runat="server"></asp:TextBox>
   
         <h4>Vitórias</h4>
         <asp:TextBox ID="txtVitoriasAdicionar" runat="server"></asp:TextBox>

         <h4>Ano Debut</h4>
         <asp:TextBox ID="txtAnoDebutAdicionar" runat="server"></asp:TextBox>

         <h4>Corridas Feitas</h4>
         <asp:TextBox ID="txtCorridasFeitasAdicionar" runat="server"></asp:TextBox>

         <h4>Bandeira País (62x40)</h4>
         <asp:FileUpload ID="fileBandeiraAdicionar" runat="server" />

         <h4>PreSet</h4>
         <asp:FileUpload ID="filePreSetAdicionar" runat="server" />

         <h4>Foto</h4>
         <asp:FileUpload ID="fileFotoAdicionar" runat="server" />

         <asp:label id="lblSucessoAdicionar" runat="server" style="color: green;" visible="false" Text="Pista Adicionada com Sucesso" Font-Size="15pt"></asp:label>   
         <br />
         <br />
         <asp:button id="btnAdicionar" runat="server" class="btnInfos" onclick="guardarAdd_Click" Text="Adicionar" style="margin-right: 10%;"></asp:button>
     </div>

     <div runat="server" id="divEditar" class="containerEditar">
         <h4>Qual Piloto deseja editar ?</h4>
         <asp:DropDownList ID="SelectPilotoEditar" runat="server" AutoPostBack="true" style="width: 40%; height: 30px;">
         </asp:DropDownList>

         <h4>Nacionalidade</h4>
         <asp:TextBox ID="txtNacionalidadeEditar" runat="server"></asp:TextBox>

         <h4>Piloto na :</h4>
         <asp:DropDownList ID="selectEquipaEditar" runat="server" style="width: 60%; height: 30px;">
         </asp:DropDownList>
   
         <h4>Idade</h4>
         <asp:TextBox ID="txtIdadeEditar" runat="server"></asp:TextBox>

         <h4>Pódios</h4>
         <asp:TextBox ID="txtPodiosEditar" runat="server"></asp:TextBox>

         <h4>Vitórias</h4>
         <asp:TextBox ID="txtVitoriasEditar" runat="server"></asp:TextBox>

         <h4>Corridas Feitas</h4>
         <asp:TextBox ID="txtCorridasFeitasEditar" runat="server"></asp:TextBox>

         <h4>Bandeira País (62x40)</h4>
         <asp:FileUpload ID="fileBandeiraEditar" runat="server" />

         <h4>PreSet</h4>
         <asp:FileUpload ID="filePreSetEditar" runat="server" />

         <h4>Foto</h4>
         <asp:FileUpload ID="fileFotoEditar" runat="server" />
         
         <asp:label id="lblSucessoEditar" runat="server" style="color: green; margin-left: 5%;" visible="false" Text="Piloto Editado com Sucesso" Font-Size="15pt"></asp:label>
         <br />
         <br />
         <asp:button id="btnEditar" runat="server" class="btnInfos" onclick="guardarEdit_Click" Text="Editar" style="margin-right: 10%; width: 15%;"></asp:button>
          <asp:button id="btnCancelar" runat="server" class="btnInfos" onclick="cancelar_Click" Text="Cancelar"></asp:button>
       </div>

     <div runat="server" id="divRemover" class="containerRemover">
         <h4>Qual Piloto deseja remover ?</h4>
         <asp:DropDownList ID="SelectPilotoRemover" runat="server" AutoPostBack="true" style="width: 40%; height: 30px;">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Label runat="server" id="confirmaPista" ForeColor="Red" Font-Size="12pt"></asp:Label>
         <br />
         <asp:label id="lblSucessoRemover" runat="server" style="color: green; margin-left: 5%;" visible="false" Text="Piloto Removido com Sucesso" Font-Size="15pt"></asp:label>

         <asp:button id="btnRemover" runat="server" class="btnInfos" onclick="guardarRemover_Click" Text="Remover"></asp:button>
     </div>
</asp:Content>
