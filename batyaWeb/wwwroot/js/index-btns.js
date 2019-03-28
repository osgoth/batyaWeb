$(document).ready(function () {

    $('#on-btn').click(function () {
        $.ajax({
            url: '/Home/BlockAll',
            type: 'POST',
            traditional: true,
            data: {},
            success: function () {
                alert("blocked everything");
            },
            error: function () {
                alert("failure");
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
                alert("unblocked everything");
            },
            error: function () {
                alert("failure");
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
                alert(data);
            },
            error: function () {
                alert("failure");
            }
        });
    });

});