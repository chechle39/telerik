var customerDetailController = function () {
    var self = this;
    var sampleListCount;
    var reponseGetById;
    this.initialize = function () {
        initForm();
    }
    
    $("#btnCancel").on('click', function () {
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });
    $("#closeModel").on('click', function () {
        $('#exampleModal').modal('hide');
        $('#exampleModal').css('display', 'none');
    });
   
    function initForm() {
        var requestNo = ["RequestNo", "SampleCode", "InLabCode"];
        var template = $('#table-template').html();
        var render = "";

        render += Mustache.render(template, {
            requestNo: document.getElementById("flag4").innerHTML,
            receivceDate: document.getElementById("flag3").innerHTML,
            dateOfSendingResult: document.getElementById("flag2").innerHTML,
            contactName: document.getElementById("flag6").innerHTML,
            contactEmail: document.getElementById("flag5").innerHTML,
            companyName: document.getElementById("flag7").innerHTML
        });
        $('#tbl-content').html(render);
        $.ajax({
            type: "GET",
            url: "/CustomerRequest/GetAnalysisByRequestNo",
            data: { requestNo: document.getElementById("flag4").innerHTML },
            dataType: "Json",
            success: function (response) {
                
                var gridData = $("#GridCustomerEdit").data("kendoGrid");
                myarr = [];
                if (response.length > 0) {
                    $('#simpleCode').val(response[0].sampleCode);
                    $('#innerCode').val(response[0].LVNCode);
                    $('#simpleName').val(response[0].sampleName);
                    $('#descriptionCustomer').val(response[0].sampleDescription);
                    $('#remarkToLab').val(response[0].remarkToLab);
                    $('#sampleMatrix').val(response[0].sampleMatrix);
                    $('#weight').val(response[0].weight);
                    $('#templateMark').val('');
                    $('#tat').val('');
                    var dataSource = new kendo.data.DataSource({
                        data: response[0].Data,
                        pageSize: 20,
                        change: function (e) {
                            specdata = []
                            let count = 0;
                            gridData.dataSource._data.reduce((r, o) => {
                                specdata.push(o);
                                if (o.analysisCode !== e.items[0].analysisCode) {

                                    count += parseFloat(o.Price);
                                }
                            }, {});
                            count += e.items[0].Price;
                            // selectedDataItems contains all selected data items
                            var template = $('#table-total').html();
                            var render = "";
                            render += Mustache.render(template, {
                                tong: parseFloat(count).toLocaleString('it-IT', { style: 'currency', currency: 'VND' }),
                            });
                            if (render !== undefined) {
                                $('#temlate').html(render);
                            }
                        }
                    });
                    gridData.setDataSource(dataSource);
                } else {
                    var requestNo = ["SampleCode", "InLabCode"];
                    $.ajax({
                        type: "POST",
                        url: "/GetCounter/GetCounterString",
                        data: JSON.stringify(requestNo),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (response) {
                            $('#simpleCode').val(response.sampleCode);
                            $('#innerCode').val(response.inLabCode);
                        },
                        error: function () {
                        }
                    });
                    var grid1 = $("#GridCustomerEdit").data("kendoGrid");

                    $('#simpleName').val('');
                    $('#descriptionCustomer').val('');
                    $('#remarkToLab').val('');
                    $('#sampleMatrix').val('');
                    $('#weight').val('');
                    $('#templateMark').val('');
                    $('#tat').val('');
                    var dataSource = new kendo.data.DataSource({
                        data: [],
                        pageSize: 20,
                    });
                    grid1.setDataSource(dataSource);
                }




                const data = { "req_per_page": 1, "page_no": 1 };
                pagination(data, parseInt(document.getElementById("flag").innerHTML));
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
    const pagination_visible_pages = 10;


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
            //if (reponseGetById.length > 0) {
            //    const a = {
            //        simpleName: reponseGetById[i].sampleName,
            //        simpleCode: reponseGetById[i].sampleCode,
            //        descriptionCustomer: reponseGetById[i].sampleDescription,
            //        innerCode: reponseGetById[i].LVNCode,
            //        remarkToLab: reponseGetById[i].remarkToLab,
            //        weight: reponseGetById[i].weight,
            //        sampleMatrix: reponseGetById[i].sampleMatrix,
            //        addSpecification: reponseGetById[i].specification,
            //        templateMark: '',
            //        tat: '',
            //        data: reponseGetById[i].Data
            //    };
            //    myarr.push(a);
            //}
            const a = { simpleName: i, simpleCode: '', descriptionCustomer: '', innerCode: '', remarkToLab: '', weight: '', sampleMatrix: '', addSpecification: '', templateMark: '', tat: '' };
            myarr.push(a);
        }
        const all_data = window.btoa(JSON.stringify(myarr));
        $(".pagination").empty();
        if (data.req_per_page !== 'ALL') {
            let pager = `<a href="#" id="prev_link" onclick=active_page('prev',\"${all_data}\",${data.req_per_page})><span class="k-icon k-i-arrow-60-left"></span></a>` +
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
            pager += `<a href="#" id="next_link" onclick=active_page('next',\"${all_data}\",${data.req_per_page})><span class="k-icon k-i-arrow-60-right"></span></a>`;
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


    var dialog = $('#dialogEdit'),
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
        title: "Edit Request",
        closable: true,
        modal: false,
        content: "",
        visible: false,
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

        var requestNo = $('#requestNoId').val();

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
                    var notification = $("#notificationEdit").data("kendoNotification");
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
                        receivceDate: response.receivceDate,
                        dateOfSendingResult: response.dateOfSendingResult,
                        contactName: itemSelected === undefined ? document.getElementById("flag6").innerHTML : itemSelected.contactName,
                        contactEmail: itemSelected === undefined ? document.getElementById("flag5").innerHTML: itemSelected.contactEmail,
                        companyName: itemSelected === undefined ? document.getElementById("flag7").innerHTML : itemSelected.companyName
                    });
                    if (render !== undefined) {
                        $('#tbl-content').html(render);

                    }
                    isCheck = false;
                    return true;
                },
                error: function () {
                    var notification = $("#notificationEdit").data("kendoNotification");
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
                    var notification = $("#notificationEdit").data("kendoNotification");
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
                        receivceDate: response.receivceDate,
                        dateOfSendingResult: response.dateOfSendingResult,
                        contactName: itemSelected === undefined ? document.getElementById("flag6").innerHTML : itemSelected.contactName,
                        contactEmail: itemSelected === undefined ? document.getElementById("flag5").innerHTML : itemSelected.contactEmail,
                        companyName: itemSelected === undefined ? document.getElementById("flag7").innerHTML : itemSelected.companyName
                    });
                    if (render !== undefined) {
                        $('#tbl-content').html(render);

                    }
                    isCheck = true;
                },
                error: function () {
                    var notification = $("#notificationEdit").data("kendoNotification");
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