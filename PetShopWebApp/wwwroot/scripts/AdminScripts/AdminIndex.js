//Gets the id of selected category at the drop down list
$(function () {
    $('#cat').change(function () {
        var val = $('select').children('option:selected').val();
        $('#btn-submit').attr('href', $('#btn-submit').data("url-prefix") + "?categoryId=" + val)
    });
})