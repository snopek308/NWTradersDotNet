//Class Three JS
$(function () {
    //check to see if the function is working below, uncomment to check to see if your JS works
    //alert("Hello World");
    //take a class and modify it $().
    //get in the habit of doing (function(){}); so you make sure you get all of them
    $('.form-check-input').each(function () {
        $(this).prop('checked', true);
    });

    //change is an event that fires when the checked box changes
    $('.form-check-input').on('change', function () {
        //fire on the click on the id choosen
        //it's like typing $('yellowBalloonImg')
        //setting the css visibility to be visible
        $('#' + this.id + 'Img').css('visibility', 'visible')

        //is THIS checked-just checking to see if it checks
        //returning a boolean
        //see below for what it looks like without code
        $(this).is(':checked') ?
            //referring to the balloons either way
            //remove class removes the extra class so you don't have a million
            $('#' + this.id + 'Img').removeClass().addClass('animated zoomIn') :
            $('#' + this.id + 'Img').addClass('animated zoomOut')
    });
});

//(boolean expression)? (execute if true):(execute if false)
