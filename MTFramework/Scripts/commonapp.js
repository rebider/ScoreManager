function monthShowHide(sender) {
    var leftMenu = $('#leftMenu');
    var dMonths = leftMenu.find('div.divMonth');
    for (var i = 0; i < dMonths.length; i++) {
        var hDiv = $(dMonths[i]).children()[0];
        if (hDiv.id != sender.id) {
            var cDiv = $(dMonths[i]).children()[1];
            var hdv = $(hDiv).find('input:hidden');
            $(cDiv).hide();
            $(hDiv).attr('class', 'yc');
            hdv.val('0');
        }
    }
    var divp = $(sender).parent();
    var contentDiv = $(divp.children()[1]);
    var hdv = $(sender).find('input:hidden');
    if (hdv.val() == '1') {
        contentDiv.hide();
        $(sender).attr('class', 'yc');
        hdv.val('0');
    } else {
        contentDiv.show();
        $(sender).attr('class', 'xxiao');
        hdv.val('1');
    }
}
function commonapp(sender) {
    var leftMenu = $('#scrnView');
    var dMonths = leftMenu.find('div.accContainer');
    for (var i = 0; i < dMonths.length; i++) {
        var hDiv = $(dMonths[i]).children()[0];
        if (hDiv.id != sender.id) {
            var cDiv = $(dMonths[i]).children()[1];
            var hdv = $(hDiv).find('input:hidden');
            $(cDiv).hide();
            $(hDiv).attr('class', 'accHeader');
            hdv.val('0');
        }
    }
    var divp = $(sender).parent();
    var contentDiv = $(divp.children()[1]);
    var hdv = $(sender).find('input:hidden');
    if (hdv.val() == '1') {
        contentDiv.hide();
        $(sender).attr('class', 'accHeader');
        hdv.val('0');
    } else {
        contentDiv.show();
        $(sender).attr('class', 'accHeader active');
        hdv.val('1');
    }
    if (top && top.reHeight) {
        top.reHeight();
    }
}