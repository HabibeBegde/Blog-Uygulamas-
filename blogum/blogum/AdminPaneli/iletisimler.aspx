<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="iletisimler.aspx.cs" Inherits="blogum.AdminPaneli.iletisimler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
   
    <asp:Button Text="Gördüklerimi sil" cssclass="btn btn-warning btn-block" runat="server" OnClick="Unnamed1_Click" /> <br /> <br />
     <asp:Label Text="" ID="lblDurum" runat="server" />
    <asp:Repeater ID="rptiletisim" runat="server">
        <ItemTemplate>
            <div class="well">
                <span>
                    <%#Eval("Ad") %> : <%#Eval("Tarih") %> //<%#Eval("Email") %></span><br /><span><%#Eval("Mesaj") %></span><br /><br />
                <a href="q.aspx?ic=<%#Eval("id") %>" class="btn btn-success">Görüntüle </a>
               


            </div>


        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
