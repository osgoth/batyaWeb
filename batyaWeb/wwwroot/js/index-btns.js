$(document).ready(function () {
// sudo iptables -L
    $('#on-btn').click(function () {
        $.ajax({
            url: '/Home/BlockAll',
            type: 'POST',
            traditional: true,
            data: {},
            success: function () {

                $('.text-out-on_off').text('Всё заблоктровано!').show();

                $('.text-out-on_off').addClass('alert-success').removeClass('alert-danger alert-primary');
            },
            error: function () {

                $('.text-out-on_off').text('Ошибка!').show();

                // Замена класса для отображения ошибокs
                $('.text-out-on_off').addClass('alert-danger').removeClass('alert-success');
            }
        });
    });

    $('#off-btn').click(function () {
        $.ajax({
            url: '/Home/UnblockAll',
            type: 'POST',
            traditional: true,
            data: {},
            success: function () {

                $('.text-out-on_off').text('Разблокировано!').show();

                $('.text-out-on_off').addClass('alert-primary').removeClass('alert-danger alert-success');

            },
            error: function () {

                $('.text-out-on_off').text('Ошибка!').show();

                // Замена класса для отображения ошибок
                $('.text-out-on_off').addClass('alert-danger').removeClass('alert-success');
            }
        });
    });

    $('#ip-btn').click(function () {
        $.ajax({
            url: '/Home/IPAddr',
            type: 'POST',
            traditional: true,
            data: {},
            success: function (data) {

                $('.text-out-ip').text(data).show();

                $('.text-out-ip').addClass('alert-success').removeClass('alert-danger');
            },
            error: function () {
                
                $('.text-out-ip').text('Ошибка!').show();

                // Замена класса для отображения ошибок
                $('.text-out-ip').addClass('alert-danger').removeClass('alert-success');
            }
        });
    });

});