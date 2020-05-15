var ManagementRequestController = function () {
    var self = this;
    this.initialize = function () {
        loadData();
    }
    var startDate;
    var endDate;
    function loadData(isPageChanged) {
        var date = paramDate();
        $.ajax({
            type: "GET",
            url: "/ManagementRequest/GetManagementRequestList",
            data: {
                startDate: date.startDate,
                endDate: date.endDate
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
}