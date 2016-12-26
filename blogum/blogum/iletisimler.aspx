<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="iletisimler.aspx.cs" Inherits="blogum.iletisimler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

                 <div class="well">
        <asp:TextBox ID="txtAd" placeHolder="Adınız" width="300" runat="server" /><br />
        <asp:TextBox ID="txtEmail" placeHolder="Email adresiniz" Width="300" runat="server" /><br />
        <asp:TextBox ID="txticerik" placeHolder="Yorumunuz" TextMode="MultiLine" Width="300" Height="200" runat="server" /><br />
        <asp:Button ID="btnGonder" Text="Gönder" cssclass="btn btn-success" runat="server" OnClick="btnGonder_Click" />
                <asp:Label ID="lblDurum" Text="" runat="server" />
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
