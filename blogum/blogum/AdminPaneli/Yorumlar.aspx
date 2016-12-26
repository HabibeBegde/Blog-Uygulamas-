<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="blogum.AdminPaneli.Yorumlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <asp:Label Text="" ID="lblDurum" runat="server" />
    <asp:Repeater ID="rptYorum" runat="server">
        <ItemTemplate>
            <div class="well">
                <span>
                    <%#Eval("Ad") %> : <%#Eval("Tarih") %> //<%#Eval("Email") %></span><br /><span><%#Eval("icerik") %></span><br /><br /> 
                <a href="p.aspx?yo=<%#Eval("id") %>" class="btn btn-success">Onayla </a>
                <a href="p.aspx?ys=<%#Eval("id") %>" class="btn btn-warning">Sil </a>

               


            </div>


        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
