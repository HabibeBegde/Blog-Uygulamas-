<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blogum.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptMakale" runat="server">
        <ItemTemplate>
             <div class="well">
        <span><h3> <%#Eval("Baslik") %></h3><%#Eval("Tarih") %></span>
        <hr />
        <%#Eval("Ozet") %>
        <a class="btn btn-danger btn-block" href="Konu.aspx?url=<%#Eval("url") %>">Devamı</a>
    </div>
        </ItemTemplate>
    </asp:Repeater>
   
</asp:Content>
