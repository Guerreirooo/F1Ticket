<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="SobrePilotos.aspx.cs" Inherits="PAP___F1_Ticket.SobrePilotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
     .navbart{
         margin-top: -6.6%;
     }
     .divPistas {
            margin-left: 1%;
    display:flex;
    height: 50px;
    width: 25%;
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
    width: 98%;
    margin-left: 1%;
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
  width: 23%;
  height: 50%;
  border-top: 3px solid black;
  border-left: 3px solid black;
  border-right: 3px solid black;
  border-bottom: 3px solid black;
  background-color: white;
  border-radius: 8px;
}
    .btnVer {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    position: relative;
    text-decoration: none;
    margin-top: 2%;
    margin-left: 1%;
    margin-bottom: 2%;
    color: black;
    overflow: hidden;
}

.btnVer::before {
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

.btnVer:hover::before {
    width: 20%;
}

    .divNomeEquipa {
        display: flex; 
        align-items: center; 
        justify-content: space-between; 
        border-bottom: 2px solid black;
        height: 12%;
        font-family: "Tw Cen MT";
    }


    .divNomePiloto{
        display: flex; 
        align-items: center; 
        justify-content: space-between; 
        border-top: 2px solid black;
        border-bottom: 2px solid black;
        height: 12%;
        font-family: "Tw Cen MT";
    }
    .imgPilotos{
        vertical-align: middle;
        margin-left: 2%; 
        height: 23px; 
        width: 40px;
    }
    .nomePilotos{
        position: relative; 
        font-size: 1.1em;
        text-align: right;
        margin-right: 3%; 
        width:100%; 
    }
    .foto{
        display: block; 
        margin: 10px auto 0;
        width: 130px; 
        height: 150px; 
        margin-bottom: 1px;
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
        <img src="Images/SobrePilotos/HamiltonEVettel.png" style="vertical-align: middle; margin-left: 1%; height: 65px; width: 82px; margin-bottom: 5.8%;" />
        <label style="vertical-align: middle;">Sobre Pilotos</label>
    </h1></div>

    <div id="botoesAdmin" runat="server" Visible="false" style="display: flex;">
        <asp:Button ID="editarPista" runat="server" class="botoesAdmin" Text="Editar Lista" style="margin-left: 80%; width: 15%; margin-top: -2%;" OnClick="editarPista_Click"/>
    </div>

    <div id="divEquipas" runat="server" class="divEquipas">    
    </div>

</asp:Content>
