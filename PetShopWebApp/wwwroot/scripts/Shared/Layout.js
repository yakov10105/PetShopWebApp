$(function () {
    //Navigation Bar

    $('.navbar-toggle').click(function () {
        $('.single-page-nav').toggleClass('show', 1000);
    });

    $('.single-page-nav a').click(function () {
        $('.single-page-nav').removeClass('show');
    });

    //===================================================

    //Slider
    //config
    let width = 1440;
    let animationSpeed = 1000;
    var pause = 3000;
    let currentSlide = 1;

    //cache DOM
    let slider = $('#slider');
    let slideContainer = slider.find('.slides');
    let slides = slideContainer.find('.slide');

    let interval;

    function startSlider() {
        interval = setInterval(function () {
            slideContainer.animate({ 'margin-left': '-=' + width }, animationSpeed, function () {
                currentSlide++;
                if (currentSlide === slides.length) {
                    currentSlide = 1;
                    slideContainer.css('margin-left', 0);
                }
            });
        }, pause);
    }
    let pauseSlider = () => clearInterval(interval);

    slider.on('mouseenter', pauseSlider).on('mouseleave', startSlider);
    startSlider();
});