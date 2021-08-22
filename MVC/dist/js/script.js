$(document).ready(function () {

    $('.datetimepicker').datepicker().on('change', function () {
        $('.datepicker').hide();
    });

    getEmployees();

    $('#txtSearch').on('keyup', function () {
        getEmployees();
    })

});

function getEmployees() {
    $.ajax({
        url: 'Employee/_EmployeeList',
        dataType: 'html',
        method: 'GET',
        data: { search: $('#txtSearch').val() },
        success: function (data) {
            $('#employee_list_table').html('').html(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
}

//Alertify
function Delete(id) {
    alertify.confirm('Employee List', 'Are you sure you want to delete this record ?', function () {
        window.location.href = 'Employee/DeleteEmployee/' + id;
    }, null)
}