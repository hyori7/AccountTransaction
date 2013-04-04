<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        account = $("#<%= hidden_account.ClientID %>").val();
        if (account == "1") {
            $('#first-account').hide();
        }
        if (account == "0") {
            $('#first-account').show();
        }
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="sub-container">
<div id="first-account">
<div>Welcome to our transcation services. Would you like to create an account now?</div>
<div><asp:Button ID="createBtn" runat="server" OnClick="createOnClick" Text="Yes"/></div>
</div>
<div id="user-account">
<div>
Account Name: <asp:Label ID="name" runat="server"></asp:Label>
</div>
<div>
Account Balance: $<asp:Label ID="balance" runat="server"></asp:Label>
</div>
</div>
<div>Search for user account: <asp:TextBox ID="search" runat="server"></asp:TextBox> <asp:Button ID="searchBtn" runat="server" OnClick="searchOnClick" Text="Search" /></div>
<div>
<asp:GridView ID="transaction" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:TemplateField HeaderText="From">
<ItemTemplate>
<div>
<asp:Label ID="from_name" runat="server" Text='<%# Eval("from_name") %>'></asp:Label>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To">
<ItemTemplate>
<div>
<asp:Label ID="to_name" runat="server" Text='<%# Eval("to_name") %>'></asp:Label>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount">
<ItemTemplate>
<div>
$<asp:Label ID="amount" runat="server" Text='<%# Eval("amount") %>' ></asp:Label>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Time">
<ItemTemplate>
<div>
<asp:Label ID="time" runat="server" Text='<%# Eval("time") %>'></asp:Label>
</div>
</ItemTemplate>
</asp:TemplateField>
</Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
</div>
<asp:HiddenField ID="hidden_account" runat="server" />
</div>
</asp:Content>

