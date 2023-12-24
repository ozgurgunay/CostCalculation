$(document).ready(function () {
});

function onCheckboxChange(userId) {
    var isChecked = document.getElementById("IsApproved_" + userId).checked;
    var userApprovedDTO = new Object();
    userApprovedDTO.UserId = userId;
    userApprovedDTO.IsApproved = isChecked;


    $.ajax({
        url: "/Admin/Home/UpdateApprovalStatus",
        data: JSON.stringify(userApprovedDTO),
        type: "POST",
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response) {
                alert("Kullanıcı aktivasyonu güncellendi.");
            }
            else {
                alert("Kullanıcı aktivasyonu güncellenirken hata oluştu!");
            }
           
        },
        error: function (xhr, status, error) {
            console.error("Hata oluştu:", error);
        }
    });
}


