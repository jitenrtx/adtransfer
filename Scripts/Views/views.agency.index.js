$(document).ready(function () {
    $('ul#nav li').removeAttr('id');

    $('ul#nav li:contains("Agency")').attr('id', 'current');
});