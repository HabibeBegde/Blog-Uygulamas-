<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Konu.aspx.cs" Inherits="blogum.Konu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <span>
            <asp:Label ID="lblBaslik" runat="server" Font-Bold="True" Font-Size="Large" />
            <asp:Label ID="lblTarih" Text="" runat="server" />
        </span> <br /> <hr />
        <asp:Label ID="lblIcerik" Text="" runat="server" /><br />
        <asp:Repeater ID="rptEtiket" runat="server">
            <ItemTemplate>
                <a href="p.aspx?id=<%#Eval("id") %>" > <%#Eval("Ad") %> &nbsp;</a>
            </ItemTemplate>
        </asp:Repeater>
        <hr />


    </div>
    <asp:Label ID="lblYrmDurum" Text="" runat="server" />
    <asp:Repeater ID="rptYorum" runat="server">
        <ItemTemplate>
            <div class="well">
        <span>
           <%#Eval("Ad") %>
            <%#Eval("Tarih") %>
        </span> <br /> <hr />

        <%#Eval("Icerik") %>
       

    </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>   
            <div class="well">
        <asp:TextBox ID="txtAd" placeHolder="Adınız" width="300" runat="server" /><br />
        <asp:TextBox ID="txtEmail" placeHolder="Email adresiniz" Width="300" runat="server" /><br />
        <asp:TextBox ID="txtYorum" placeHolder="Yorumunuz" TextMode="MultiLine" Width="300" Height="200" runat="server" /><br />
        <asp:Button ID="btnGonder" Text="Gönder" cssclass="btn btn-success" runat="server" OnClick="btnGonder_Click" />
                <asp:Label ID="lblDurum" Text="" runat="server" />
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
