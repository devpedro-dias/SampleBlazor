window.ShowToastr = function (type, message) {
    if (type == "success") {
        toastr.sucess(message)
    }

    if (type == "error") {
        toastr.error(message)
    }
}