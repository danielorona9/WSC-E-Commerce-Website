﻿$(document).ready(function() {
    $(function() {
        // Document.ready -> link up remove event handler
        $(".RemoveLink").click(function() {
            // Get the id from the link
            var recordToDelete = $(this).attr("data-id");
            if (recordToDelete != "") {
                // Perform the ajax post
                $.post("/ShoppingCart/RemoveFromCart",
                    { "id": recordToDelete },
                    function(data) {
                        // Successful requests get here
                        // Update the page elements
                        if (data.ItemCount === 0) {
                            $("#row-" + data.DeleteId).fadeOut("slow");
                        } else {
                            $("#item-count-" + data.DeleteId).text(data.ItemCount);
                        }
                        $("#cart-total").text(data.CartTotal);
                        $("#update-message").text(data.Message);
                        $("#cart-status").text("Cart (" + data.CartCount + ")");
                        handleUpdate();
                    });
            }
        });


    });


    function handleUpdate() {
        // Load and deserialize the returned JSON data
        // var json = context.get_data();
        var json = context.getData();
        var data = Sys.Serialization.JavaScriptSerializer.deserialize(json); // parseJSON(json); //      
        // Update the page elements
        if (data.ItemCount === 0) {
            $("#row-" + data.DeleteId).fadeOut("slow");
        } else {
            $("#item-count-" + data.DeleteId).text(data.ItemCount);
        }
        $("#cart-total").text(data.CartTotal);
        $("#update-message").text(data.Message);
        $("#cart-status").text("Cart (" + data.CartCount + ")");


    }

});


//$(function () {
//    $(".RemoveLink").click(function() {
//        $.ajax({
//            url: "/ShoppingCart/RemoveFromCart",
//            data: { id: $(this).data("id") },
//            type: 'POST',
//            success: function(result) {
//                $('#row-' + result.DeleteId).remove();
//                $('#row-' + result.DeleteId).fadeOut('slow');
//                $('#cart-status').text('Cart (' + +result.CartCount + ')');
//                $('#update-message').text(result.Message);
//                $('#cart-total').text(result.CartTotal);
//                $.get("/ShoppingCart/CartSummary");

//            }
//        });
//    });

//});