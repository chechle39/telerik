var customerController = function () {
    var self = this;
    this.initialize = function () {
    }
    $("#btnCancel").on('click', function () {
        console.log('xxx');
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });
    $("#closeModel").on('click', function () {
        console.log('xxx');
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });
    $("#showModel").on('click', function () {
        resetFormMaintainance();
        initRoleList();
        $('#exampleModal').modal('show');

    });

    $("#btnSave").on('click', function () {
        var numOfSam = $('#numOfSam').val();
        var customers = $('#customers').val();
        var contact = $('#contact').val();
        var requestNo = $('#requestNo').val();
        var vat = $('#vat').val();
        var datetimepicker = $('#datetimepicker').val();
        var datetimepickerReturn = $('#datetimepickerReturn').val();
        var piceList = $('#piceList').val();
        $.ajax({
            type: "POST",
            url: "/CustomerRequest/SaveEntity",
            data: {
                requestNo: requestNo,
                customerID: customers,
                receivceDate: datetimepicker,
                dateOfSendingResult: datetimepickerReturn,
                contactID: contact,
                numberSample: numOfSam,
                printVAT: vat,
            },
            dataType: "json",

            success: function () {
                console.log('success');
            },
            error: function () {
                console.log('error');
            }
        });
    });
}