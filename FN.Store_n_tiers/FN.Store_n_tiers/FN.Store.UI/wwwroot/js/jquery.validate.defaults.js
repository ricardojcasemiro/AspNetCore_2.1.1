/// <reference path="jquery-3.3.1.js" />
/// <reference path="jquery.validate.js" />

$.validator.setDefaults({
    highlight: function (el) {
        $(el).closest('.form-group')
            .find('input, label, select, textarea, span')
            .addClass('is-invalid');
    },
    unhighlight: function (el) {
        $(el).closest('.form-group')
            .find('input, label, select, textarea, span')
            .removeClass('is-invalid');
    }
});