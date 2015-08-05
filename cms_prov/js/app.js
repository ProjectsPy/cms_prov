$(document).ready(function () {

    //$("#owl-demo").owlCarousel({

    //    // navigation: true, // Show next and prev buttons
    //    slideSpeed: 300,
    //    paginationSpeed: 400,
    //    singleItem: true,
    //    autoPlay: true

    //    // "singleItem:true" is a shortcut for:
    //    // items : 1, 
    //    // itemsDesktop : false,
    //    // itemsDesktopSmall : false,
    //    // itemsTablet: false,
    //    // itemsMobile : false

    //});
    // Layer Slider Dynamic- Set height to fit navbar
    if ($(".layer-slider-dynamic").length > 0) {
        layerSliderDynamic();
    }

    // Layer Slider Fullsize
    if ($(".layer-slider-fullsize").length > 0) {
        layerSliderFullsize();
    }

    // Window resize events
    $(window).resize(function () {
        if ($(".layer-slider-dynamic").length > 0) {
            layerSliderDynamic();
        }
        if ($(".layer-slider-fullsize").length > 0) {
            layerSliderFullsize();
        }
    });

    // Functions
    function layerSliderDynamic() {
        var windowHeight = $(window).height();
        var headerHight = $("#divHeaderWrapper").height();
        var newSliderHeight = windowHeight - headerHight;
        $("#layerslider").css({ "height": newSliderHeight + "px" });
    }
    function layerSliderFullsize() {
        var windowHeight = $(window).height();
        $("#layerslider").css({ "height": windowHeight + "px" });
    }


    var screenRes = $(window).width(),
        screenHeight = $(window).height(),
        html = $('html');

    $('#ulSorList').mixitup();
    // Fancybox
    $(".theater").fancybox();
    // Fancybox	
    $(".ext-source").fancybox({
        'transitionIn': 'none',
        'transitionOut': 'none',
        'autoScale': false,
        'type': 'iframe',
        'width': '50%',
        'height': '60%',
        'scrolling': 'no'
    });
});