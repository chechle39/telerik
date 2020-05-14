var customerController = function () {
    var self = this;
    this.initialize = function () {
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
    $("#showModel").on('click', function () {
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
        if ($('#requestNoId').val() === '') {
            sampleListCount = parseInt($('#numOfSam').val());
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

                success: function (response) {
                    drlab.notify('Update page successful', 'success');
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
                        contactEmail: itemSelected.contactEmail
                    });
                    if (render !== undefined) {
                        $('#tbl-content').html(render);

                    }
                },
                error: function () {
                    console.log('error');
                }
            });
        } else {
            sampleListCount = parseInt($('#numOfSam').val());
            $.ajax({
                type: "POST",
                url: "/CustomerRequest/UpdateEntity",
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

                success: function (response) {
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
                        contactEmail: itemSelected.contactEmail
                    });
                    if (render !== undefined) {
                        $('#tbl-content').html(render);

                    }
                },
                error: function () {
                    console.log('error');
                }
            });
        }
        
    });

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
// load data and style for active page
//function active_page(element, rows, req_per_page) {

//    var current_page = checkClass(document.getElementsByClassName('active'));
//    var next_link = document.getElementById('next_link');
//    var prev_link = document.getElementById('prev_link');
//    var next_tab = current_page[0].nextSibling;
//    var prev_tab = current_page[0].previousSibling;
//    current_page[0].className = current_page[0].className.replace("active", "");
//    if (element === "next") {
//        if (parseInt(next_tab.text).toString() === 'NaN') {
//            next_tab.previousSibling.className += " active";
//            next_tab.setAttribute("onclick", "return false");
//        } else {
//            next_tab.className += " active"
//            render_table_rows(rows, parseInt(req_per_page), parseInt(next_tab.text));
//            if (prev_link.getAttribute("onclick") === "return false") {
//                prev_link.setAttribute("onclick", `active_page('prev',\"${rows}\",${req_per_page})`);
//            }
//            if (next_tab.style.display === "none") {
//                next_tab.style.display = "block";
//                hide_from_beginning(prev_link.nextSibling)
//            }
//        }
//    } else if (element === "prev") {
//        if (parseInt(prev_tab.text).toString() === 'NaN') {
//            prev_tab.nextSibling.className += " active";
//            prev_tab.setAttribute("onclick", "return false");
//        } else {
//            prev_tab.className += " active";
//            render_table_rows(rows, parseInt(req_per_page), parseInt(prev_tab.text));
//            if (next_link.getAttribute("onclick") === "return false") {
//                next_link.setAttribute("onclick", `active_page('next',\"${rows}\",${req_per_page})`);
//            }
//            if (prev_tab.style.display === "none") {
//                prev_tab.style.display = "block";
//                hide_from_end(next_link.previousSibling)
//            }
//        }
//    } else {
//        element.className += "active";
//        render_table_rows(rows, parseInt(req_per_page), parseInt(element.text));
//        if (prev_link.getAttribute("onclick") === "return false") {
//            prev_link.setAttribute("onclick", `active_page('prev',\"${rows}\",${req_per_page})`);
//        }
//        if (next_link.getAttribute("onclick") === "return false") {
//            next_link.setAttribute("onclick", `active_page('next',\"${rows}\",${req_per_page})`);
//        }
//    }
//}

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
}