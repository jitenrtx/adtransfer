$(document).ready(function () {
    $('ul#nav li').removeAttr('id');

    $('ul#nav li:contains("Channel")').attr('id', 'current');
});