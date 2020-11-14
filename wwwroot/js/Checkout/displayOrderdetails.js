function fetchdata() {

    var itemsShop = $('#itemsShop');
    var url = itemsShop.attr('action');
    var total = 0;
    $.ajax(
        {
            url: url,
            type: 'Get',
            dataType: 'json',
            success: function (result) {
                $('#restuls').tmpl(result).appendTo('.order-products')
                
                result.forEach(function (data) {
                    total += parseFloat(data.price);
                });

                $("#order-totalPrice").append(formatToCurrency(total));
            }
        });
}

const formatToCurrency = amount => {
    return "$" + amount.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, "$&,");
};

$(document).ready(function () {
    //setTimeout(fetchdata, 0);
    fetchdata();
});