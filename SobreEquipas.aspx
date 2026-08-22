<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="SobreEquipas.aspx.cs" Inherits="PAP___F1_Ticket.SobreEquipas" %>
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
        .divEquipas {       
        display: flex;
        flex-wrap: wrap;
    height: 540px;
    width: 95%;
    margin-left: 2%;
    margin-top: 2%; 
    overflow-y: scroll;
    border-style: solid;
    border-color: red;
    border-bottom-width: 3px;
    border-top-width: 3px;
    border-right: 0px;
    border-left-width: 3px;
    border-image: linear-gradient(to right, red 100%, white 0%) 1;
    border-radius: 8px;
}
        .divEquipas::-webkit-scrollbar {
    width: 3px;
    background-color: white;
}

        .divEquipas::-webkit-scrollbar-thumb {
    background-color: black;
}
        .blue-border {
            margin-top: 1%;
            margin-left: 1%;
            margin-bottom: 1%;
            flex-direction: column;
  display: flex;
  width: 45%;
  height: 50%;
  border-top: 3px solid black;
  border-left: 3px solid black;
  border-right: 3px solid black;
  border-bottom: 3px solid black;
  background-color: white;
  border-radius: 8px;
}
    .btnVer {
    text-decoration: none;
    display: block;
    margin-left: 1%;
    margin-bottom: 1%;
    text-align: center;
    border-radius: 8px;
    height: 10%;
    width: 15%;
    color: black;
    background-color: #eeeeee;
    float: right;
    padding-top: 1%;
    box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.45);
}


    .nomeEquipa {
      display: flex;
      align-items: center;
      font-size: 1.2em;
      text-align: center;
      position: relative;
      border-bottom: 2px solid black;
      width: 100%;
      height: 15%;
      font-family: 'Tw Cen MT';
    }

    .nomeEquipa img {
      vertical-align: middle;
    }
    .divPilotos{
        display: flex; 
        align-items: center; 
        justify-content: space-between; 
        border-bottom: 2px solid black; 
        height: 12%;
    }
    .imgPilotos{
        vertical-align: middle;
        margin-left:2%; 
        height: 23px; 
        width: 44px;
    }
    .nomePilotos{
        position: relative; 
        font-size: 1.2em; 
        margin-left:2%; 
        width:50%; 
        font-family: 'Tw Cen MT';
    }
    .carro{
        display: block; 
        margin: 0 auto;
        width: 600px; 
        height: 175px;
    }
    .botoesAdmin {
            text-decoration: none;
            height: 30px;
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
        <img src="Images/SobreEquipas/SobreEquipas.png" style="vertical-align: middle; margin-left: 1%; height: 70px; width: 70px; margin-bottom: 8.8%;" />
        <label style="vertical-align: middle;">Sobre Equipas</label>
    </h1></div>

    <div id="botoesAdmin" runat="server" Visible="false" style="display: flex;">
         <asp:Button ID="editarPista" runat="server" class="botoesAdmin" Text="Editar Lista" style="margin-left: 80%; width: 15%; margin-top: -2%;" OnClick="editarPista_Click"/>
    </div>

    <div id="divEquipas" runat="server" class="divEquipas">
    </div>

</asp:Content>
