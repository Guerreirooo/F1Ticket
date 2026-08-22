<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PAP___F1_Ticket.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>F1 Ticket</title>
    <link href="Themes/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Login ID="loginUser" runat="server" CreateUserText="Register"
                CreateUserUrl="~/Register.aspx"
                OnAuthenticate="loginUser_Authenticate" BackColor="#EEEEEE"
                BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="0px"
                Font-Names="Sans-serif" Font-Size="10pt" Height="250px" Width="300px" TextLayout="TextOnTop">
                <CheckBoxStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <InstructionTextStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <LabelStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <LayoutTemplate>
                    <p align="center"><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nome de Utilizador</asp:Label></p>
                    <p align="center">
                        <asp:TextBox ID="UserName" runat="server" />
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="O Nome de Utilizador é obrigatório." ToolTip="O Nome de Utilizador é obrigatório." ValidationGroup="loginUser" class="obg">*</asp:RequiredFieldValidator></p>
                    <p align="center"><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Palavra-passe</asp:Label></p>
                    <p align="center"><asp:TextBox ID="Password" runat="server" TextMode="Password" class="box"/>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Palavra-passe obrigatória." ToolTip="Palavra-passe obrigatória." ValidationGroup="loginUser" class="obg">*</asp:RequiredFieldValidator></p>

                    <p class="Aviso"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></p>
                    <br />
                    <p align="center"><asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar Sessão" Class="btn" ValidationGroup="loginUser" Height="5%" Width="40%" /></p>

                    
                    <p align="center">Ainda não tens conta? <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/Register.aspx" Text="Registar" Class="link" /></p>

                </LayoutTemplate>
                <FailureTextStyle HorizontalAlign="Center" />
                <TextBoxStyle BorderStyle="None"/>
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:Login>
        </div>
    </form>
</body>
</html>
