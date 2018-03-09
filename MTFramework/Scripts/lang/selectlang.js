
$(function () {
    var l = $('#lang').val();
    if (l == null||l == "") l = "Cn";
    jQuery.getScript("/Scripts/lang/" + l + "/index.js", function (data, status, jqxhr) {
        if (l == "En"){
            $("*").addClass("font-family");
            $(".fa").removeClass("font-family")
        } 
        else $("*[data-english != yes]").removeClass("font-family");
        for (var key in weblang) {
            $("[lang=" + key + "]").html(weblang[key]);
            $("[btn-lang=" + key + "]").val(weblang[key]);
            $("[btn-lang=" + key + "]").html(weblang[key]);
        }
    });
});
