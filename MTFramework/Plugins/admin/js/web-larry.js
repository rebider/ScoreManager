layui.config({
    base: "/Plugins/admin/js/"
}).use(["jquery", "element", "layer", "navtab"],
function () {

    window.jQuery = window.$ = layui.jquery;
    window.layer = layui.layer;
    var element = layui.element(),
    navtab = layui.navtab({
        elem: ".larry-tab-box"
    });
    if (document.readyState != "complete") {
        $("#content").removeClass("fullwidth");
        $("#content").removeClass("fullwidth").delay(10).queue(function (next) {
            $(this).addClass("fullwidth");
            next()
        })
    } else {
        $("#content").hide()
    }
    $(window).on("resize",
    function () {
        var $content = $("#larry-tab .layui-tab-content");
        $content.height($(this).height() -80);
        $content.find("iframe").each(function () {
            $(this).height($content.height())
        });
        var larryFoot = $("#admin-footer").width();
        $("#admin-footer p.p-admin").width(larryFoot - 300)
    }).resize();

});