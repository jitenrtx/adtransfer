$(document).ready(function () {
    $('ul#nav li').removeAttr('id');

    $('ul#nav li:contains("Client")').attr('id', 'current');
});