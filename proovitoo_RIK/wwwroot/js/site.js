// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#customRadioInline2").click(function () {
        $("#legalEntity").removeClass("d-none");
        $("#legalEntity :input").val('');
        $("#person").addClass("d-none");
        $("#person :input").val('');
        $('#customRadioInline1').prop("checked", false)
    });

    $("#customRadioInline1").click(function () {
        $("#legalEntity").addClass("d-none");
        $("#legalEntity :input").val('');
        $("#person").removeClass("d-none");
        $("#person :input").val('');
        $('#customRadioInline2').prop("checked", false)
    });

    $('#form').click(function () {
        if ($('#customRadioInline2').is(':checked')) {
            $('textarea').attr('maxlength', 5000);
            $('textarea').val('');
        } else {
            $('textarea').attr('maxlength', 1500);
            $('textarea').val('');
        }
    });
});

(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));

$(document).ready(function () {
    $(".code").inputFilter(function (value) {
        return /^\d*$/.test(value);    // Allow digits only, using a RegExp
    });
});

$(document).ready(function () {
    $("#delete input").removeClass("btn btn-primary-custom")
        .addClass("btn btn-danger");
});
