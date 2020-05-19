var customerController = function () {
    var self = this;
    this.initialize = function () {
        initForm();
       
    }
    var sampleListCount;

    $("#btnCancel").on('click', function () {
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });
    $("#closeModel").on('click', function () {
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });

    function initForm() {
        var requestNo = "RequestNo";
         $.ajax({
            type: "GET",
            url: "/GetCounter/GetCounterString",
            data: { request: requestNo },
          //  dataType: "text",
            async: false,
            success: function (response) {
                $('#requestNo').val(response);
                $('#simpleCode').val("lalala");
                $('#innerCode').val("lalala1");
            },
            error: function () {

            }
        });

    }


    //paging fronent


    // on page load collect data to load pagination as well as table
    var myarr = [];

// on page load collect data to load pagination as well as table
const data = { "req_per_page": 1, "page_no": 1 };

// At a time maximum allowed pages to be shown in pagination div
const pagination_visible_pages = 5;


// hide pages from pagination from beginning if more than pagination_visible_pages
function hide_from_beginning(element) {
    if (element.style.display === "" || element.style.display === "block") {
        element.style.display = "none";
    } else {
        hide_from_beginning(element.nextSibling);
    }
}

// hide pages from pagination ending if more than pagination_visible_pages
function hide_from_end(element) {
    if (element.style.display === "" || element.style.display === "block") {
        element.style.display = "none";
    } else {
        hide_from_beginning(element.previousSibling);
    }
}

function checkClass(classList) {
    var a = [];
    for (var i = 0; i < classList.length; i++) {
        if (classList[i].className.split(' ').join('') === 'active') {
            a.push(classList[i]);
        }
    }

    return a;
}


// Render the table's row in table request-table
function render_table_rows(rows, req_per_page, page_no) {
    const response = JSON.parse(window.atob(rows));
    const resp = response.slice(req_per_page * (page_no - 1), req_per_page * page_no)
    $('#request-table').empty()
    $('#request-table').append('<tr><th>Index</th><th>Request No</th><th>Title</th></tr>');
    resp.forEach(function (element, index) {
        if (Object.keys(element).length > 0) {
            const { req_no, title } = element;
            const td = `<tr><td>${++index}</td><td>${req_no}</td><td>${title}</td></tr>`;
            $('#request-table').append(td)
        }
    });
}   

// Pagination logic implementation
function pagination(data, lenth) {
    for (var i = 0; i < lenth; i++) {
        const a = { simpleName: i, simpleCode: '', descriptionCustomer: '', innerCode: '', remarkToLab: '', weight: '', sampleMatrix: '', addSpecification: '', templateMark: '', tat: '' };
        myarr.push(a);
    }
    const all_data = window.btoa(JSON.stringify(myarr));
    $(".pagination").empty();
    if (data.req_per_page !== 'ALL') {
        let pager = `<a href="#" id="prev_link" onclick=active_page('prev',\"${all_data}\",${data.req_per_page})>&laquo;</a>` +
            `<a href="#" class="active" onclick=active_page(this,\"${all_data}\",${data.req_per_page})>1</a>`;
        const total_page = Math.ceil(parseInt(myarr.length) / parseInt(data.req_per_page));
        if (total_page < pagination_visible_pages) {
            render_table_rows(all_data, data.req_per_page, data.page_no);
            for (let num = 2; num <= total_page; num++) {
                pager += `<a href="#" onclick=active_page(this,\"${all_data}\",${data.req_per_page})>${num}</a>`;
            }
        } else {
            render_table_rows(all_data, data.req_per_page, data.page_no);
            for (let num = 2; num <= pagination_visible_pages; num++) {
                pager += `<a href="#" onclick=active_page(this,\"${all_data}\",${data.req_per_page})>${num}</a>`;
            }
            for (let num = pagination_visible_pages + 1; num <= total_page; num++) {
                pager += `<a href="#" style="display:none;" onclick=active_page(this,\"${all_data}\",${data.req_per_page})>${num}</a>`;
            }
        }
        pager += `<a href="#" id="next_link" onclick=active_page('next',\"${all_data}\",${data.req_per_page})>&raquo;</a>`;
        $(".pagination").append(pager);
    } else {
        render_table_rows(all_data, myarr.length, 1);
    }
}

//calling pagination function
pagination(data, myarr);


// trigger when requests per page dropdown changes
function filter_requests() {
    const data = { "req_per_page": 5, "page_no": 1 };
    pagination(data, myarr);
    }


    var dialog = $('#dialog'),
        undo = $("#undo");

    undo.click(function () {
        dialog.data("kendoDialog").open();
        undo.fadeOut();
    });

    function onClose() {
        undo.fadeIn();
    }

    dialog.kendoDialog({
        width: "450px",
        title: "New Request",
        closable: false,
        modal: false,
        content: "",
        actions: [
            { text: 'Cancel' },
            {
                text: 'Save', primary: true,
                action: onOK,
                //action: function (e) {
                
                //}
                
            }
        ],
     //   close: onClose
    });


    function onOK(e) {
        var numOfSam = $('#numOfSam').val();

        var customers = $('#customers').val();

        var contact = $('#contact').val();

        var requestNo = $('#requestNo').val();

        var vat = $('#vat').val();

        var datetimepicker = $('#datetimepicker').val();
        var datetimepickerReturn = $('#datetimepickerReturn').val();
        var lenthx;
                   // var piceList = $('#piceList').val();
                    if ($('#requestNoId').val() === '') {
                        sampleListCount = parseInt($('#numOfSam').val());
                        var request = {
                            requestNo: requestNo,
                            customerID: customers,
                            receivceDate: datetimepicker,
                            dateOfSendingResult: datetimepickerReturn,
                            contactID: contact,
                            numberSample: numOfSam,
                            printVAT: vat,
                        };
                        $.ajax({
                            type: "POST",
                            url: "/CustomerRequest/SaveEntity",
                            data: JSON.stringify(request),
                            dataType: 'json',
                            contentType: 'application/json',
                            processData: false,
                            success: function (response) {
                                lenthx = response;
                                isCheck = true;
                                var notification = $("#notification").data("kendoNotification");
                                notification.show({
                                    message: "Save Successful"
                                }, "success");
                                myarr = [];
                                $('#requestNoId').val(response.requestNo);
                                $('#isCheck').show();
                                const data = { "req_per_page": 1, "page_no": 1 };
                                pagination(data, sampleListCount);
                                $('#exampleModal').modal('hide');
                                $('#exampleModal').css('display', 'none');
                                var template = $('#table-template').html();
                                var render = "";

                                render += Mustache.render(template, {
                                    requestNo: response.requestNo,
                                    receivceDate: drlab.dateTimeFormatJson(response.receivceDate),
                                    dateOfSendingResult: drlab.dateTimeFormatJson(response.dateOfSendingResult),
                                    contactName: itemSelected.contactName,
                                    contactEmail: itemSelected.contactEmail,
                                    companyName: itemSelected.companyName
                                });
                                if (render !== undefined) {
                                    $('#tbl-content').html(render);

                                }
                                isCheck = false;
                                return true;
                            },
                            error: function () {
                                var notification = $("#notification").data("kendoNotification");
                                notification.show({
                                    title: "Wrong Save",
                                    message: "Save error check requestNo"
                                }, "error");
                                var dialog = $('#dialog');
                                dialog.data("kendoDialog").open();
                            },

                        })
                    } else {
                        var request = {
                            requestNo: document.getElementById("requestNo").innerHTML,
                            customerID: customers,
                            receivceDate: datetimepicker,
                            dateOfSendingResult: datetimepickerReturn,
                            contactID: contact,
                            numberSample: numOfSam,
                            printVAT: vat,
                        };
                        sampleListCount = parseInt($('#numOfSam').val());
                        $.ajax({
                            type: "POST",
                            url: "/CustomerRequest/UpdateEntity",
                            data: JSON.stringify(request),
                            dataType: "json",
                            contentType: "application/json",
                            processData: false,
                            success: function (response) {
                                isCheck = true;
                                var notification = $("#notification").data("kendoNotification");
                                notification.show({
                                    message: "Update Successful"
                                }, "success");
                                myarr = [];
                                $('#requestNoId').val(response.requestNo);
                                $('#isCheck').show();
                                const data = { "req_per_page": 1, "page_no": 1 };
                                pagination(data, sampleListCount);
                                $('#exampleModal').modal('hide');
                                $('#exampleModal').css('display', 'none');
                                var template = $('#table-template').html();
                                var render = "";

                                render += Mustache.render(template, {
                                    requestNo: response.requestNo,
                                    receivceDate: drlab.dateTimeFormatJson(response.receivceDate),
                                    dateOfSendingResult: drlab.dateTimeFormatJson(response.dateOfSendingResult),
                                    contactName: itemSelected.contactName,
                                    contactEmail: itemSelected.contactEmail,
                                    companyName: itemSelected.companyName
                                });
                                if (render !== undefined) {
                                    $('#tbl-content').html(render);

                                }
                                isCheck = true;
                            },
                            error: function () {
                                var notification = $("#notification").data("kendoNotification");
                                notification.show({
                                    title: "Wrong Save",
                                    message: "Uppdate error check requestNo"
                                }, "error");
                                var dialog = $('#dialog');
                                dialog.data("kendoDialog").open();
                            }
                        });
                    }

    }
}