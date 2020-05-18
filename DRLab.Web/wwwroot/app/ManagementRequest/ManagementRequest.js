
var ManagementRequestController = function () {
    var startDate;
    var endDate;
 
    var self = this;
    this.initialize = function () {
        loadData();
    }

    function loadData() {
        var date = paramDate();
        var dataCus = $("#multiselect").data("kendoMultiSelect")._old;
        $.ajax({
            type: "GET",
            url: "/ManagementRequest/GetManagementRequestList",
            data: {
                startDate: date.startDate,
                endDate: date.endDate,
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
                });
                grid.setDataSource(dataSource);
            },
            error: function (status) {
                console.log(status);
            }
        });
    };
  
    function paramDate() {
        var curr = new Date;
        var first = curr.getDate() - curr.getDay() + 1;
        var last = first + 6;
        var firstday = new Date(curr.setDate(first)).toUTCString();
        var lastday = new Date(curr.setDate(last)).toUTCString();

        const data = {
            startDate: new Date(firstday).toLocaleDateString(),
            endDate: new Date(lastday).toLocaleDateString(),
        }

        return data;
    }

    var dialog = $('#dialog');


    dialog.kendoDialog({
        width: "400px",
        title: "Search",
        closable: false,
        modal: false,
        content: "",
        actions: [
            { text: 'Cancel' },
            {
                text: 'Save', primary: true,
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
                searchData(startDate1.toLocaleDateString(), endDate1.toLocaleDateString());
                break;
            case 2:
                var initialSart = datepicker.value.split("/");
                var initialTo = datepickerto.value.split("/");
                searchData([initialSart[1], initialSart[0], initialSart[2]].join('/'), [initialTo[1], initialTo[0], initialTo[2]].join('/'));
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
                });
                grid.setDataSource(dataSource);
            },
            error: function (status) {
            }
        });
    }
}