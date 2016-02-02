/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.toolbar = 'Full';
    config.toolbar_Full = [
       ['Source', 'Maximize'],
       ['NumberedList', 'BulletedList', '-', 'Bold', 'Italic', 'Underline', 'Strike', '-', 'Outdent', 'Indent', 'Blockquote'],
       ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
       ['Link', 'Unlink', 'Image', 'Table'],
       '/',
       ['Styles', 'Format', 'Font', 'FontSize'],
       ['TextColor', 'BGColor']
    ];

    //config.extraPlugins = 'video';
    config.toolbarStartupExpanded = true;
    config.allowedContent = true;
    config.height = 400;
    config.filebrowserImageBrowseUrl = CKEDITOR.basePath + "ImageBrowser.aspx";
    config.filebrowserImageWindowWidth = 850;
    config.filebrowserImageWindowHeight = 730;
    config.filebrowserBrowseUrl = CKEDITOR.basePath + "LinkBrowser.aspx";
    config.filebrowserWindowWidth = 850;
    config.filebrowserWindowHeight = 730;
    config.filebrowserVideoBrowseUrl = CKEDITOR.basePath + "LinkBrowser.aspx";
    config.font_names = '新細明體;標楷體;微軟正黑體;' + config.font_names;
};
