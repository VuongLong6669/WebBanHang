var baseUrl = 'https://localhost:44392/api/';

function getApi(url, request, sucess, error) {
    var _url = baseUrl + url;
    if (request != null) {
        _url += "/";
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

function showProduct(listHangHoa, parent) {
    var defaultItem = $(parent).find(".list-item-flash");
    var copyItem = defaultItem[0];
    $(defaultItem).remove();
    for (let i = 0; i < listHangHoa.length; i++) {
        console.log(i);
        $(copyItem).clone().appendTo(parent);
        var listItem = $(parent).find(".list-item-flash");
        var currentItem = listItem[listItem.length - 1];
        $($(currentItem).find(".list-flash-image")).attr("src", listHangHoa[i].anh);
        $($(currentItem).find(".list-flash-name")).text(listHangHoa[i].tenHangHoa);
        $($(currentItem).find(".list-flash-text")).text(listHangHoa[i].donGiaBan);
        $(currentItem).click(function () {
            var URL = 'https://localhost:44366/Product/Details/' + listHangHoa[i].idHangHoa;
            location.href = URL;
        })
    }
}