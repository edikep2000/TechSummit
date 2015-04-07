/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.extraPlugins = 'fmath_formula';
    config.extraPlugins = 'eqneditor';
    config.extraPlugins = 'eqneditor'

    config.toolbar = [
         ['Templates', 'Styles', 'Format', 'Font', 'FontSize', 'TextColor', 'BGColor', 'Maximize', 'Image'],
         ['Source', 'EqnEditor'],
         ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
         ['Table', 'HorizontalRule'],
         ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
         ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
    ];
};
