$(function () {
    //绑定 下拉列表监听事件
    layui.use(['jquery', 'form'], function () {
        var form = layui.form();
        var lang = $("#lang").val();
        if (lang == undefined || lang === "") {
            lang = "Cn";
        }
        form.verify({
            required: function (value) {
                if (!value.match(/[\S]+/)) {
                    if (lang === "En") {
                        return 'Required cannot be empty';
                    } else {
                        return '必填项不能为空';
                    }
                }
            },
            phone: function (value) {
                if (!value.match(/^1\d{10}$/)) {
                    if (lang === "En") {
                        return 'Please enter the correct phone number';
                    } else {
                        return '请输入正确的手机号';
                    }
                }
            },
            password: function (value) {
                if (!value.match(/^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,20}$/)) {
                    if (lang === "En") {
                        return 'Please enter a password consisting of 6-20 alphanumeric characters';
                    } else {
                        return '请输入6-20位字母和数字组成的密码';
                    }
                }
            },
            email: function (value) {
                // /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
                if (!value.match(/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/)) {
                    if (lang === "En") {
                        return 'Incorrect mailbox format';
                    } else {
                        return '邮箱格式不正确';
                    }
                }
            },
            url: function (value) {
                if (!value.match(/(^#)|(^http(s*):\/\/[^\s]+\.[^\s]+)/)) {
                    if (lang === "En") {
                        return 'Incorrect link format';
                    } else {
                        return '链接格式不正确';
                    }
                }
            },
            number: function (value) {
                if (!value.match(/^\d+$/)) {
                    if (lang === "En") {
                        return 'Fill in numbers only';
                    } else {
                        return '只能填写数字';
                    }
                }
            },
            date: function (value) {
                if (!value.match(/^(\d{4})[-\/](\d{1}|0\d{1}|1[0-2])([-\/](\d{1}|0\d{1}|[1-2][0-9]|3[0-1]))*$/)) {
                    if (lang === "En") {
                        return 'Incorrect date format';
                    } else {
                        return '日期格式不正确';
                    }
                }
            },
            identity: function (value) {
                if (!value.match(/(^\d{15}$)|(^\d{17}(x|X|\d)$)/)) {
                    if (lang === "En") {
                        return 'Please enter the correct ID number';
                    } else {
                        return '请输入正确的身份证号';
                    }
                }
            },
            idcard: function (value) {
                var id = value;
                //if (id.length==18) {
                //    if (!value.match(/(\d{1+})|(^\d{17}(x|X|\d)$)/)) {
                //        if (lang === "En") {
                //            return 'Please enter the correct ID number';
                //        } else {
                //            return '请输入正确的身份证号';
                //        }
                //    }
                //}
                if (id.length == 18) {
                    if (!value.match(/(\d{1+})|(^\d{17}(x|X|\d)$)/)) {
                        if (lang === "En") {
                            return 'Please enter the correct ID number';
                        } else {
                            return '请输入正确的身份证号';
                        }
                    }
                } else {

                    if (!value.match(/[\S]+/)) {
                        if (lang === "En") {
                            return 'Required cannot be empty';
                        } else {
                            return '必填项不能为空';
                        }
                    }
                } 
               
            },
            amountverification: function (value) {
                if (value <100 || value > 7000 || value == "" || value == undefined ) {

                    if (lang === "En") {
                        return 'Input amount inconformity criterion';
                    } else {
                        return '输入金额不符合规范';
                    }
                }
            }
        });
    });
});