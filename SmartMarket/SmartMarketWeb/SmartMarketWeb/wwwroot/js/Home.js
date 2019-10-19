$(document).ready(function () {
    getApi("product/get-new", null, shownNewProduct, null);
    getApi("product/get-new", null, shownTrendProduct, null);
    getApi("cate/getall", null, showLoaiHangHoa, null);
 
});
function showLoaiHangHoa(listHangHoa) {
    console.log(listHangHoa);
    var defaultItem = $(".l-category").find(".list-category");
    console.log(defaultItem);
    var copyItem = defaultItem[0];
    $(defaultItem).remove();
    for (let i = 0; i < listHangHoa.length; i++) {
        $(copyItem).clone().appendTo(".l-category");
        var listItem = $(".l-category").find(".list-category");
        var currentItem = listItem[listItem.length - 1];
        $($(currentItem).find(".image")).attr("src", listHangHoa[i].anh);
        $($(currentItem).find(".name")).text(listHangHoa[i].tenLoaiHang);
        $(currentItem).click(function () {
            alert(i);
        })
    }
}

function shownNewProduct(listHangHoa) {
    showProduct(listHangHoa, "#list-new-product");
}

function shownTrendProduct(listHangHoa) {
    showProduct(listHangHoa, "#list-trand-product");
}