﻿//Class Three JS
$(function () {
    //check to see if the function is working below, uncomment to check to see if your JS works
    //alert("Hello World");
    //take a class and modify it $().
    //get in the habit of doing (function(){}); so you make sure you get all of them
    $('.balloon-checkBox').each(function () {
        $(this).prop('checked', true);
    });

    $('#checkAll').prop('checked', true);

    //change is an event that fires when the checked box changes
    $('.balloon-checkBox').on('change', function () {
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


    $('#checkAll').change(function (e) {
        console.log(e);

        if (e.target.checked) {
            $('.balloon-checkBox').each(function () {
                $(this).prop('checked', true);
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
        } else {
            $('.balloon-checkBox').each(function () {
                $(this).prop('checked', false);
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
        }
    });

    var randomNumber = Math.floor(Math.random() * 4);
    var animateClass = ['wobble', 'swing', 'rubberBand', 'jello'];
    //addClass which is adding a class to the H1, then you put in the array to choose which class which
    //is generated by the randomNumber
    $('#happyBirthdayBox').addClass(animateClass[randomNumber]);

    $('#submit').click(function () {
        console.log('clicked submit');
        var checkBoxCount = 0;
        $('.balloon-checkBox').each(function () {
            console.log($(this).prop('checked'))
            if ($(this).prop('checked')) {
                checkBoxCount += 1;
            } 
        });
        console.log(checkBoxCount);
        if (checkBoxCount == 0) {
            $('#errorToast').removeClass('d-none');
        }
    });

    $("#orangeBalloonLabel, #pinkBalloonLabel, #yellowBalloonLabel").mouseover(function (e) {
        if (e.target.id === 'orangeBalloonLabel') {
            $('#happyBirthdayBox').css('color', 'orange');
        } else if (e.target.id === 'pinkBalloonLabel') {
            $('#happyBirthdayBox').css('color', 'pink');
        } else{
            $('#happyBirthdayBox').css('color', 'yellow');
        }
        
    });

});

//id = #
//class = .
//(boolean expression)? (execute if true):(execute if false)
