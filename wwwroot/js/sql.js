// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("sqlForm").addEventListener("keydown", function (e) {
    if (e.key === "Enter" || e.keyCode === 13) {
        e.preventDefault();
        return false;
    }
});
document.getElementById("myButton").addEventListener("keydown", function (event) {
    // Check if Enter key is pressed
    if (event.key === "Enter" || event.keyCode === 13) {
        event.preventDefault(); // Stop default action
        event.stopPropagation(); // Stop bubbling
        console.log("Enter key disabled for this button.");
    }
});
document.querySelectorAll("input").forEach(i => {
    i.addEventListener("keydown", e => {
        if (e.key === "Enter" || e.keyCode === 13) e.preventDefault();
    });
});


function handleTextChange(inputElement) {
    // Get the value of the textbox
    var newValue = inputElement.value;
    //var value = $('#TableCount').val();
    var min = 1;
    var max = 50;
    //  $( "#theadBoxContainer, #lblBoxContainer").show();
    if ($.trim(newValue) === "") {
        alert("Please enter a value.");
        e.preventDefault();
        return false;
    }

    if (!$.isNumeric(newValue)) { // Check if it is a number
        alert("Please enter a numeric value.");
        e.preventDefault();
        return false;
    }

    if (newValue < min || newValue > max) { // Check if it is within range
        alert("Please enter a value between " + min + " and " + max + ".");
        e.preventDefault();
        return false;
    }

    //$( "#textBoxContainer").append('');
    $("#textBoxContainer").empty();
    $("#GeneratedScript").empty();
    for (var i = 0; i < newValue; i++) {
        //$("#textBoxContainer").append('<tr><td><input id="TN[' + i + ']"  name="TN[' + i + ']" class="form-control glass-input TN"/></td><td><input id="TF[' + i + ']"  name="TF[' + i + ']" class="form-control glass-input TF" /></td><td><button class="btn btn-sm btn-outline-light">Edit</button> | <button class="btn btn-sm btn-outline-light">Delete</button></td></tr>');
        $("#textBoxContainer").append('<tr><td><input id="TN[' + i + ']"  name="TN[' + i + ']" class="form-control glass-input TN"/></td><td><input id="TF[' + i + ']"  name="TF[' + i + ']" class="form-control glass-input TF" /></td></tr>');
    }
}
$(document).ready(function () {
    //if ('@Model.GeneratedScript' != '') {
    //    $('#TC').attr('disabled', 'disabled');
    //    $('#TC').attr('disabled', true);
    //    $('#myButton').attr('disabled', 'disabled');
    //    $('#myButton').attr('disabled', true);
    //}

    $('#sqlForm').submit(function (e) {
        debugger;
        var allFilledTN = true;
        var allFilledTF = true;
        if ($('input.TN').length > 0) {
            $('input.TN').each(function () {
                if ($.trim($(this).val()).length === 0) {
                    // alert('An empty field was found.');
                    $(this).focus(); // Optional: focus on the first empty field
                    allFilledTN = false;
                    return false; // Break the loop
                }
            });
        }
        else {
            alert("Please enter a numeric value between 1 and 50.");
            return false;
        }
        if ($('input.TF').length > 0) {
            $('input.TF').each(function () {
                if ($.trim($(this).val()).length === 0) {
                    //alert('An empty field was found.');
                    $(this).focus(); // Optional: focus on the first empty field
                    allFilledTF = false;
                    return false; // Break the loop
                }
            });
        }
        else {
            alert("Please enter a numeric value between 1 and 50.");
            return false;
        }

        debugger;
        if (allFilledTN && allFilledTF) {
            alert('All required fields are filled!');

            //             $('#TC').prop('disabled', true);
            // $('#myButton').prop('disabled', true);
            // $( "#theadBoxContainer, #lblBoxContainer").hide();
            // Proceed with form submission
        } else {
            alert('Please fill out all required fields.');
            return false;
        }

        // var value = $('#TableCount').val();
        // var min = 1;
        // var max = 50;

        // if ($.trim(value) === "") {
        //     alert("Please enter a value.");
        //     e.preventDefault();
        //     return false;
        // }

        // if (!$.isNumeric(value)) { // Check if it is a number
        //     alert("Please enter a numeric value.");
        //     e.preventDefault();
        //     return false;
        // }

        // if (value < min || value > max) { // Check if it is within range
        //     alert("Please enter a value between " + min + " and " + max + ".");
        //     e.preventDefault();
        //     return false;
        // }
    });
});