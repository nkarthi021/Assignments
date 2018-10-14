$(document).ready(function () {

    $('#btnClear').click(function () {
        $('#CustomerId').val(0);
    })
    $('#btnfartocel').click(function () {
        if ($('#txtvalue').val() != '') {
            $.post('/Tempreature/FartoCel', { "value": $('#txtvalue').val() }, function (data) {
                $('#output').text('The Output is : ' + data.output + '°C');

            });
        }
        else
            alert('Plase Enter Value to Convert');
    });

    $('#btnceltofar').click(function () {
        if ($('#txtvalue').val() != '') {
        $.post('/Tempreature/celtoFar', { "value": $('#txtvalue').val() }, function (data) {
            $('#output').text('The Output is : ' + data.output + '°F');
        });
        }
        else
            alert('Plase Enter Value to Convert');
    });
});

$(document).on("click", "#btnsave", function (e) {

    e.preventDefault();
    var $form = $(this).parents('form');

    $.post('/Employee/AddorUpdate', $form.serialize(), function (data) {
        if (data.status == 'Success') {
            $.get('/Employee/Index', null, function (response) {
                $('#divEmployeeForm').html(response);

            });
        }
    });



});



function GetEmployee(id) {
    $.get('/Employee/Index', { "Id": id }, function (response) {
        $('#divEmployeeForm').html(response);
    });
}

function GetData(data) {
    data = $.parseJSON(data.d);
    // $('#customerForm').html($('#customerForm',data).html());    
    $('#CustomerId').val(data.CustomerId)
    $('#txtName').val(data.CustomerName);
    $('#txtAddress').val(data.CustomerAddress);
    $('#txtDOB').val(ToDate(data.DOB));
    $('#txtSalary').val(data.Salary);

};


function DeleteEmployee(id) {
    if (confirm("Are you sure do you want to delete?")) {
        $.post('/Employee/Delete', { "Id": id }, function (data) {
            if (data.status == 'Success') {
                $.get('/Employee/Index', null, function (response) {
                    $('#divEmployeeForm').html(response);

                });
            }
        });
    };
}