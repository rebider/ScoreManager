$("th").click(function () {
    var label = $(this).children("label").attr("for").replace("Item_", "");
    if ($(this).children("label").attr("order") == undefined) {
        $(this).children("label").attr("order", "desc");
        $(this).children("label").children("i").attr("class", "fa fa-sort-asc fa-fw");
        $("#orderby").val(label + " asc");
    } else if ($(this).children("label").attr("order") == "asc") {
        $("#orderby").val(label + " desc");
        $(this).children("label").attr("order", "desc");
        $(this).children("label").children("i").attr("class", "fa fa-sort-desc fa-fw");
    } else {
        $("#orderby").val("");
        $(this).children("label").removeAttr("order");
        $(this).children("label").children("i").attr("class", "");
    }
    $(".layui-form").submit();
});

$(function () {

    $("th label[for]").each(function () {
        $(this).html($(this).text() + "<i class=''></i>");
    });

    var orderby = $("#orderby").val();
    if (orderby != undefined) {
        if (orderby.length > 0) {
            var arrorder = orderby.split(" ");

            var item = "Item_" + arrorder[0];
            if (arrorder[1].trim() == "asc") {

                $("th label[for='" + Trim(item) + "']").attr("order", Trim(arrorder[1]));
                $("th label[for='" + Trim(item) + "']").children("i").attr("class", "fa fa-sort-asc fa-fw");
            } else if (arrorder[1].trim() == "desc") {
                $("th label[for='" + Trim(item) + "']").attr("order", Trim(arrorder[1]));
                $("th label[for='" + Trim(item) + "']").children("i").attr("class", "fa fa-sort-desc fa-fw");
            } else {
                $("th label[for='" + Trim(item) + "']").children("i").attr("class", "");
            }

        }
    }
    
});


function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}