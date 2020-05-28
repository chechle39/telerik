
var ManagementRequestController = function () {
    var startDate;
    var endDate;

    var self = this;
    this.initialize = function () {
        loadData();

    }

    function loadData() {
        var date = paramDate();
        var dataCus = [];
        if ($("#multiselect").data("kendoMultiSelect") !== undefined) {
            dataCus = $("#multiselect").data("kendoMultiSelect")._old;
        }
        var start = document.getElementById("flagStart").innerHTML;
        var end = document.getElementById("flagEnd").innerHTML;
        if (start !== "") {
            GetDataToDate(start, end, dataCus);
        } else {
            GetDataToDate(date.startDate, date.endDate, dataCus);
        }

    };

    function paramDate() {
        var curr = new Date;
        var first = curr.getDate() - curr.getDay() + 1;
        var last = first + 6;
        var firstday = new Date(curr.setDate(first)).toUTCString();
        var lastday = new Date(curr.setDate(last)).toUTCString();

        const data = {
            startDate: convertDate(new Date(firstday).toLocaleDateString()),
            endDate: convertDate(new Date(lastday).toLocaleDateString()),
        }

        return data;
    }

    function convertDate(date) {
        var b = date.split('/');
        var d = b[0] + "/" + b[1] + "/" + b[2]
        return d;
    }

    var dialog = $('#dialog');


    dialog.kendoDialog({
        width: "360px",
        title: "Search",
        closable: true,
        modal: false,
        content: "",
        visible: false,
        actions: [
            { text: 'Cancel' },
            {
                text: 'Search', primary: true,
                action: okSearch,
                //action: function (e) {

                //}

            }
        ],
        //   close: onClose
    });

    function okSearch(e) {
        switch (checkDate) {
            case 0:
                loadData();
                break;
            case 1:
                searchData(convertDate(startDate1.toLocaleDateString()), convertDate(endDate1.toLocaleDateString()));
                break;
            case 2:
                var initialSart = datepicker.value.split("/");
                var initialTo = datepickerto.value.split("/");
                searchData(datepicker.value, datepickerto.value);
                break;
            default:
                loadData();
                break;
        }
    }

    function searchData(start, end) {
        var dataCus = $("#multiselect").data("kendoMultiSelect")._old;
        $.ajax({
            type: "GET",
            url: "/ManagementRequest/GetManagementRequestList",
            data: {
                startDate: start,
                endDate: end,
                customer: JSON.stringify(dataCus)
            },
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) {
                console.log(response);
                var grid = $("#Grid").data("kendoGrid");
                var dataSource = new kendo.data.DataSource({
                    data: response,
                    pageSize: 20,
                    schema: {
                        model: {
                            id: "requestNo"
                        }
                    }
                });
                grid.setDataSource(dataSource);
                var dateTemplate = $('#date-templateData').html();
                var renderDateTem = "";
                renderDateTem += Mustache.render(dateTemplate, {
                    day: start + '-' + end
                });
                $('#dayTem').html(renderDateTem);
            },
            error: function (status) {
            }
        });
    }
}

function GetDataToDate(start, end, dataCus) {
    $.ajax({
        type: "GET",
        url: "/ManagementRequest/GetManagementRequestList",
        data: {
            startDate: start,
            endDate: end,
            customer: JSON.stringify(dataCus)
        },
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) {
            var grid = $("#Grid").data("kendoGrid");
            var dataSource = new kendo.data.DataSource({
                data: response,
                pageSize: 20,
                schema: {
                    model: {
                        id: "requestNo"
                    }
                }
            });
            grid.setDataSource(dataSource);
            var dateTemplate = $('#date-templateData').html();
            var renderDateTem = "";
            renderDateTem += Mustache.render(dateTemplate, {
                day: start + '-' + end
            });
            $('#dayTem').html(renderDateTem);
        },
        error: function (status) {
        }
    });
}
