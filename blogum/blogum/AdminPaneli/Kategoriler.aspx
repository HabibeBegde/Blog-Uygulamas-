<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="blogum.AdminPaneli.Kategoriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div style="text-align:center" class="well">
        <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList><br />
     Id:   <asp:Label ID="lblId" runat="server" Text=""></asp:Label> <br />
     Ad:   <asp:TextBox ID="txtAd" runat="server"></asp:TextBox> <br />
     Url:  <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox> <br />
     Sıra: <asp:TextBox ID="txtSira" runat="server"></asp:TextBox> <br />
        <asp:Button ID="btnKaydet" CssClass="btn btn-success" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
        <asp:Button ID="btnDuzenle" CssClass="btn btn-warning" runat="server" Text="Düzenle" OnClick="btnDuzenle_Click" />
        <asp:Button ID="btnSil" CssClass="btn btn-danger" runat="server" Text="Sil" OnClick="btnSil_Click" /> <br /> <br />
        <asp:Label ID="lblDurum" runat="server" Text=""></asp:Label>

    </div>


        </ContentTemplate>
    </asp:UpdatePanel>

   
</asp:Content>
