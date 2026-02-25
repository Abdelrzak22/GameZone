$(document).ready(function () {

    $('.action-btn').on('click', function () {

        var btn = $(this);

        $.ajax({
            url: `/Games/Delete/${btn.data('id')}`,
            type: 'DELETE',
            success: function () {
                btn.closest('tr').fadeOut(300, function () {
                    $(this).remove();
                });
            },
            error: function () {
                alert("Something went wrong");
            }
        });

    });

});