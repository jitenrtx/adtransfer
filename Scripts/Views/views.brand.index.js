$(document).ready(function () {
    $('ul#nav li').removeAttr('id');

    $('ul#nav li:contains("Brand")').attr('id', 'current');
});