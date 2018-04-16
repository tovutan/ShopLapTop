/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.syntaxhighligh_lang = 'csharp';
    config.syntaxhighligh_hideControls = true;
    config.language = 'vi';
    config.entities_latin = false;
    config.filebrowserBrowserUrl = '/Assets/Admin/js/plugins/ckfinder/ckfinder.html';
    config.filebrowseImageBrowserUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowserUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';// chu y o dây
    //config.filebrowserUploadUrl = '/assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    //config.filebrowserImageUploadUrl = '/Assets/Images/';

    config.filebrowserImageUploadUrl = '/Assets/hinhanh/sanpham/';

    config.filebrowserFlashUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Assets/Admin/js/plugins/ckfinder/');
};
