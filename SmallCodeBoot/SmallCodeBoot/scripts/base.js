
function postDelete(url, id) {
    $.post(url, function (data) {
        if (data.Status == 'ok' || data.Status == 'OK') {
            $('#' + id).remove();
            swal("删除完成!", "你已经删除该条记录", "success");
        }
        else
            swal("删除失败!", "你删除该条记录失败", "warning");
    });
}

function deleteDialog(url, id) {

    swal({
        title: "提示",
        text: "您确认要删除这条记录吗？",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "是, 删除!",
        cancelButtonText: "取消",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function () {
        postDelete(url, id);
      
    });
}

/*储存成功之后执行方法*/
function SaveSucess(data) {
    swal({
        title: data.Message,
    }, function () {
        window.location.href = data.ReturnUrl;
    });
    //swal(data.Message).function()


}