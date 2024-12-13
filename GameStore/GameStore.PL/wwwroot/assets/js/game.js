$('#review-form').on('submit', (e) => {
    e.preventDefault();

    const productId = $(location).attr('href').split('/').pop();
    const comment = $('#comment').val();

    $.post('/game/addcomment/',
        {
            id: productId,
            comment: comment
        },
        function (review, status) {
            if (status == "success")
            {
                $('#comments').prepend(`<div>${review.comment}${review.createdAt}</div>`);
            }
        }
    );
})