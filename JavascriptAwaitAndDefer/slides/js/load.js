$(function () {
    $('section.bad').attr('data-state', 'bad');
    $('section.good').attr('data-state', 'good');
    $('section.caution').attr('data-state', 'caution');

    Reveal.initialize({
        controls: true,
        progress: true,
        history: true,
        keyboard: true,
        overview: true, // use esc key
        center: true,
        loop: false,
        rtl: false,
        autoSlide: 0,
        mouseWheel: false,
        rollingLinks: true,
        transition: 'cube', // default/cube/page/concave/zoom/linear/fade/none
        transitionSpeed: 'default' // default/fast/slow
    });

    $('a').attr('target', '_blank');

    $('pre').addClass('prettyprint');
    prettyPrint();
})
