$(document).ready(function () {
    $('ul#nav li').removeAttr('id');
    $('ul#nav li:contains("Brand")').attr('id', 'current');
    $("#clientBrandManager").prop("disabled", true);
    $("#clientBrandManager").hide();
    $("#agencyBrandManager").prop("disabled", true);
    $("#agencyBrandManager").hide();
    //$("#tblclientBrandManager").hide();
    //$("#tblagencyBrandManager").hide();
    
    $("#drpClient").change(function () {
        if ($('#drpClient :selected').val())
        {
            $.ajax({
                url: "/Brand/GetClientDetail",
                data: {
                    "clientID": $('#drpClient :selected').val(),
                    "type": 1                    
                },
                success: function (data) {
                    $("#clientBrandManager").empty();
                    $("#clientBrandManager").append("<option value='0'>-- Select Brand Manager --</option>");

                    for (var i = 0; i < data.length; i++) {
                        $("#clientBrandManager").append("<option value='" + data[i].BrandManagerID + "'>" + data[i].Name + "</option>");
                    }
                    $("#clientBrandManager").prop("disabled", false);
                    $("#clientBrandManager").show();
                }
            });
            //alert($('#drpAgency :selected').val());
        }        
    })

    $("#clientBrandManager").change(function () {
        $.ajax({
            url: "/BrandManager/GetBrandManagerDetail",
            data: {
                "id": $('#clientBrandManager :selected').val()
            },
            success: function (data) {
                $("#cBMName").text(data.Name);
                $("#cBMEmail").text(data.Email);
                $("#cBMAddress").text(data.Address)
                $("#cBMPhone").text(data.Phone)
                $("#cBMCity").text(data.City)
                $("#cBMState").text(data.State)
                $("#cBMCountry").text(data.Country)
                $("#cBMPin").text(data.PINCode)
                $("#tblclientBrandManager").show();
            }
        });
    })


    $("#drpAgency").change(function () {
        if ($('#drpAgency :selected').val()) {
            $.ajax({
                url: "/Brand/GetClientDetail",
                data: {
                    "clientID": $('#drpAgency :selected').val(),
                    "type": 2
                },
                success: function (data) {
                    $("#agencyBrandManager").empty();
                    $("#agencyBrandManager").append("<option value='0'>-- Select Brand Manager --</option>");

                    for (var i = 0; i < data.length; i++) {
                        $("#agencyBrandManager").append("<option value='" + data[i].BrandManagerID + "'>" + data[i].Name + "</option>");
                    }
                    $("#agencyBrandManager").prop("disabled", false);
                    $("#agencyBrandManager").show();
                }
            });
        }
    })

    $("#agencyBrandManager").change(function () {
        $.ajax({
            url: "/BrandManager/GetBrandManagerDetail",
            data: {
                "id": $('#clientBrandManager :selected').val()
            },
            success: function (data) {
                $("#aBMName").text(data.Name);
                $("#aBMEmail").text(data.Email);
                $("#aBMAddress").text(data.Address)
                $("#aBMPhone").text(data.Phone)
                $("#aBMCity").text(data.City)
                $("#aBMState").text(data.State)
                $("#aBMCountry").text(data.Country)
                $("#aBMPin").text(data.PINCode)
                $("#tblagencyBrandManager").show();
            }
        });
    })

});