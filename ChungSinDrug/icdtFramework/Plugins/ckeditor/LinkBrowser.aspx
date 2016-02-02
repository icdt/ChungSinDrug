<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkBrowser.aspx.cs" Inherits="icdtFramework.Plugins.ckeditor.LinkBrowser" StylesheetTheme="none"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><title>Link
    Browser</title>
    <style type="text/css">
        body { margin: 0; }
        
        form { width: 700px; background-color: #E3E3C7; }
        
        h1 { padding: 15px; margin: 0; padding-bottom: 0; font-family: Arial; font-size: 14pt; color: #737357; }
        
        .tab-panel .ajax__tab_body { background-color: #E3E3C7; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="_Content_ScriptManager" runat="server" />
    <h1>
        選擇附加檔案</h1>
    <br />
    <table width="95%" align="center" cellpadding="10" cellspacing="0" border="0" style="background-color: #F1F1E3;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        目錄名稱：<asp:DropDownList ID="DirectoryList" runat="server" Style="width: 160px;" OnSelectedIndexChanged="ChangeDirectory"
                            AutoPostBack="true" />
                        <asp:Button ID="DeleteDirectoryButton" runat="server" Text="刪除目錄" OnClick="DeleteFolder"
                            OnClientClick="return confirm('您確定要刪除此目錄嗎?? 刪除目錄連同檔案都會被刪除掉，是否確定!!');" />
                        <asp:HiddenField ID="NewDirectoryName" runat="server" />
                        <asp:Button ID="NewDirectoryButton" runat="server" Text="新增目錄" OnClick="CreateFolder" />
                        <br />
                        <br />
                        <asp:Panel ID="SearchBox" runat="server" DefaultButton="SearchButton">
                            搜尋目錄：<asp:TextBox ID="SearchTerms" runat="server" />
                            <asp:Button ID="SearchButton" runat="server" Text="開始搜尋" OnClick="Search" UseSubmitBehavior="false" />
                            <br />
                        </asp:Panel>
                        <asp:ListBox ID="ImageList" runat="server" Style="width: 98%; height: 220px;" OnSelectedIndexChanged="SelectImage"
                            AutoPostBack="true" />
                        <br />
                        <div style="text-align: right; height: 30px; margin: 10px 10px 0px 0px">
                            <asp:HiddenField ID="NewImageName" runat="server" />
                            <asp:Button ID="RenameImageButton" runat="server" Text="修改檔名" OnClick="RenameImage"
                                OnClientClick="return confirm('您確定要修改檔名嗎??');" />
                            <asp:Button ID="DeleteImageButton" runat="server" Text="刪除檔案" OnClick="DeleteImage"
                                OnClientClick="return confirm('您確定要刪除此檔案嗎??');" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <fieldset>
                    <legend>上傳檔案-(限單一檔案 10 MB)</legend>
                    <asp:FileUpload ID="UploadedImageFile" Width="80%" Height="25px" runat="server" />
                    <asp:Button ID="UploadButton" runat="server" Text="開始上傳" OnClick="Upload" />
                </fieldset>
            </td>
        </tr>
    </table>
    <div style="text-align: center; margin: 10px 0px 0px 0px;">
        <asp:Button ID="OkButton" runat="server" Text="選取檔案" OnClick="Clear" />
        <asp:Button ID="CancelButton" runat="server" Text="離開選取" OnClientClick="window.top.close(); window.top.opener.focus();"
            OnClick="Clear" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
