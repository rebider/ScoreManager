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
        $content.height($(this).height() - 133);
        $content.find("iframe").each(function () {
            $(this).height($content.height())
        });
        var larryFoot = $("#admin-footer").width();
        $("#admin-footer p.p-admin").width(larryFoot - 300)
    }).resize();
    $(function () {
        $("#larry-nav-side").click(function () {


           
            if ($(this).attr("lay-filter") !== undefined) {
                $(this).children("ul").find("li").each(function () {
                    var $this = $(this);
                    if ($this.find("dl").length > 0) {

                        var $dd = $this.find("dd").each(function () {
                            $(this).click(function () {
                                var $a = $(this).children("a");
                                var href = $a.data("url");
                                var icon = $a.children("i:first").data("icon");
                                var title = $a.children("span").text();
                                var data = {
                                    href: href,
                                    icon: icon,
                                    title: title
                                };
                                navtab.tabAdd(data)
                            })
                        })
                    } else {
                        $this.click(function () {
                            var $a = $(this).children("a");
                            var href = $a.data("url");
                            var icon = $a.children("i:first").data("icon");
                            var title = $a.children("span").text();
                            var data = {
                                href: href,
                                icon: icon,
                                title: title
                            };
                            navtab.tabAdd(data)
                        })
                    }
                })
            }
        });

        if ($("#larry-nav-side").attr("lay-filter") !== undefined) {
            $("#larry-nav-side").children("ul").find("li").each(function () {
                var $this = $(this);
                if ($this.find("dl").length > 0) {

                    var $dd = $this.find("dd").each(function () {
                        $(this).click(function () {

                            var $a = $(this).children("a");
                            var href = $a.data("url");
                            var icon = $a.children("i:first").data("icon");
                            var title = $a.children("span").text();
                            var data = {
                                href: href,
                                icon: icon,
                                title: title
                            };
                            navtab.tabAdd(data)
                        })
                    })
                } else {
                    $this.click(function () {
                        var $a = $(this).children("a");
                        var href = $a.data("url");
                        var icon = $a.children("i:first").data("icon");
                        var title = $a.children("span").text();
                        var data = {
                            href: href,
                            icon: icon,
                            title: title
                        };
                        navtab.tabAdd(data)
                    })
                }
            })
        }

        if (document.readyState != 'complete') {
            $('#content').hide();
        }
    })
});

