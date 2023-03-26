function ShowMessage(state, message) {
    switch (state) {
        case 0: //Error
            {
                toastr.error(message);
                break;
            }
        case 1: //Success
            {
                toastr.success(message);
                break;
            }
        case 2: //Warning
            {
                toastr.warning(message);
                break;
            }
    }
}

var HttpRequest = (function ($) {
    return {
        Request: function (url, params, method, successCallback, errorCallback) {
            setTimeout(function () {
                var contentType = "application/json; charset=utf-8";
                $.ajax({
                    type: method,
                    url: url,
                    data: params,
                    traditional: true,
                    async: false,
                    contentType: contentType,
                    dataType: "json",
                    cache: false,
                    timeout: 30000,
                    success: function (result, status, xhr) {
                        HideLoader();
                        if (!!successCallback) {
                            successCallback(result);
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        HideLoader();
                        if (!!errorCallback) {
                            errorCallback(xhr, ajaxOptions, thrownError);
                        }
                    }
                });
            }, 50);
        },
        Post: function (url, params, successCallback, errorCallback) {
            ShowLoader();
            return this.Request(url, JSON.stringify(params), "POST", successCallback, errorCallback);
        },
        Get: function (url, params, successCallback, errorCallback) {
            ShowLoader();
            return this.Request(url, params, "GET", successCallback, errorCallback);
        }
    };
}($));

function ShowLoader() {
    $("#BackGroundFreezerPreloader").css('display', 'flex');
    //$("#BackGroundFreezerPreloader").css('height', '100%');
}

function HideLoader() {
    $("#BackGroundFreezerPreloader").css('display', 'none');
    //$("#BackGroundFreezerPreloader").css('height', '100%');
}