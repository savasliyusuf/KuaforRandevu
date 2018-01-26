(function ($) {
"use strict";
  
/*--
    Variables
-----------------------------------*/
var $window = $(window),
    $windowSize = $window.width(),
    $preloader = $('.preloader'),
    $headerArea = $('.header-area'),
    $mainMenuNav = $('.main-menu nav'),
    $headerTopOffset = $('.header-area').height(),
    $bgYoutubeVideo = $('.bg-youtube-video'),
    $bgVimeoVideo = $('.bg-vimeo-video'),
    $bgSelfHostVideo = $('.bg-selfhost-video'),
    $counter = $('.counter'),
    $progressBar = $('.progress-bar'),
    $portfolioFilter = $('.portfolio-filter'),
    $portfolioGrid = $('.portfolio-grid'),
    $imagePopup = $('[data-image-popup]'),
    $videoPopup = $('[data-video-popup]'),
    $testimonialSlider = $('.testimonial-slider'),
    $portfolioGridItem = '.portfolio-grid .item';
if( $windowSize < 767 ) {
    var $dataScrollOffset = 66;
} else {
    var $dataScrollOffset = $headerTopOffset + 10;
};
/*--
	Preloader
-----------------------------------*/
$window.on('load', function(){
	$preloader.fadeOut('slow');
});
/*--
	Menu Sticky
-----------------------------------*/
$window.on('scroll', function() {
    if( $(this).scrollTop() > 300 ) {
        $headerArea.addClass('stick slideInDown');
    } else {
        $headerArea.removeClass('stick slideInDown');
    }
});
/*--
	Mobile Menu
------------------------*/
$mainMenuNav.meanmenu({
	meanScreenWidth: '767',
    onePage: true,
	meanMenuContainer: '.mobile-menu',
	meanMenuClose: '<span class="close-menu"><i></i></span>',
	meanMenuOpen: '<span class="open-menu"><i></i></span>',
	meanRevealPosition: 'right',
});
/*--
	One Page Menu
-----------------------------------*/
$('.main-menu nav, .mean-nav').onePageNav({
	currentClass: 'active',
	scrollThreshold: 0.2,
	scrollSpeed: 1000,
	scrollOffset: $headerTopOffset + 10,
});
/*--
	Kenburne Slider
-----------------------------------*/
$(".kenburne-slider").kenburnsy({
    fullscreen: true,
});
$bgYoutubeVideo.YTPlayer();
$bgVimeoVideo.vimeo_player();

$bgSelfHostVideo.vide({
    'mp4': 'video/shutter-island',
    'poster': 'video/poster',
}, {
	posterType: 'jpg',
});
/*--
	Skill Progress Bar
-----------------------------------*/
$progressBar.appear(function() {
    $progressBar.each(function(){
        var $progressBarWidth = $(this).data('present');
        /*-- Skill Animation --*/
        $(this).css({'width': $progressBarWidth, 'opacity': '1', });
    });
});
/*--
	Counter Up
-----------------------------------*/
$counter.counterUp({
    time: 3000,
});
/*--
	Portfolio Isotop With Image Loaded
-----------------------------------------*/
$portfolioGrid.imagesLoaded( function() {
    /*-- Filter List --*/
    $portfolioFilter.on( 'click', 'button', function() {
        $portfolioFilter.find('button').removeClass('active');
        $(this).addClass('active');
        var $filterValue = $(this).attr('data-filter');
        $portfolioGrid.isotope({ filter: $filterValue });
    });
    /*-- Filter Grid --*/
    $portfolioGrid.isotope({
        itemSelector: $portfolioGridItem,
        masonry: {
            columnWidth: $portfolioGridItem,
        }
    });
});
/*--
	Magnific Popup
-----------------------------------*/
/*Image*/
$imagePopup.magnificPopup({
    type:'image',
    gallery: {
      enabled: true
    },
});
/*Video*/
$videoPopup.magnificPopup({
    type:'iframe',
    gallery: {
      enabled: true
    },
});
/*--
	Testimonial Slider
-----------------------------------*/
$testimonialSlider.slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    dots: true,
});
/*--
	Smooth Scroll
-----------------------------------*/
$('.mean-nav > ul > li a, [data-scroll]').on('click', function() {
    $.smoothScroll({
        offset: -$dataScrollOffset,
        scrollTarget: this.hash,
        speed: 1000,
    });
	return false;
});


})(jQuery);	