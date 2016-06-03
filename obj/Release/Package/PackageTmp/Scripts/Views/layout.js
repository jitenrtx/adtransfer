$(function () {
    $('.password').pstrength();
});

$(document).ready(function () {
    $("#myTable")
    .tablesorter({
        // zebra coloring
        widgets: ['zebra'],
        // pass the headers argument and assing a object 
        headers: {
            // assign the sixth column (we start counting zero) 
            6: {
                // disable it by setting the property sorter to false 
                sorter: false
            }
        }
    })
.tablesorterPager({ container: $("#pager") });
});