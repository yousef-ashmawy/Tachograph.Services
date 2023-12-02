$('.container_list .menu_item_link').click(function() {
    $(this).toggleClass('activeMenu');
    $('.container_list .menu_item_link').not($(this)).removeClass('activeMenu');
})


$('.container_list .menu_item_link').click(function() {
    $(this).next('.submenu').slideToggle();
    $('.container_list .menu_item_link ').not($(this)).next('.submenu').slideUp();
})

$(document).mouseup(e => {
    if (!$('.container_list .menu_item_link').is(e.target) // if the target of the click isn't the container...
        &&
        $('.container_list .menu_item_link').has(e.target).length === 0) // ... nor a descendant of the container
    {
        $('.container_list .menu_item_link').removeClass('activeMenu');
        $('.container_list .menu_item_link ').not($(this)).next('.submenu').slideUp();

    }
});


$('.menuHead .containerLink .linkItem').on('click', function() {
    $('.contentBody').addClass('spaceFormenu');
    $(this).toggleClass('activeM');
    $(this).siblings().removeClass('activeM');
    $($(this).data('content')).toggleClass('showMenu');
    $($(this).data('content')).siblings().removeClass('showMenu');

    if ($('.menuBody .container_list').hasClass('showMenu')) {
        $('.contentBody').addClass('spaceFormenu');
    } else {
        $('.contentBody').removeClass('spaceFormenu');
    }
});



$(' .menu-toggle ').click(function() {
    $(this).toggleClass('on');
    $('.side_menu').toggleClass('smallMenu');
    $('.main_content').toggleClass('smallMain')
})

/*============== Start menuBtn ==============*/

$('.cta').click(function() {
    $(this).toggleClass('active');
    $('.menu').toggleClass('showMenuMob');
    $('body').toggleClass('overMenu')
})

// $(document).on('click', function(e) {
//     if (($(e.target) != $('.cta')) && $('.cta').has(e.target).length === 0) {
//         $('.cta').removeClass('active');
//         $('.menu').removeClass('showMenuMob');
//         $('body').removeClass('overMenu')
//     }
// });
/*============== end menuBtn ==============*/

/*============== Start Dynamic Tab ==============*/
$('.tap_item').on('click', function() {
    $(this).addClass('tap_item_active').siblings().removeClass('tap_item_active');

    $('.content_tap > div').hide();
    $($(this).data('content')).fadeIn();
});
/*============== End Dynamic Tab ==============*/

$(window).scroll(function() {
    // scroll to top buttom
    var scrollToTop = $('.menu')
    if ($(window).scrollTop() >= 75) {
        scrollToTop.addClass("topShow");
    } else {
        scrollToTop.removeClass("topShow");
    }
});


var $el = $(".profileHead");
var $ee = $(".popProfile");
$el.click(function(e) {
    e.stopPropagation();
    $(".popProfile").toggleClass('toggleItemClass');
});

$(document).on('click', function(e) {
    if (($(e.target) != $el) && ($ee.hasClass('toggleItemClass'))) {
        $ee.removeClass('toggleItemClass');
    }
});