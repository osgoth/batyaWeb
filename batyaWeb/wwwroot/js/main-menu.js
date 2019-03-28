//Выпадающие ссылки в меню
var flag_dropdown = true
$('#dropdown-links').click(function(){
    
    if (flag_dropdown == true){
    
        $(".menu-ds-none").css({'display':'block'});

        flag_dropdown = false;

        return;
    }

    $(".menu-ds-none").css({'display':'none'});
    
    flag_dropdown = true;
});
