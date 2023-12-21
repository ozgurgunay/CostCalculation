$(document).ready(function () {
    GetCurrencyData();
});

function GetCurrencyData() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetCurrencyData',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (data) {
            DrawCurrencyInfo(data);
        },
        Error: function (e) {
            alert("Hata: " + e.responseText);
        }
    });
}
function DrawCurrencyInfo(data) {
    var html =
        '<div>' + '&euro; ' + formatNumber(data.formattedBanknoteSelling) + '</div>'; /*+ data.currencyName + ' : '*/
    $(".border-top.footer .container .currency").html(html);
}
function formatNumber(number) {
    const formattedNumber = (number / 10000).toLocaleString('tr-TR', {
        minimumFractionDigits: 4,
        maximumFractionDigits: 4
    });
    return formattedNumber;
}






