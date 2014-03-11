function openwindow(wndname, link, width, height, title, onclose) {
    if (link) {
        var div = $("<div id='" + wndname + "'/>");
        div.kendoWindow({
            title: title,
            modal: true,
            content: link,
            width: width,
            height: height,
            visible: false,
            actions: ["Close"],
            /* open: onOpen,*/
            close:(onclose?onclose: function () { this.destroy(); })
        }).data("kendoWindow").center().open();

        var data = $("#" + wndname).data("kendoWindow");
        // data.refresh({ url: link });
        data.center();
        data.open();
    }
}

function closewindow(wndname) {
    $("#" + wndname).data("kendoWindow").close();
}

function ajaxcall(link, content) {
    $.ajax({
        url: link,
        dataType: 'html',
        success: function (data) {
            $("#" + content).html(data);
        }
    });
}

