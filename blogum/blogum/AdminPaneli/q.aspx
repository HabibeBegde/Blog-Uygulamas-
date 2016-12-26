<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="q.aspx.cs" Inherits="blogum.AdminPaneli.q" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="well">
       Ad:   <asp:Label ID="lblAd" Text ="" runat="server" />
       Tarih:  <asp:Label ID="lblTarih" Text="" runat="server" /> 
       e-Mail:  <asp:Label ID="lblMail" Text="" runat="server" /> 
         <hr />  
         <asp:Label ID="lblMesaj" Text="" runat="server" />
         <hr />

            </div>
    <div class="well">
        <table class="col-lg-8">
            <tr>
                <td>Mesaj Konusu </td>
                <td>
                    <asp:TextBox ID="txtMKonu"  Width="500px" runat="server" />
                </td>
            </tr>
            <tr>
            <td> Mesaj İçerik</td>
            <td>
                <asp:TextBox ID="txtMesaj" TextMode="MultiLine" Width="500px" Height="150px" runat="server" />
            </td>
                </tr>
            <tr>
                <td colspan="2" style="text-align:right">
                    <asp:Button ID="btnGonder" CssClass="btn btn-success" Text="Gönder" runat="server" OnClick="btnGonder_Click" />
                    <asp:Button ID="btnSil" CssClass="btn btn-danger" Text="Sil" runat="server" OnClick="btnSil_Click" />

                </td>
            </tr>

        </table>

    </div>
</asp:Content>
