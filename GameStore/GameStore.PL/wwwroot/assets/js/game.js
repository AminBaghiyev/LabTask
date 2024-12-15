$('#add-to-cart').on('submit', function (e) {
    e.preventDefault();

    const id = $(location).attr('href').split('/').pop();
    const quantity = $('input[name="quantity"]').val();

    if (quantity <= 0)
    {
        const alertMessage = $('<div class="alert danger">Product quantity must be a positive number!</div>');
        $('body').append(alertMessage);

        alertMessage.fadeIn(300);

        setTimeout(function () {
            alertMessage.fadeOut(300, function () {
                $(this).remove();
            });
        }, 3000);

        $('input[name="quantity"]').val(1);
        return;
    }

    $.post('/cart/add/',
        {
            id,
            quantity
        },
        function (data, status) {
            let alertMessage = "";
            if (status == "success") {
                alertMessage = $('<div class="alert success">Product added to cart.</div>');
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

$('#review-form').on('submit', (e) => {
    e.preventDefault();

    const id = $(location).attr('href').split('/').pop();
    const comment = $('#comment').val();

    $.ajax({
        url: '/game/addcomment/',
        method: 'POST',
        data: {
            id,
            comment
        },
        success: function (review) {
            const createdAt = new Date(review.createdAt)
                .toLocaleString("de-DE", {
                    day: "2-digit",
                    month: "2-digit",
                    year: "numeric",
                    hour: "2-digit",
                    minute: "2-digit",
                    second: "2-digit"
                }).replace(",", "");

            $('#comments').prepend(`
                <div class="comment-container">
                    <div class="comment-info d-flex justify-content-between">
                        <div>@${$('.username').text()}:</div>
                        <div class="created-at">${createdAt}</div>
                    </div>
                    <div class="comment">${review.comment}</div>
                </div>
            `);

            $('#comment').val("");

            $('#reviews-tab').text(`Reviews (${parseInt($("#reviews-tab").text().slice(9), 10) + 1})`);
        },
        error: function (e) {
            let alertMessage;
            if (e.status === 401) {
                alertMessage = $('<div class="alert danger">You need to log in to add a comment!</div>');
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
    });
});
