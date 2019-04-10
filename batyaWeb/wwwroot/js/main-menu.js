//Выпадающие ссылки в меню
var flag_dropdown = true
$('#dropdown-links').click(function(){
    
    if (flag_dropdown == true){
    
        $(".menu-ds-none").css({'display':'block'});

        $('.drd-links').css({'background-color':'#2d3236'});

        flag_dropdown = false;

        return;
    }

    $(".menu-ds-none").css({'display':'none'});
    
    $('.drd-links').css({'background-color':'#212529'});
    //$('.drd-links').hover({'background-color':'#212529'});

    // test
    // $('.drd-links').css("background-color", "rgb(255, 197, 7)");

    // типа свойство hover
    $(".drd-links").mouseenter(function() {

        $(this).css("background-color", "rgb(255, 197, 7)");

    }).mouseleave(function() {

        if (flag_dropdown == true){

            $(this).css("background-color", "#212529");

        }
    });

    flag_dropdown = true;
});
