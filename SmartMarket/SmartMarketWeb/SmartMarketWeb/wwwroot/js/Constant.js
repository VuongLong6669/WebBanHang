var baseUrl = 'https://localhost:44392/api/';

function getApi(url, request, sucess, error) {
    var _url = baseUrl + url;
    if (request != null) {
        _url += request;
    }
    console.log(_url);
    $.ajax({
        type: 'GET',
        url: _url,
        dataType: "json",
        crossDomain: true,
        success: function (data) {
            console.log(data);
            sucess(data);
        },
        error: function (request, status, error) {
            console.log(error);
        }
    });
}