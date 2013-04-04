<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="login">
<div>Username: <asp:TextBox ID="username" runat="server"></asp:TextBox></div>
<div>Password: <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></div>
<div><asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginOnClick" /> 
<asp:Button ID="register" runat="server" Text="Register" OnClick="registerOnClick" />
</div>
</div>
</asp:Content>

