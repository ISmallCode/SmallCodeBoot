jQuery.fn.delay = function (time, func) {
    this.each(function () {
        setTimeout(func, time);
    });

    return this;
};

/*储存成功之后执行方法*/
function SaveSucess(data) {
    swal({
        title: data.Message,
    }, function () {
        window.location.href = data.ReturnUrl;
    });
    //swal(data.Message).function()

   
}