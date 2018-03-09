/*
* @Author: Larry
* @Date:   2016-12-15 17:20:54
* @Last Modified by:   qinsh
* @Last Modified time: 2016-12-20 13:28:08
* +----------------------------------------------------------------------
* | LarryBlogCMS [ LarryCMS网站内容管理系统 ]
* | Copyright (c) 2016-2017 http://www.larrycms.com All rights reserved.
* | Licensed ( http://www.larrycms.com/licenses/ )
* | Author: qinshouwei <313492783@qq.com>
* +----------------------------------------------------------------------
*/
layui.define(["element"],
function (exports) {
    var module_name = "navtab",
    $ = layui.jquery,
    layer = parent.layer === undefined ? layui.layer : parent.layer,
    element = layui.element(),
    globalTabIdIndex = 0,
    LarryTab = function () {
        this.config = {
            elem: undefined,
            closed: true
        }
    };
    var ELEM = {};
    LarryTab.prototype.set = function (options) {
        var _this = this;
        $.extend(true, _this.config, options);
        return _this
    };
    LarryTab.prototype.init = function () {
        var _this = this;
        var _config = _this.config;
        if (typeof (_config.elem) !== "string" && typeof (_config.elem) !== "object") {
            layer.alert("Tab选项卡错误提示: elem参数未定义或设置出错，具体设置格式请参考文档API.")
        }
        var $container;
        if (typeof (_config.elem) === "string") {
            $container = $("" + _config.elem + "")
        }
        if (typeof (_config.elem) === "object") {
            $container = _config.elem
        }
        if ($container.length === 0) {
            layer.alert("Tab选项卡错误提示:找不到elem参数配置的容器，请检查.")
        }
        var filter = $container.attr("lay-filter");
        if (filter === undefined || filter === "") {
            layer.alert("Tab选项卡错误提示:请为elem容器设置一个lay-filter过滤器")
        }
        _config.elem = $container;
        ELEM.titleBox = $container.children("ul.layui-tab-title");
        ELEM.contentBox = $container.children("div.layui-tab-content");
        ELEM.tabFilter = filter;
        return _this
    };
    LarryTab.prototype.exists = function (title) {
        var _this = ELEM.titleBox === undefined ? this.init() : this,
        tabIndex = -1;
        ELEM.titleBox.find("li").each(function (i, e) {
            var $em = $(this).children("em");
            if ($em.text() === title) {
                tabIndex = i
            }
        });
        return tabIndex
    };
    LarryTab.prototype.tabAdd = function (data) {
     
        var _this = this;
    
        var tabIndex = _this.exists(data.title);
        if (tabIndex === -1) {
            globalTabIdIndex++;
            var content = '<iframe src="' + data.href + '" data-id="' + globalTabIdIndex + '"></iframe>';
            var title = "";
            if (data.icon !== undefined) {
                if (data.icon.indexOf("icon-") !== -1) {
                    title += '<i class="iconfont ' + data.icon + '"></i>'
                } else {
                    title += '<i class="' + data.icon + '"></i>';
                }
            }
            title += "<em>" + data.title + "</em>";
            if (_this.config.closed) {
                title += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + globalTabIdIndex + '">&#x1006;</i>'
            }
            element.tabAdd(ELEM.tabFilter, {
                title: title,
                content: content
            });
            ELEM.contentBox.find("iframe[data-id=" + globalTabIdIndex + "]").each(function () {
                $(this).height(ELEM.contentBox.height())
            });
            if (_this.config.closed) {
                ELEM.titleBox.find("li").children("i.layui-tab-close[data-id=" + globalTabIdIndex + "]").on("click",
                function () {
                    element.tabDelete(ELEM.tabFilter, $(this).parent("li").index()).init()
                })
            }
            element.tabChange(ELEM.tabFilter, ELEM.titleBox.find("li").length - 1)
        } else {
            element.tabChange(ELEM.tabFilter, tabIndex)
        }
    };
    LarryTab.prototype.on = function (events, callback) { };
    var navtab = new LarryTab();
    exports(module_name,
    function (options) {
        return navtab.set(options)
    })
});