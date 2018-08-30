//HoldOn Page Loader Events
$(document).ready(function () {
    initLoadHoldOn();
});

$(window).load(function() {
    HoldOn.close(); 
});

//$(document).on('submit', 'form', function () {
//    initLoadHoldOn();
//});

$(document).on('invalid-form.validate', 'form', function () {
    HoldOn.close();
});


$(document).ajaxStart(function () {
    initLoadHoldOn();
});

$(document).ajaxStop(function () {
    HoldOn.close();
});

function initLoadHoldOnClose() {
    
    HoldOn.close();
}

function initLoadHoldOn() {
    HoldOn.open({
        theme: "sk-bounce",
        message: 'Loading..Please Wait',
        textColor: "white",
    });
}