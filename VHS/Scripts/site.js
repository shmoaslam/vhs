﻿/// <reference path="../Scripts/jquery-1.8.2-vsdoc.js" />
var site = site || {};
site.baseUrl = site.baseUrl || "";
$(document).ready(function (e) {
    // locate each partial section.
    // if it has a URL set, load the contents into the area.
    $(".partialContents").each(function (index, item) {
        var url = site.baseUrl + $(item).data("url");
        if (url && url.length > 0) {
            //$(item).load(url);
            var divId = this.id;
            $.ajax({
                url: url,
                cache: false,
                dataType: "html",
                success: function (data) {
             
                    $("#" + divId).html(data);
                    $.validator.unobtrusive.parse($(data));
                   
                },
                error: function (jqXHR, exception) {
                    var msg = '';
                    if (jqXHR.status === 0) {
                        msg = 'Not connect.\n Verify Network.';
                    } else if (jqXHR.status == 404) {
                        msg = 'Requested page not found. [404]';
                    } else if (jqXHR.status == 500) {
                        msg = 'Internal Server Error [500].';
                    } else if (exception === 'parsererror') {
                        msg = 'Requested JSON parse failed.';
                    } else if (exception === 'timeout') {
                        msg = 'Time out error.';
                    } else if (exception === 'abort') {
                        msg = 'Ajax request aborted.';
                    } else {
                        msg = 'Uncaught Error.\n' + jqXHR.responseText;
                    }
                    alert(msg);
                }
            });
        }

    });
});