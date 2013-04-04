<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="register">
        <div>
            Username:
        </div>
        <div>
            <asp:TextBox ID="username" runat="server"></asp:TextBox></div>
        <div>
            Password:
        </div>
        <div>
            <asp:TextBox ID="password" runat="server"></asp:TextBox></div>
        <div>
            Name:
        </div>
        <div>
            <asp:TextBox ID="name" runat="server"></asp:TextBox></div>
        <div>
            Address:
        </div>
        <div>
            <asp:TextBox ID="address" runat="server"></asp:TextBox></div>
        <div>
            Phone:
        </div>
        <div>
            <asp:TextBox ID="phone" runat="server"></asp:TextBox></div>
        <div>
            Licence:
        </div>
        <div>
            <asp:TextBox ID="licence" runat="server"></asp:TextBox></div>
        <div>
            <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                CaptchaMaxTimeout="240" FontColor="#529E00" />
        </div>
        <div>
            <asp:TextBox ID="captcha_txt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="registerBtn" runat="server" OnClick="registerOnClick" Text="Register" /></div>
        <div id="register-error">
            <div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
            <div>
                <asp:Label ID="error_Length" runat="server"></asp:Label></div>
            <div>
                <asp:Label ID="error_Upper" runat="server"></asp:Label></div>
            <div>
                <asp:Label ID="error_Number" runat="server"></asp:Label></div>
            <div>
                <asp:Label ID="error_Symbol" runat="server"></asp:Label></div>
        </div>
    </div>
</asp:Content>
