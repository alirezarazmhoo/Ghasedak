﻿
function checkvalidity(target) {
    var ErrorText = '';
    var state = 1;
    var count = 0;
    $('form#' + target + '').find('input').each(function () {
        if ($(this).prop('required') && $(this).val() === "") {
            count++;
            ErrorText += $(this).attr('display') + " ، ";
            state = 0;
        }
    });
    if (state === 0) {

        if (count > 1) {

            ErrorText += 'Are Empty !';
        }
        else {
            ErrorText += 'Is Empty !';
        }
        $("#textError").text(ErrorText);
        $("#ErrorModal").modal('show');
        return 0;
    }
    else {
        return 1;
    }
}
function clear(target, InputType) {

    for (var i = 0; i < InputType.length; i++) {

        $('form#' + target + '').find(InputType[i]).each(function () {
            $(this).val('');
        });
    }
}
function cleardiv(target) {

    for (var i = 0; i < target.length; i++) {
        $('#' + target[i] + '').html('');
    }
}
function CreateModal(target, mode) {
    var modal = "";
    if (parseInt(mode) === 1) {
        modal = "<div class='modal fade' id='ErrorModal' role='dialog'><div class='modal-dialog modal-sm'><div class='modal-content'><div class='modal-header'><h4 class='modal-title text-danger'>خطا</h4></div><div class='modal-body text-danger'><p id='textError'></p></div><div class='modal-footer'><button type='button' class='btn btn-danger'  data-dismiss='modal'>بستن</button>";
        document.getElementById(target).innerHTML = modal;
    }
    else if (parseInt(mode) === 2) {
        modal = "<div class='modal fade' id='SuccessModal' role='dialog'><div class='modal-dialog modal-sm'><div class='modal-content'><div class='modal-header'><h4 class='modal-title text-success'> موفقیت آمیز</h4></div><div class='modal-body text-success'><p>عملیات با موفقیت انجام شد</p></div><div class='modal-footer'><button type='button' class='btn btn-success'  data-dismiss='modal'>بستن</button>";
        document.getElementById(target).innerHTML = modal;
    }
    else {
        modal = "<div class='modal fade' id='QuestionModal' role='dialog'><div class='modal-dialog modal-sm'><div class='modal-content'><div class='modal-header'><h4 class='modal-title'></h4></div><div class='modal-body text-warning'><p>آیا مایل به حذف این رکورد هستید؟</p></div><div class='modal-footer'><button type='button' class='btn btn-success' onclick='Remove();' data-dismiss='modal'>حذف</button><button  style='margin-left:5px' type='button' class='btn btn-danger' data-dismiss='modal'>بازگشت</button>";
        document.getElementById(target).innerHTML = modal;
    }
}
function PostAjax(ActionName, Parameters, redirecturl) {
    var fd = new FormData();
    for (var i = 0; i < Parameters.length; i++) {
        if (Parameters[i].special === 'combo') {
            fd.append(Parameters[i].id, $('#' + Parameters[i].htmlname + '').find('option:selected').val());
        }
        else if (Parameters[i].special === 'Multicombo') {
            fd.append(Parameters[i].id, $('#' + Parameters[i].htmlname + '').val());
        }
        else if (Parameters[i].special === 'radio') {
            fd.append(Parameters[i].id, $('input[name="' + Parameters[i].htmlname + '"]:checked').val());
        }

        else if (Parameters[i].special === 'file') {

            $.each($(".TheFile"), function (i, obj) {
                $.each(obj.files, function (j, file) {
                    fd.append("file", file);
                });
            });

        }
        else if (Parameters[i].special === 'music') {
            $.each($(".MusicUrl"), function (i, obj) {
                $.each(obj.files, function (j, file) {
                    fd.append("musicfiles", file);
                });
            });
        }
        else if (Parameters[i].special === 'siglefile') {
            fd.append("pictiremusic", $('#' + Parameters[i].htmlname + '')[0].files[0]);
        }
        else {
            fd.append(Parameters[i].id, $('#' + Parameters[i].htmlname + '').val());
        }
    }
    $.ajax({
        type: "POST",
        url: "" + ActionName + "",
        data: fd,
        dataType: "json",
        contentType: false,
        processData: false,
        beforeSend: function () {
            $("#LoadingModal").modal('show');
        },
        success: function (response) {
            if (response.success) {
                $("#SuccessModal").modal('show');

                setTimeout(function () { location.href = redirecturl; }, 2000);
            }
            else {
                $("#textError").text(response.responseText);
                $("#ErrorModal").modal('show');
            }
        },
        error: function (response) {
            $("#LoadingModal").modal('show');

        },
        complete: function () {
            $("#LoadingModal").modal('toggle');
        }
    });
}
function CreateAllModals() {
    CreateModal('Error', 1);
    CreateModal('Success', 2);
    CreateModal('Question', 3);
}

function FillComboBox(ActionName, Target) {
    $.ajax({
        type: "GET",
        url: "" + ActionName + "",
        dataType: "json",
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                $.each(response.list, function () {

                    $('#' + Target + '').append($("<option/>").val(this.id).text(this.name));
                });
            }
            else {
                $("#textError").text(response.responseText);
                $("#ErrorModal").modal('show');
            }
        },
        error: function (response) {
            alert("Error");
            //$("#LoadingModal").modal('show');
        }
    });
}

function EditAjax(ActionName, id) {

    var fd = new FormData();
    fd.append('ItemId', id);
    $.ajax({
        type: "Post",
        url: "" + ActionName + "",
        data: fd,
        dataType: "json",
        contentType: false,
        processData: false,
        beforeSend: function () {
            $("#LoadingModal").modal('show');
        },
        success: function (response) {
            if (response.success) {
                $.each(response.listItem, function () {
                    
                    if (this.key == "isActive") {
                        if (this.value == "True") {
                            $('#register').find('input:checkbox[id^="isActive"]').prop('checked', true);
                        }
                        else {
                            $('#register').find('input:checkbox[id^="isActive"]').prop('checked', false);

                        }
                    }

                    if (this.key == "isAccessBox") {
                        if (this.value == "True") {
                            $('#register').find('input:checkbox[id^="isAccessBox"]').prop('checked', true);
                        }
                        else {
                            $('#register').find('input:checkbox[id^="isAccessBox"]').prop('checked', false);

                        }
                    }

                    if (this.key == "isAccessSponsor") {
                        if (this.value == "True") {
                            $('#register').find('input:checkbox[id^="isAccessSponsor"]').prop('checked', true);
                        }
                        else {
                            $('#register').find('input:checkbox[id^="isAccessSponsor"]').prop('checked', false);

                        }
                    }

                    if (this.key == "isAccessFinancialAid") {
                        if (this.value == "True") {
                            $('#register').find('input:checkbox[id^="isAccessFinancialAid"]').prop('checked', true);
                        }
                        else {
                            $('#register').find('input:checkbox[id^="isAccessFinancialAid"]').prop('checked', false);

                        }
                    }

                    if (this.key == "isAccessFlowerCrown") {
                        if (this.value == "True") {
                            $('#register').find('input:checkbox[id^="isAccessFlowerCrown"]').prop('checked', true);
                        }
                        else {
                            $('#register').find('input:checkbox[id^="isAccessFlowerCrown"]').prop('checked', false);

                        }
                    }
                    if (this.key == "codeOprator") {
                        debugger
                        if (this.value == "") {
                            $("#opratorSection").hide();
                        }
                    }
                    $('#' + this.key + '').val(this.value);
                });
                //if (response.listartists != null) {
                //    $.each(response.listartists, function () {
                //        $("#ArtistsId option[value=" + this.key + "]").attr("selected", true);
                //    });
                //}
                //if (response.genreitem != null) {
                //    $.each(response.genreitem, function () {
                //        $("#GenreId option[value=" + this.key + "]").attr("selected", true);
                //    });
                //}
                //if (response.artistfiles != null) {
                //    var Filescontent = "";

                //    $.each(response.artistfiles, function () {
                //        Filescontent += '<div id= "' + this.id + '"><img src="../Upload/ImageArtist/' + this.url + '" style="width: 70px; height: 60px;id="' + this.id + '" " /><button type="button"  class="btn btn-danger btn-sm btnremovefile"   style="width:30px;margin-left:30%;"><i class="fa fa-remove"></i></button></div>';
                //    });
                //    $('#RemoveImageItems').html(Filescontent);
                //}
                //if (response.audio != null) {
                //    var audiocontent = '<audio controls><source src="../Upload/Music/' + response.audio + '" ></audio>';
                //    $('#MusicItem').html(audiocontent);
                //}
                //if (response.musicattachedfiles != null) {
                //    var MusicFilescontent = "";

                //    $.each(response.musicattachedfiles, function () {
                //        if (this.specialtypefile == "Picture") {
                //            MusicFilescontent += '<div id= "' + this.id + '"><img src="../Upload/MusicFiles/' + this.url + '" style="width: 70px; height: 60px;id="' + this.id + '" " /><button type="button"  class="btn btn-danger btn-sm btnremovefile"   style="width:30px;margin-left:30%;"><i class="fa fa-remove"></i></button></div>';
                //        }
                //        $('#RemoveMusicFilesItems').html(MusicFilescontent);
                //    });
                //}
                $('#myModal').modal('show');
            }
            else {
                $("#textError").text(response.responseText);
                $("#ErrorModal").modal('show');
            }
        },
        error: function (response) {
            $("#LoadingModal").modal('show');
        },
        complete: function () {
            $("#LoadingModal").modal('toggle');
        }
    });


}
function setInputFilter(textbox, inputFilter) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    });
}

function SetInputFilter(targets) {
    for (var i = 0; i < targets.length; i++) {
        setInputFilter(document.getElementById(targets[i]), function (value) {
            return /^\d*\.?\d*$/.test(value);
        });
    }
}
function ResetListBox(targets) {

    for (var i = 0; i < targets.length; i++) {
        $('#' + targets[i] + '').prop('selectedIndex', 0);
    }

}


function SetPictures(inputtarget, target, type) {
    var myURL = window.URL || window.webkitURL;
    var result = "";
    var tag = "";
    var _File = document.getElementById("" + inputtarget + "").files;
    for (var i = 0; i < _File.length; i++) {
        var fileURL = myURL.createObjectURL(_File[i]);

        if (type == 'music') {
            tag = "<img src='../Images/MusicIcon.png' style='width:80px;height:60px;'>";
        }
        else {
            tag = "<img src='" + fileURL + "' style='width:80px;height:60px;'>";
        }
        result += tag;
    }

    $('#' + target + '').html(result);
}


function RemoveFiles(ParentTarget, ActionName, ParameterName, Parametervalue) {

    var fd = new FormData();

    fd.append(ParameterName, Parametervalue);
    $.ajax({
        type: "POST",
        url: "" + ActionName + "",
        data: fd,
        dataType: "json",
        contentType: false,
        processData: false,
        beforeSend: function () {

            $('.btnremovefile').prop('disabled', true);
        },
        success: function (response) {

        },
        error: function (response) {
            $("#LoadingModal").modal('show');

        },
        complete: function () {
            $('.btnremovefile').prop('disabled', false);

        }
    });
}
$('#isActive').change(function () {
    if (this.checked) {
        var isChecked = $(this).prop("checked");
        $('#register').find('input:checkbox[id^="isActive"]').prop('checked', isChecked);
        $('#register #isActive').val(true)
    }
    else {
        $('#register #isActive').val(false)

    }
});
$('#isAccessBox').change(function () {
    if (this.checked) {
        var isChecked = $(this).prop("checked");
        $('#register').find('input:checkbox[id^="isAccessBox"]').prop('checked', isChecked);
        $('#register #isAccessBox').val(true)
    }
    else {
        $('#register #isAccessBox').val(false)

    }
});
$('#isAccessSponsor').change(function () {
    if (this.checked) {
        var isChecked = $(this).prop("checked");
        $('#register').find('input:checkbox[id^="isAccessSponsor"]').prop('checked', isChecked);
        $('#register #isAccessSponsor').val(true)
    }
    else {
        $('#register #isAccessSponsor').val(false)

    }
});
$('#isAccessFinancialAid').change(function () {
    if (this.checked) {
        var isChecked = $(this).prop("checked");
        $('#register').find('input:checkbox[id^="isAccessFinancialAid"]').prop('checked', isChecked);
        $('#register #isAccessFinancialAid').val(true)
    }
    else {
        $('#register #isAccessFinancialAid').val(false)

    }
});
$('#isAccessFlowerCrown').change(function () {
    if (this.checked) {
        var isChecked = $(this).prop("checked");
        $('#register').find('input:checkbox[id^="isAccessFlowerCrown"]').prop('checked', isChecked);
        $('#register #isAccessFlowerCrown').val(true)
    }
    else {
        $('#register #isAccessFlowerCrown').val(false)

    }
});
