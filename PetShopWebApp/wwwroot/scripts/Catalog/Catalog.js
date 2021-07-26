$(function () {
    //gets the id of the selected category at the drop down list
    $('#cat').change(function () {
        var val = $('select').children('option:selected').val();
        $('#btn-submit').attr('href', $('#btn-submit').data("url-prefix") + "?categoryId=" + val)
    });
})