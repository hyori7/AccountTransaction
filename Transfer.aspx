<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Transfer.aspx.cs" Inherits="Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="sub-container">
<div>
From: <asp:label ID="from" runat="server"></asp:label>
</div>
<div>
To: <asp:Label ID="to" runat="server"></asp:Label>
</div>
<div>
Amount: $<asp:TextBox ID="balance" runat="server"></asp:TextBox>
</div>
<div>
<asp:Button ID="confirm" runat="server" OnClick="confirmOnClick" Text="Confirm" />
</div>
<asp:HiddenField ID="target_id" runat="server" />
</div>
</asp:Content>

