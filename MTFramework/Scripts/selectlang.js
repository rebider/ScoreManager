
$(function () {
    var l = $('#lang').val();
    if (l == null) l = "zh_cn";
    if (l == "zh_cn")
    jQuery.getScript("/lang/" + l + "/index.js", function (data, status, jqxhr) {
            for (var key in lang) {
               $("[lang="+key+"]").html(lang[key]);
            } 
    });
});
