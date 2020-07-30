var recordResultController = function () {
    var self = this;
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
    var dialogRubber = $('#dialogRubber');
    dialogRubber.kendoDialog({
        width: "1000px",
        title: "PHÂN HẠNG CAO SU SVR",
        closable: true,
        modal: false,
        content: "",
        visible: false,

        actions: [
            { text: 'Cancel' },
            {
                text: 'Save', primary: true,
                action: onRubber,

            }
        ],
        //   close: onClose
    });
    function onRubber() {
        var combobox = $("#chiTieu").data("kendoDropDownList");
        if (combobox._old === "0") {
            var kendoWindow = $("<div />").kendoDialog({
                title: "Confirm",
                resizable: false,
                modal: true,
                actions: [
                    { text: 'No', primary: true, },
                    {
                        text: 'Yes',
                    }
                ],
            });

            kendoWindow.data("kendoDialog")
                .content($("#select-confirmation").html()).open();

            kendoWindow
                .find(".delete-confirm,.delete-cancel")
                .click(function () {
                    if ($(this).hasClass("delete-confirm")) {

                    }

                    kendoWindow.data("kendoDialog").close();
                })
                .end()
        }
        if (combobox._old === "0") {
            return;
        }
        var arr = [];
        var gridx = $("#GridRubber").data("kendoGrid");
        for (var i = 0; i < gridx.columns.length; i++) {
            if (gridx.columns[i].field !== "MauSo") {
                for (var index = 0; index < gridx._data.length; index++) {
                    const obj = {
                        iD: 0,
                        sampleCode: $('#simpleCode').val(),
                        columName: gridx.columns[i].field,
                        value: gridx._data[index][gridx.columns[i].field],
                        Denominator: gridx._data[index]["MauSo"],
                        dKSVR: combobox.text(),
                        requestNo: document.getElementById("flag4").innerHTML,
                    };
                    arr.push(obj);
                };
            }
            
        }

        $.ajax({
            type: "POST",
            url: "/RecordResult/CreateFieldTable",
            data: JSON.stringify(arr),
            dataType: 'json',
            contentType: 'application/json',
            processData: false,
            success: function (response) {
                var data = handerDataGridDeleted(response);


                $.ajax({
                    type: "POST",
                    url: "/RecordResult/UpdateEntity",
                    data: JSON.stringify(data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        const checkUrl = window.location.pathname;
                        var grid = $("#Grid").data("kendoGrid");
                        var dataSource = new kendo.data.DataSource({
                            data: data,
                            pageSize: 20,
                            schema: {

                                model: {
                                    id: "AnalysisCode",
                                    fields: {
                                        specification: {
                                            editable: false
                                        },
                                        Mark: {
                                            editable: false
                                        },
                                        method: {
                                            editable: false

                                        },
                                        LOD: {
                                            editable: false

                                        },

                                        unit: {
                                            editable: false

                                        },

                                        ExpectationDate: {
                                            editable: false

                                        },
                                        ReviewResult: {
                                            editable: false
                                        },
                                        Result: {
                                            editable: checkUrl === '/RecordResult/RiviewRequest/' ? false : true
                                        },
                                        ResultText: {
                                            editable: checkUrl === '/RecordResult/RiviewRequest/' ? false : true
                                        },
                                    }
                                }
                            }
                        });
                        grid.setDataSource(dataSource);
                    },
                    error: function () {


                    }
                });
            },
            error: function () {
               
            },

        })
    }
    function initForm() {

        var requestNo = ["RequestNo", "SampleCode", "InLabCode"];
        var template = $('#table-template').html();
        var render = "";
        const checkUrl = window.location.pathname;
        render += Mustache.render(template, {
            requestNo: document.getElementById("flag4").innerHTML,
            receivceDate: document.getElementById("flag3").innerHTML,
            dateOfSendingResult: document.getElementById("flag2").innerHTML,
            contactName: document.getElementById("flag6").innerHTML,
            contactEmail: document.getElementById("flag5").innerHTML,
            companyName: document.getElementById("flag7").innerHTML
        });
        $('#tbl-content').html(render);
        var url = '';
        if (checkUrl === '/RecordResult/ApproveResult/') {
            url = '/RecordResult/GetRecordResulAccepttList';
        } else if (checkUrl === '/RecordResult/RiviewRequest/')  {
            url = '/RecordResult/GetRecordResultList';
        }
        else {
            url = '/RecordResult/GetRecordResultDapperList';
        }
        $.ajax({
            type: "GET",
            url: url,
            data: { requestNo: document.getElementById("flag4").innerHTML },
            dataType: "json",
            success: function (response) {

                myarr = [];
                reponseGetById = response;
                if (response.length > 0) {
                    $('#simpleCode').val(response[0].sampleCode);
                    $('#innerCode').val(response[0].LVNCode);
                    $('#simpleName').val(response[0].sampleName);
                    $('#descriptionCustomer').val(response[0].sampleDescription);
                    $('#remarkToLab').val(response[0].remarkToLab);
                    $('#sampleMatrix').val(response[0].SampleMatrix);
                    $('#weight').val(response[0].weight);
                    $('#templateMark').val('');
                    $('#tat').val('');
                    if (response[0].Data !== null) {
                        var grid = $("#Grid").data("kendoGrid");
                        var dataSource = new kendo.data.DataSource({
                            data: response[0].Data,
                            pageSize: 20,
                            schema: {

                                model: {
                                    id: "AnalysisCode",
                                    fields: {
                                        specification: {
                                            editable: false
                                        },
                                        Mark: {
                                            editable: false
                                        },
                                        method: {
                                            editable: false

                                        },
                                        LOD: {
                                            editable: false

                                        },

                                        unit: {
                                            editable: false

                                        },

                                        ExpectationDate: {
                                            editable: false

                                        },
                                        ReviewResult: {
                                            editable: false
                                        },
                                        Result: {
                                            editable: checkUrl === '/RecordResult/RiviewRequest/' ? false : true
                                        },
                                        ResultText: {
                                            editable: checkUrl === '/RecordResult/RiviewRequest/' ? false : true
                                        },
                                    }
                                }
                            }
                        });
                        grid.setDataSource(dataSource);
                        grid.table.on('keydown', function (e) {
                            if (e.keyCode === 40 && $($(e.target).closest('.k-edit-cell'))[0]) {
                                e.preventDefault();
                                var currentNumberOfItems = grid.dataSource.view().length;
                                var row = $(e.target).closest('tr').index();
                                var col = grid.cellIndex($(e.target).closest('td'));

                                var dataItem = grid.dataItem($(e.target).closest('tr'));
                                var field = grid.columns[col].field;
                                var value = $(e.target).val();
                                dataItem.set(field, value);

                                if (row >= 0 && row < currentNumberOfItems && col >= 0 && col < grid.columns.length) {
                                    var nextCellRow = row;
                                    var nextCellCol = col;

                                    if (e.shiftKey) {
                                        if (nextCellRow - 1 < 0) {
                                            nextCellRow = currentNumberOfItems - 1;
                                            nextCellCol--;
                                        } else {
                                            nextCellRow--;
                                        }
                                    } else {
                                        if (nextCellRow + 1 >= currentNumberOfItems) {
                                            nextCellRow = 0;
                                            nextCellCol++;
                                        } else {
                                            nextCellRow++;
                                        }
                                    }

                                    if (nextCellCol >= grid.columns.length || nextCellCol < 0) {
                                        return;
                                    }

                                    // wait for cell to close and Grid to rebind when changes have been made
                                    setTimeout(function () {
                                        grid.editCell(grid.tbody.find("tr:eq(" + nextCellRow + ") td:eq(" + nextCellCol + ")"));
                                    });
                                }
                            }
                        });
                    } else {
                        var grid = $("#Grid").data("kendoGrid");
                        var dataSource = new kendo.data.DataSource({
                            data: [],
                            pageSize: 20,
                        });
                        grid.setDataSource(dataSource);
                        grid.table.on('keydown', function (e) {
                            if (e.keyCode === 40 && $($(e.target).closest('.k-edit-cell'))[0]) {
                                e.preventDefault();
                                var currentNumberOfItems = grid.dataSource.view().length;
                                var row = $(e.target).closest('tr').index();
                                var col = grid.cellIndex($(e.target).closest('td'));

                                var dataItem = grid.dataItem($(e.target).closest('tr'));
                                var field = grid.columns[col].field;
                                var value = $(e.target).val();
                                dataItem.set(field, value);

                                if (row >= 0 && row < currentNumberOfItems && col >= 0 && col < grid.columns.length) {
                                    var nextCellRow = row;
                                    var nextCellCol = col;

                                    if (e.shiftKey) {
                                        if (nextCellRow - 1 < 0) {
                                            nextCellRow = currentNumberOfItems - 1;
                                            nextCellCol--;
                                        } else {
                                            nextCellRow--;
                                        }
                                    } else {
                                        if (nextCellRow + 1 >= currentNumberOfItems) {
                                            nextCellRow = 0;
                                            nextCellCol++;
                                        } else {
                                            nextCellRow++;
                                        }
                                    }

                                    if (nextCellCol >= grid.columns.length || nextCellCol < 0) {
                                        return;
                                    }

                                    // wait for cell to close and Grid to rebind when changes have been made
                                    setTimeout(function () {
                                        grid.editCell(grid.tbody.find("tr:eq(" + nextCellRow + ") td:eq(" + nextCellCol + ")"));
                                    });
                                }
                            }
                        });
                    }

                } else {

                    $('#simpleCode').val('');
                    $('#innerCode').val('');
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
                    grid1.table.on('keydown', function (e) {
                        if (e.keyCode === 40 && $($(e.target).closest('.k-edit-cell'))[0]) {
                            e.preventDefault();
                            var currentNumberOfItems = grid1.dataSource.view().length;
                            var row = $(e.target).closest('tr').index();
                            var col = grid1.cellIndex($(e.target).closest('td'));

                            var dataItem = grid1.dataItem($(e.target).closest('tr'));
                            var field = grid1.columns[col].field;
                            var value = $(e.target).val();
                            dataItem.set(field, value);

                            if (row >= 0 && row < currentNumberOfItems && col >= 0 && col < grid.columns.length) {
                                var nextCellRow = row;
                                var nextCellCol = col;

                                if (e.shiftKey) {
                                    if (nextCellRow - 1 < 0) {
                                        nextCellRow = currentNumberOfItems - 1;
                                        nextCellCol--;
                                    } else {
                                        nextCellRow--;
                                    }
                                } else {
                                    if (nextCellRow + 1 >= currentNumberOfItems) {
                                        nextCellRow = 0;
                                        nextCellCol++;
                                    } else {
                                        nextCellRow++;
                                    }
                                }

                                if (nextCellCol >= grid1.columns.length || nextCellCol < 0) {
                                    return;
                                }

                                // wait for cell to close and Grid to rebind when changes have been made
                                setTimeout(function () {
                                    grid1.editCell(grid1.tbody.find("tr:eq(" + nextCellRow + ") td:eq(" + nextCellCol + ")"));
                                });
                            }
                        }
                    });
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

    function handerDataGridDeleted(request) {
        var myGrid = [];
        var data = handerDataGrid();
        for (var i = 0; i < data.length; i++) {
            switch (data[i].SpecCode) {
                case "ML":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.ML,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "Color":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.Color,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "PRI":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.PRI,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "P0":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.P0,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "Nitrogen":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.Nitro,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "Volatile matter":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.Volatilematter,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "Ash":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.Ash,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                case "Dirt":
                    var object = {
                        ExpectationDate: data[i].ExpectationDate,
                        LOD: data[i].LOD,
                        Mark: data[i].Mark,
                        method: data[i].method,
                        Result: request.Dirt,
                        ResultText: data[i].ResultText,
                        ReviewResult: data[i].ReviewResult,
                        WOID: data[i].WOID,
                        specification: data[i].specification,
                        unit: data[i].unit,
                        LVNCode: data[i].LVNCode,
                        AnalysisCode: data[i].AnalysisCode
                    };
                    myGrid.push(object);
                    break;
                default:
                // code block
            }
            
        }
        return myGrid;
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
        for (var i = 0; i < parseInt(document.getElementById("flag").innerHTML); i++) {
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
        closable: false,
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