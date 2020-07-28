
var UserController = function () {

    this.initialize = function () {
        loadData();
        registerEvents();
    }
    function registerEvents() {
        $('#userForm').validate({
            errorClass: 'validate-announc',
            ignore: [],
            lang: 'en',
            rules: {
                fullName: { required: true },
                address: { required: true },
                passwordDrlab: {
                    required: true,
                    minlength: 6
                },
                comfirmPasswordDrlab: {
                    equalTo: "#passwordDrlab"
                },
                email: {
                    required: true,
                    email: true
                },
                role: {
                    required: true,
                }
            },
            messages: {
                fullName: 'Please enter fullname',
                address: 'Please enter address',
            }
        });
        $('#userFormEdit').validate({
            errorClass: 'validate-announc',
            ignore: [],
            lang: 'en',
            rules: {
                fullNameEdit: { required: true },
                addressEdit: { required: true },

                emailEdit: {
                    required: true,
                    email: true
                },
                roleEdit: {
                    required: true,
                }
            },
            messages: {
                fullName: 'Please enter fullname',
                address: 'Please enter address',
            }
        });
    }
    var dialog = $('#dialog');
    var dialogEdit = $('#dialogEdit');
    dialogEdit.kendoDialog({
        width: "500px",
        title: "Edit user",
        closable: true,
        modal: false,
        content: "",
        visible: false,
        actions: [
            { text: 'Cancel' },
            {
                text: 'Save', primary: true,
                action: okEditSave,
                //action: function (e) {

                //}

            }
        ],
        //   close: onClose
    });
    dialog.kendoDialog({
        width: "500px",
        title: "Add new user",
        closable: true,
        modal: false,
        content: "",
        visible: false,
        actions: [
            { text: 'Cancel' },
            {
                text: 'Save', primary: true,
                action: okSave,
                //action: function (e) {

                //}

            }
        ],
        //   close: onClose
    });
    function okSave(e) {
        // resetForm();
        var role;
        var comboRole = $("#role").data("kendoComboBox");
        if ($('#role').val().length > 0) {
             role = comboRole.dataSource._pristineData.filter(x => x.Id === parseInt($('#role').val()))[0].Name;
        } else {
            role = null;
        }
      
        const request = {
            id: 0,
            fullName: $('#fullName').val(),
            email: $('#email').val(),
            password: $('#passwordDrlab').val(),
            userName: $('#email').val(),
            address: $('#address').val(),
            phoneNumber: $('#phoneNumber').val(),
            status: $("[name='DoctoralLevelSttId']:checked")[0].value === 'Active' ? 1: 0,
            gender: $("[name='DoctoralLevelId']:checked")[0].value,
            roles: role !== null ? [role]: null,
        }
        console.log(request);

        if ($('#userForm').valid()) {
            $.ajax({
                type: "POST",
                url: "/User/SaveEntity",
                data: JSON.stringify(request),
                contentType: 'application/json',
                dataType: "json",

                success: function () {
                    var notification = $("#notification").data("kendoNotification");
                    notification.show({
                        message: "Save Successful"
                    }, "success");
                    loadData();
                },
                error: function () {
                    var notification = $("#notification").data("kendoNotification");
                    notification.show({
                        title: "Wrong Save",
                        message: "User exist!!"
                    }, "error");
                }
            });
        } else {
            return false;
        }
       
    }
    function okEditSave(e) {
        // resetForm();
        var comboRole = $("#roleEdit").data("kendoComboBox");
        var role;
        if ($('#roleEdit').val().length > 0) {
            role = comboRole.dataSource._pristineData.filter(x => x.Id === parseInt($('#roleEdit').val()))[0].Name;
        } else {
            role = null;
        }
        const request = {
            id: $('#id').val(),
            fullName: $('#fullNameEdit').val(),
            email: $('#emailEdit').val(),
            userName: $('#emailEdit').val(),
            address: $('#addressEdit').val(),
            phoneNumber: $('#phoneNumberEdit').val(),
            status: $("[name='DoctoralLevelSttId']:checked")[0].value === 'Active' ? 1 : 0,
            gender: $("[name='DoctoralLevelId']:checked")[0].value,
            roles: role !== null ? [role] : null,
        }
        console.log(request);

        if ($('#userFormEdit').valid()) {
            $.ajax({
                type: "POST",
                url: "/User/UpdateEntity",
                data: JSON.stringify(request),
                contentType: 'application/json',
                dataType: "json",

                success: function () {
                    var notification = $("#notification").data("kendoNotification");
                    notification.show({
                        message: "Update Successful"
                    }, "success");
                    loadData();
                },
                error: function () {
                    var notification = $("#notification").data("kendoNotification");
                    notification.show({
                        title: "Wrong Save",
                        message: "Update error"
                    }, "error");
                }
            });
        } else {
            return false;
        }

    }
    function loadData() {
        $.ajax({
            type: "GET",
            url: "/User/GetUser",
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
                            id: "Id"
                        }
                    }
                });
                grid.setDataSource(dataSource);
                
            },
            error: function (status) {
            }
        });
    }
    function resetForm() {
        fullName: $('#fullName').val('');
        birthDay: $('#datepicker').val('');
        email: $('#email').val('');
        password: $('#passwordDrlab').val('');
        userName: $('#email').val('');
        address: $('#address').val('');
        phoneNumber: $('#phoneNumber').val('');
        status: $("[name='status']:checked")[0].labels[0].innerHTML;
        gender: $("[name='gender']:checked")[0].labels[0].innerHTML;
        roles: $('#role').val('');

    }

}

