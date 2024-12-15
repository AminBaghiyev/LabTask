$('.add-cart-btn').on('click', function () {
    const id = parseInt($(this).data('id'), 10);
    const price = parseFloat($(this).data('price'));
    const quantityInput = $(this).siblings('input[name="quantity"]');
    const subtotal = $("#subtotal");
    const total = $("#total");
    const quantity = parseInt(quantityInput.val(), 10);

    $.post('/cart/add/',
        {
            id
        },
        function (data, status) {
            let alertMessage = "";
            if (status == "success")
            {
                alertMessage = $('<div class="alert success">Product added to cart.</div>');
                quantityInput.val(quantity + 1);
                const newSubtotal = (parseFloat(subtotal.text().replace('$', '').trim()) + price).toFixed(2);
                subtotal.text(`$ ${newSubtotal}`);
                total.text(`$ ${newSubtotal}`);
            } else
            {
                alertMessage = $('<div class="alert danger">Something went wrong!</div>');
            }

            $('body').append(alertMessage);

            alertMessage.fadeIn(300);

            setTimeout(function () {
                alertMessage.fadeOut(300, function () {
                    $(this).remove();
                });
            }, 3000);
        }
    );
})

$('.remove-cart-btn').on('click', async function () {
    const button = $(this);
    const id = parseInt(button.data('id'), 10);
    const price = parseFloat(button.data('price'));
    const quantityInput = button.siblings('input[name="quantity"]');
    const subtotal = $("#subtotal");
    const total = $("#total");
    const quantity = parseInt(quantityInput.val(), 10);

    if (quantity - 1 === 0)
    {
        const result = await Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        })

        if (!result.isConfirmed) return;
    }

    $.post('/cart/remove/',
        {
            id
        },
        function (data, status) {
            let alertMessage = "";
            if (status == "success") {
                alertMessage = $('<div class="alert success">Product removed from cart.</div>');
                quantityInput.val(quantity - 1);
                const newSubtotal = (parseFloat(subtotal.text().replace('$', '').trim()) - price).toFixed(2);
                subtotal.text(`$ ${newSubtotal}`);
                total.text(`$ ${newSubtotal}`);
            } else {
                alertMessage = $('<div class="alert danger">Something went wrong!</div>');
            }

            if (quantity - 1 === 0)
            {
                button.closest('.cart-item').remove();
            }

            $('body').append(alertMessage);

            alertMessage.fadeIn(300);

            setTimeout(function () {
                alertMessage.fadeOut(300, function () {
                    $(this).remove();
                });
            }, 3000);
        }
    );
})

$('.remove-all-cart-btn').on('click', async function () {
    const button = $(this);
    const id = parseInt(button.data('id'), 10);
    const price = parseFloat(button.data('price'));
    const quantity = parseInt(button.closest('.cart-item').find('input[name="quantity"]').val(), 10);
    const subtotal = $("#subtotal");
    const total = $("#total");

    const result = await Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    })

    if (!result.isConfirmed) return;

    $.post('/cart/remove/',
        {
            id,
            quantity
        },
        function (data, status) {
            let alertMessage = "";
            if (status == "success") {
                alertMessage = $('<div class="alert success">Product removed from cart.</div>');
                const newSubtotal = (parseFloat(subtotal.text().replace('$', '').trim()) - (price * quantity)).toFixed(2);
                subtotal.text(`$ ${newSubtotal}`);
                total.text(`$ ${newSubtotal}`);
                button.closest('.cart-item').remove();
            } else {
                alertMessage = $('<div class="alert danger">Something went wrong!</div>');
            }

            $('body').append(alertMessage);

            alertMessage.fadeIn(300);

            setTimeout(function () {
                alertMessage.fadeOut(300, function () {
                    $(this).remove();
                });
            }, 3000);
        }
    );
})