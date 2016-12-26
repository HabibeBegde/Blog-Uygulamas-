<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blogum.AdminPaneli.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlGiris" runat="server">
        <div style="text-align:center">
            <asp:TextBox ID="txtAd" runat="server" /> <br /> 
            <asp:TextBox ID="txtSifre" TextMode="Password" runat="server" /> <br /> 
            <asp:Label ID="lblHata" Text=""  runat="server" /> <br /> 
            <asp:Button ID="btnGiris" Text="Giris" runat="server" OnClick="btnGiris_Click" />

        </div>

    </asp:Panel>
    <asp:Panel ID="pnlMenu" runat="server">
        <a href="Kategoriler.aspx" class="btn btn-warning" > Kategori </a>
        <a href="Etiketler.aspx" class="btn btn-info" > Etiket </a>
        <a href="iletisimler.aspx" class="btn btn-success"> İletisim </a>
    <a href="Yorumlar.aspx" class="btn btn-default"> Yorumlar </a>
    <a href="Makaleler.aspx" class="btn btn-danger"> Makaleler </a>

    

    

    </asp:Panel>
</asp:Content>
