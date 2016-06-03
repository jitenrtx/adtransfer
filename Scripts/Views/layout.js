$(function () {
    $('.password').pstrength();
});

$(document).ready(function () {
//    $("#myTable")
//    .tablesorter({
//        // zebra coloring
//        widgets: ['zebra'],
//        // pass the headers argument and assing a object 
//        headers: {
//            // assign the sixth column (we start counting zero) 
//            6: {
//                // disable it by setting the property sorter to false 
//                sorter: false
//            }
//        }
//    })
//.tablesorterPager({ container: $("#pager") });

    $("#nav").find("a").click(function () {
        //$("#nav").find("a").removeClass("selected");//remove if something was selected
        //$(this).addClass("selected");//add a selected class
        $("#nav").find("a").removeAttr('id');//remove if something was selected
        $(this).attr('id', 'current');//add a selected class

    });


//    $('ul#nav li').click(function (e)
//    {
//        //event.stopPropagation();
//        $('ul#nav li').removeAttr('id');
//        $(this).attr('id', 'current');
//        alert(this);
////     alert($(this).find("span.t").text());
//    });

});

