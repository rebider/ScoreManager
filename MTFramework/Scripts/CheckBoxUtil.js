//多选通用方法
function BindCheckAll(options) {
    options = $.extend({
        btnClass: '.btnDelete',
        checkall: '.checkall',
        checkone: '.checkone:enabled',
        noSelectTip: '您尚未选择要删除的选项！',
        confirmTip: '您确定要删除所选项吗？',
        goAction: 'Delete'
    }, options);

    var checkall = $(options.checkall);
    var checkone = $(options.checkone);
    var btnDelete = $(options.btnClass);

    checkall.bind('click', function () {
        var allState = (($(this).attr('checked') || '') != '');
        if (allState == '') {
            checkone.removeAttr('checked');
        } else {
            checkone.attr('checked', 'checked');
        }
    });

    checkone.each(function () {
        $(this).bind('click', function () {
            if ($('.checkone:checked').length == checkone.length) {
                checkall.attr('checked', 'checked');
            } else {
                checkall.removeAttr('checked');
            }
        });
    });

    btnDelete.bind('click', function () {
        if ($('.checkone:checked').length == 0) {
            layer.msg(options.noSelectTip);
        } else {
            layer.confirm(options.confirmTip,{ icon: 3, title: '提示' }, function (index) {
                var newArr = new Array();
                var pathName = location.pathname.split('/');
                for (var i = 0; i < pathName.length - 1; i++) {
                    newArr.push(pathName[i]);
                }
                newArr.push(options.goAction);
                var newStr = newArr.join('/');
                var newArr2 = new Array();
                for (var j = 0; j < $('.checkone:checked').length; j++) {
                    newArr2.push($('.checkone:checked').eq(j).val());
                }
                newStr += '?id=' + newArr2.join(',');
                $.ajax({
                    url: newStr,
                    type: "POST",
                    success: function (data) {
                        if (data.status == 1) {
                            if (data.msg == "") {
                                data.msg == "删除成功！";
                            }
                            layer.open({
                                content: data.msg,
                                yes: function (layero, index) {
                                    window.location.reload();
                                }
                            });
                        }
                    }
                });
            });
        }
    });
}