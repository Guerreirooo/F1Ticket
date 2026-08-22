<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarPP.aspx.cs" Inherits="PAP___F1_Ticket.AlterarPP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    margin-top: 8%;
    margin-left: 39%;
    background-color: #EEE;
    border-radius: 10px;
    width: 300px;
    height: 380px;
    padding: 1%;
}
        .check{
            height: 10px;
            width: 10px;
        }
        .link{
            text-decoration: none;
        }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:ChangePassword ID="ChangePassword1" runat="server" style="width: 100%;" >
                <ChangePasswordTemplate>
                                        <p align="center">
                                           <asp:Label runat="server" AssociatedControlID="CurrentPassword" ID="CurrentPasswordLabel">Palavra-passe</asp:Label>
                                        </p>
                    
                                        <p align="center">
                                            <asp:TextBox runat="server" TextMode="Password" ID="CurrentPassword"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Palavra-passe obrigat&#243;ria." ValidationGroup="ChangePassword1" ToolTip="Palavra-passe obrigat&#243;ria." ID="CurrentPasswordRequired">*</asp:RequiredFieldValidator>
                                        </p>
                                    
                                    
                                        <p align="center">
                                            <asp:Label runat="server" AssociatedControlID="NewPassword" ID="NewPasswordLabel">Nova Palavra-passe</asp:Label>
                                        </p>
                   
                                        <p align="center">
                                            <asp:TextBox runat="server" TextMode="Password" ID="NewPassword"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" ErrorMessage="Nova Palavra-passe &#233; obrigat&#243;rio." ValidationGroup="ChangePassword1" ToolTip="Nova Palavra-passe &#233; obrigat&#243;rio." ID="NewPasswordRequired">*</asp:RequiredFieldValidator>
                                        </p>
                                    
                                    
                                        <p align="center">
                                            <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword" ID="ConfirmNewPasswordLabel">Confirmar Nova Palavra-passe</asp:Label>
                                        </p>
                   
                                        <p align="center">
                                            <asp:TextBox runat="server" TextMode="Password" ID="ConfirmNewPassword"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirmar Nova Palavra-passe &#233; obrigat&#243;rio." ValidationGroup="ChangePassword1" ToolTip="Confirmar Nova Palavra-passe &#233; obrigat&#243;rio." ID="ConfirmNewPasswordRequired">*</asp:RequiredFieldValidator>
                                        </p>
                                    
                                    
                                        <p align="center" colspan="2">
                                            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" ForeColor="Red" ErrorMessage="A entrada de Confirmar Nova Palavra-passe tem de corresponder &#224; entrada de Nova Palavra-passe." Display="Dynamic" ValidationGroup="ChangePassword1" ID="NewPasswordCompare"></asp:CompareValidator>
                                        </p>
                                    
                                    
                                        <p align="center" colspan="2" style="color: Red;">
                                            <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                        </p>
                                   
                                    
                                        <p align="center">
                                            <asp:Button runat="server" CommandName="ChangePassword" Text="Alterar Palavra-passe" ValidationGroup="ChangePassword1" ID="ChangePasswordPushButton" Height="8%" Width="50%"></asp:Button>
                                        </p>
                                        <p align="center">
                                            <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" PostBackUrl="Perfil.aspx" ID="CancelPushButton" Height="8%" Width="50%"></asp:Button>
                                        </p>
                </ChangePasswordTemplate>
                <SuccessTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center">
                                         <asp:Label runat="server" >Alteração de Palavra-passe Concluída</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" >A palavra-passe foi alterada!</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" margin-top="15px">
                                        <asp:Button  PostBackUrl="~/Login.aspx" runat="server" CausesValidation="False" CommandName="Continue" Text="Continuar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
            </asp:ChangePassword>
        </div>
    </form>
</body>
</html>
