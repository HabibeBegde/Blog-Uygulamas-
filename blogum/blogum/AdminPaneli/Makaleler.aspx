<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Makaleler.aspx.cs" Inherits="blogum.AdminPaneli.Makaleler" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function TumunuSec(_check)
        {
            var mCheck = (_check.type == "checkbox") ? _check : _check.children.items[0];
            mDurum = mCheck.checked;
            mGrid = mCheck.form.elements;
            for (i = 0; i < mGrid.Length; i++)
                if (mGrid[i].type == "checkbox" && mGrid[i].id != mCheck.id)
                {
                    if (mGrid[i].checked != mDurum)
                        mGrid[i].click();

                }
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <asp:Button ID="btnGizleGoster" Text="Göster"  runat="server" OnClick="btnGizleGoster_Click" /><br />
                 <asp:Label  ID="lblDurum" runat="server" Text="" /><br />
                <asp:Panel ID="pnlMakale" Visible="false" runat="server">
                   
                
           
            <asp:TextBox ID="txtBaslik" placeHolder="Başlık Gir" width="840" runat="server" /> <br />
            <asp:TextBox ID="txtUrl" placeHolder="Url Gir" width="840" runat="server" /> <br />
            <asp:TextBox ID="txtOzet" placeHolder="Makalenin özetini gir" TextMode="Multiline"  width="840"  runat="server" Height="54px"/><br />
         <CKEditor:CKEditorControl ID="txtIcerik"  BasePath="/ckeditor/" width="840" runat="server"> Makaleni Yaz</CKEditor:CKEditorControl>
           <asp:DropDownList ID="drpKategori" runat="server"></asp:DropDownList><br />
            <asp:TextBox ID="txtEtiket" placeHolder="Etiket Gir" width="840" runat="server" > </asp:TextBox><br />
           <asp:CheckBoxList ID="cblEtiket" RepeatColumns="5" runat="server"></asp:CheckBoxList><br />
                    <asp:label ID="lblId" text="" runat="server" />
            <asp:Button ID="btnKaydet" text="Kaydet" runat="server" cssClass="btn btn-success" OnClick="btnKaydet_Click" />
                    <asp:Button ID="btnDuzenle" CssClass="btn btn-info" Text="Düzenle" runat="server" OnClick="btnDuzenle_Click" />
                    <asp:Button ID="btnBosalt" cssclass="btn btn-default" Text="Boşalt" runat="server" OnClick="btnBosalt_Click" />


               
                    </asp:Panel>
                <asp:Panel ID="pnlListe" runat="server">
                    <asp:GridView ID="gvMakale" runat="server" OnRowCreated="gvMakale_RowCreated">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="cbAll" type="checkbox" onclick="javascript : TumunuSec(this)" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSec" AutoPostBack="true" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnGvSectigimiDuzenle" cssclass="btn btn-warning" Text="Düzenle" runat="server" OnClick="btnGvSectigimiDuzenle_Click" />
                    <asp:Button id="btnSil" CssClass="btn btn-danger" Text="Sil" runat="server" OnClick="btnSil_Click" />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    

    
</asp:Content>
