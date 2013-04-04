<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
        function goto(id) {
            document.location.href = "../Transaction/Transfer.aspx?user_id=" + id;

        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="sub-container">
<div>
Enter Name: <asp:TextBox ID="search" runat="server"></asp:TextBox> <asp:Button ID="searchBtn" runat="server" OnClick="searchOnClick" Text="Search"/>
</div>
<div>
<asp:GridView ID="account" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:TemplateField HeaderText="Username">
<ItemTemplate>
<div id="username-div">
<%#"<a href=\"javascript:goto('" + Eval("id") + "');\">" + Eval("username") + "</a>"%>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Account Name"><ItemTemplate>
<div id="name-div">
<%#"<a href=\"javascript:goto('" + Eval("id") + "');\">" + Eval("name") + "</a>"%>
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
</div>
</asp:Content>

