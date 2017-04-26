//$(document).ready(function() {
//    getProducts();
//});


//function getProducts() {
//    $('#JobTypes').on('click', function (){
//    $.ajax('/Catalog/sortBy',
//    {
//        type: 'GET',
//        dataType: 'json',
//        data: {id: $('JobTypes').val()},
//        success: function(data) {
//            var rows = '';
//            $.each(data,
//                function(i, item) {
//                    rows += "<tr>";
//                    rows += "<td>" + item.JobTypeID + "</td>";
//                    rows += "<td>" + item.MediaTypeID + "</td>";
//                    rows += "<td>" + item.Price + "</td>";
//                    rows += "<td>" + item.Description + "</td>";
//                    rows += "<td>" + item.StockAvailable + "</td>";
//                    rows += "<td><img src='" + item.ProductImage + "' alt='" + item.Description + "' /></td>";
//                    rows += "</tr>";
//                    $("#catalog_List tbody").html(rows);
//                });
//        }
//    });
//    });
//}