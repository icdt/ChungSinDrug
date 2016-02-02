<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageBrowser.aspx.cs" Inherits="icdtFramework.Plugins.ckeditor.ImageBrowser" StylesheetTheme="none"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>圖片上傳
    </title>
    <style type="text/css">
        body {
            margin: 0;
            font-size: 12px;
        }

        form {
            width: 850px;
            background-color: #E3E3C7;
        }

        input {
            font-size: 12px;
        }

        h1 {
            padding: 15px;
            margin: 0;
            padding-bottom: 0;
            font-family: Arial;
            font-size: 14pt;
            color: #737357;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="_Content_ScriptManager" runat="server" />
        <h1>圖片管理</h1>
        <table width="800px" height="500px" cellpadding="10" cellspacing="0" border="0" style="background-color: #F1F1E3; margin: 15px;">
            <tr>
                <td style="width: 396px;" valign="middle" align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Image ID="Image1" runat="server" Style="max-height: 400px; max-width: 380px;" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 304px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            現有目錄：<asp:DropDownList ID="DirectoryList" runat="server" Style="width: 130px;" OnSelectedIndexChanged="ChangeDirectory"
                                AutoPostBack="true" />
                            <asp:Button ID="DeleteDirectoryButton" runat="server" Text="刪除" OnClick="DeleteFolder"
                                OnClientClick="return confirm('您確定要刪除此目錄嗎?? 目錄裡面所有的檔案會被全部刪除，如果有活動圖片有連結到此目錄將會連結不到而破圖。\n\n是否確定呢?? ');" />
                            <asp:HiddenField ID="NewDirectoryName" runat="server" />
                            <asp:Button ID="NewDirectoryButton" runat="server" Text="新增" OnClick="CreateFolder" />
                            <br />
                            <br />
                            <asp:Panel ID="SearchBox" runat="server" DefaultButton="SearchButton">
                                <fieldset>
                                    <legend>搜尋圖片：
                                    <asp:TextBox ID="SearchTerms" Width="150px" Height="16px" runat="server" /><asp:Button
                                        ID="SearchButton" runat="server" Text="開始搜尋" OnClick="Search" UseSubmitBehavior="false" /></legend>
                                    <asp:ListBox ID="ImageList" runat="server" Style="width: 100%; height: 180px;" OnSelectedIndexChanged="SelectImage"
                                        AutoPostBack="true" />
                                    <asp:HiddenField ID="NewImageName" runat="server" />
                                    <br />
                                    <div style="text-align: right; height: 30px; margin: 10px 10px 0px 0px">
                                        <asp:Button ID="RenameImageButton" runat="server" Text="修改檔案名稱" OnClick="RenameImage"
                                            OnClientClick="return confirm('您確定要改變此圖片名稱? 如果有活動圖片檔名被修改了，圖片將會破圖。');" />
                                        <asp:Button ID="DeleteImageButton" runat="server" Text="刪除此檔案" OnClick="DeleteImage"
                                            OnClientClick="return confirm('您確定要刪除此圖片嗎? 如果有活動圖片被連結卻被刪除，圖片將會破圖。');" />
                                    </div>
                                </fieldset>
                            </asp:Panel>
                            <br />
                            <br />
                            <fieldset>
                                <legend>修改圖示大小</legend>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>寬度：<asp:TextBox ID="ResizeWidth" runat="server" Width="50" OnTextChanged="ResizeWidthChanged" /><br />
                                            高度：<asp:TextBox ID="ResizeHeight" runat="server" Width="50" OnTextChanged="ResizeHeightChanged" />
                                            <asp:HiddenField ID="ImageAspectRatio" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="ResizeImageButton" runat="server" Text="修改圖示大小" OnClientClick="return confirm('您確定要修改此圖片大小嗎??修改後無法還原等比大小!!');"
                                                OnClick="ResizeImage" /></td>
                                    </tr>
                                </table>
                                <asp:Label ID="ResizeMessage" runat="server" ForeColor="Red" />
                            </fieldset>
                            <br />
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <br />
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
        <div style="text-align: center;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="OkButton" runat="server" Text="選取此圖" OnClick="Clear" />
                    <asp:Button ID="CancelButton" runat="server" Text="離開選取" OnClientClick="window.top.close(); window.top.opener.focus();"
                        OnClick="Clear" />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>

