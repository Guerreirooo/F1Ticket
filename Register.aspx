<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PAP___F1_Ticket.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>F1 Ticket - Register</title>
    <link href="Themes/Register.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="users" runat="server" />
        <div class="container">
            <asp:CreateUserWizard ID="RegisterUser" runat="server" OnCreateUserButtonClick="CreateUserButton_Click" 
            OnCreatedUser="RegisterUser_CreatedUser" BackColor="#EEEEEE"
            Font-Size="10pt" Font-Names="Sans-serif" Height="250px" Width="300px">
            <ContinueButtonStyle BackColor="White" BorderColor="#C5BBAF"
                BorderStyle="Solid" BorderWidth="1px" />
            <CreateUserButtonStyle height="5%" Width="40%"/>
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
              <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                 <ContentTemplate>
                    <tr>
                          <td align="center">
                              <p>Email</p>
                              <asp:TextBox ID="Email" runat="server"/>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="Correio eletr&#243;nico necess&#225;rio." ValidationGroup="RegisterUser" ToolTip="Correio eletr&#243;nico necess&#225;rio." ID="EmailRequired">*</asp:RequiredFieldValidator>
                          </td>
                     </tr>
                     <tr>
                          <td align="center">
                              <p>Nome de Utilizador</p>
                              <asp:TextBox ID="UserName" runat="server" OnTextChanged="UserName_TextChanged"/>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="O Nome de Utilizador &#233; obrigat&#243;rio." ValidationGroup="RegisterUser" ToolTip="O Nome de Utilizador &#233; obrigat&#243;rio." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                              <br />
                              <asp:label id="labelTextBox" runat="server" style="color: red" ></asp:label>
                          </td>
                     </tr>
                     <tr>
                          <td align="center">
                              <p>Palavra-passe</p>
                              <asp:TextBox ID="Password" runat="server" TextMode="Password"/>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Palavra-passe obrigat&#243;ria." ValidationGroup="RegisterUser" ToolTip="Palavra-passe obrigat&#243;ria." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                          </td>
                     </tr>
                     <tr>
                          <td align="center">
                              <p>Confirmar Palavra-passe</p>
                              <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" OnTextChanged="Password_TextChanged"/>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="&#201; necess&#225;ria a Palavra-passe de Confirma&#231;&#227;o." ValidationGroup="RegisterUser" ToolTip="&#201; necess&#225;ria a Palavra-passe de Confirma&#231;&#227;o." ID="ConfirmPasswordRequired">*</asp:RequiredFieldValidator>
                              <br />
                              <asp:label id="labelPassword" runat="server" style="color: red" ></asp:label>
                          </td>
                     </tr>
                     <tr>
                          <td align="center" style="color: Red; max-height: 30px; padding-top: 5px;">
                              <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="A Palavra-passe e a Palavra-passe de Confirma&#231;&#227;o t&#234;m de ser iguais." Display="Dynamic" ValidationGroup="RegisterUser" ID="PasswordCompare"></asp:CompareValidator>
                          </td>
                     </tr>
                 </ContentTemplate>
              </asp:CreateUserWizardStep>
            </WizardSteps>
       </asp:CreateUserWizard>
            <p align="center">Já tem conta criada? <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/Login.aspx" Text="Login" Class="link" /></p>
        </div>
    </form>
</body>
</html>