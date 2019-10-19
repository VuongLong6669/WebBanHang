$(document).ready(function () {
    var currentUrl = window.location.href;
    var split = currentUrl.split('/');
    var id;
    if (split != null && split.length > 0) {
        id = split[split.length - 1];
    }
    getApi("product", id, showData, null);
    getApi("product/get-new", null, shownRelateProduct, null);
});

function showData(data) {
    $(".img-product").attr("src", data.anh);
    $("#name").text(data.tenHangHoa);
    $("#price").text(data.donGiaBan);
}

function shownRelateProduct(listHangHoa) {
    showProduct(listHangHoa, "#product-relate");
}
