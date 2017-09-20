var site = function () {
    var public = {};

    public.page = {};
    public.ajax = {};

    return public;
}();

site.ajax = function () {
    var ajax = {};

    var defaultErrorHandler = function (serverData) {
        var readyState = (serverData != undefined && serverData.readyState) ? serverData.readyState : "None";
        var status = (serverData != undefined && serverData.status) ? serverData.status : "None";
        var message = (serverData != undefined && serverData.responseText) ? serverData.responseText : undefined;

        if (message !== undefined && message !== null && message !== "") {

            try {
                var resultObject = $.parseJSON(message);
                var redirectUrl = resultObject.RedirectUrl;

                if (typeof (redirectUrl) !== "undefined") {
                    Console.info("Server Exception. Redirecting to error page.");
                    window.location = redirectUrl;
                    return;
                }
            } catch (err) {
            }
        }

        Console.error("Ajax error occurred: Ready State [" + readyState + "] Status [" + status + "] Message [" + ((message != undefined) ? message : "None") + "]");
    };

    var generateSuccessRouteHandler = function (successCallback, url) {
        Console.info("Successfull Ajax call. Destination = [" + ((url != undefined) ? url : "None") + "]");
        return successCallback;
    };

    var generateFailureRouteHandler = function (failureCallback, url) {
        var failureHandler = ((failureCallback == undefined) ? defaultErrorHandler : failureCallback);

        Console.info("Ajax call failed. Destination = [" + ((url != undefined) ? url : "None") + "]");
        return failureHandler;
    };

    ajax.submitAjaxGetRequest = function (targetUrl, successCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);

        $.get(targetUrl, successHandler);
    };

    ajax.submitAjaxGetJson = function (targetUrl, jsonData, successCallback, failureCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);
        var failureHandler = generateFailureRouteHandler(failureCallback, targetUrl);

        var jsonString = JSON.stringify(jsonData);

        $.ajax({
            type: "POST",
            url: targetUrl,
            data: jsonString,
            success: successHandler,
            error: failureHandler,
            contentType: "application/json",
            dataType: "html"
        });
    };

    ajax.submitAjaxGetHtml = function (targetUrl, jsonData, successCallback, failureCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);
        var failureHandler = generateFailureRouteHandler(failureCallback, targetUrl);

        var jsonString = JSON.stringify(jsonData);

        $.ajax({
            type: "POST",
            url: targetUrl,
            data: jsonString,
            success: successHandler,
            error: failureHandler,
            contentType: "application/json",
            dataType: "json"
        });
    };

    return ajax;
}();
