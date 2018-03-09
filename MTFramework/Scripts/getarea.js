function loadPro(formlay, pro) {
    $.ajax({
        url: "/Admin/Public/GetProvince",
        type: "GET",
        success: function (data) {
            var strhtml = "";
            strhtml += "<option value>请选择省</option>";
            $.each(data.data, function (index, content) {
                if (pro != null && pro != 'undefined' && pro == data.data[index].Code) {
                    strhtml += "<option value='" + data.data[index].Code + "' selected='selected'>" + data.data[index].Name + "</option>";

                } else {
                    strhtml += "<option value='" + data.data[index].Code + "'>" + data.data[index].Name + "</option>";
                }
            });


           

            //初始化省数据
            $('#province').append(strhtml);
            layui.form().render();

        }
    });

}

//初始数据
//加载省数据
function loadProvince(formlay, pro, cit, are) {
    $.ajax({
        url: "/Admin/Public/GetProvince",
        type: "GET",
        success: function (data) {
            var strhtml = "";
            strhtml += "<option value>请选择省</option>";
            $.each(data.data, function (index, content) {
                if (pro != null && pro != 'undefined' && pro == data.data[index].Code) {
                    strhtml += "<option value='" + data.data[index].Code + "' selected='selected'>" + data.data[index].Name + "</option>";

                } else {
                    strhtml += "<option value='" + data.data[index].Code + "'>" + data.data[index].Name + "</option>";

                }
            });
            
            //初始化省数据
            $('#province').append(strhtml);
            layui.form().render();

        }
    });
    if (pro != null && pro != 'undefined' && pro != '') {
        loadcity(pro, cit);
    } else {
        loadcity("");
    }

    if (cit != null && cit != 'undefined' && cit != '') {
        loadarea(cit, are);
     
    } else {
        loadarea("");
    }

    formlay.on('select(province)', function (data) {
        loadcity(data.value);
    });

    formlay.on('select(city)', function (data) {
        loadarea(data.value);
    });
}

function loadcity(proid, cit) {
    $('#city').html('<option value="">请选择市</option>');
    $('#area').html('<option value="">请选择县/区</option>');
    loadarea("");
    if (proid != null && proid != 'undefined' && proid != '') {
        $.ajax({
            url: "/Admin/Public/GetProvince?pcode=" + proid,
            type: "GET",
            success: function (data) {
                var strhtml = "";
                strhtml += "<option value>请选择市</option>";
                $.each(data.data, function (index, content) {

                    if (cit != null && cit != "" && cit != 'undefined' && cit == data.data[index].Code) {
                        strhtml += "<option value='" + data.data[index].Code + "' selected='selected'>" + data.data[index].Name + "</option>";

                    } else {
                        strhtml += "<option value='" + data.data[index].Code + "'>" + data.data[index].Name + "</option>";

                    }
                });

                //初始化省数据
                $('#city').append(strhtml);
                layui.form().render();
            }
        });
    } else {
        var strhtml = "";
        strhtml += "<option value>请选择市</option>";
        $('#city').append(strhtml);
        layui.form().render();
    }
    
}

function loadarea(cityid, are) {
    $('#area').html('<option value="">请选择县/区</option>');
    $('#area').html('<option value="">请选择县/区</option>');
    if (cityid != null && cityid != 'undefined' && cityid != '') {
    $.ajax({
        url: "/Admin/Public/GetProvince?pcode=" + cityid,
        type: "GET",
        success: function (data) {
            var strhtml = "";
            strhtml += "<option value>请选择区</option>";
            $.each(data.data, function (index, content) {
                if (are != null && are != "" && are != 'undefined' && are == data.data[index].Code) {
                    strhtml += "<option value='" + data.data[index].Code + "' selected='selected'>" + data.data[index].Name + "</option>";

                } else {
                    strhtml += "<option value='" + data.data[index].Code + "'>" + data.data[index].Name + "</option>";

                }
            });
           
            //初始化省数据
            $('#area').append(strhtml);
            layui.form().render();
        }
    });
    } else {
        var strhtml = "";
        strhtml += "<option value>请选择县/区</option>";
        $('#area').append(strhtml);
        layui.form().render();
    }
}