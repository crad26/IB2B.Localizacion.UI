var v_MenuId = '';
$(document).on('click', '[data-type="modal-link"]', function (e) {

    e.preventDefault();

    // Url de vista a cargar
    var sourceUrl = $(this).attr('data-source-url');
    var customWidth = $(this).attr('data-modal-width');
    if (customWidth) {
        $modal.css('width', customWidth + "px");
        $modal.css('margin-left', "-" + (customWidth / 2) + "px");
    }

    var $modal = $('<div class="modal inmodal" data-refresh="true" tabindex="-1" role="dialog"><div class="modal-dialog modal-lg"><div class="modal-content animated fadeIn"></div></div></div>');
    var $modalContent = $modal.find('.modal-content');
    if (customWidth) {
        $modal.css('width', customWidth + "px");
        $modal.css('margin-left', "-" + (customWidth / 2) + "px");
    }

    $('#loading-modal').show();
    $modalContent.html($('#loading-modal').html())
    var $container = $('#default-modal-container');
    $container.remove();
    $container.append($modal);
    var bootModal = $modal.modal('show');
    $modalContent.load(sourceUrl, function (response, status, xhr) {
        if (status == "error") {
            $('#loading-modal').hide();
            $modalContent.html($('#loading-modal-error').html());
        }
        else {
            $('#loading-modal').hide();
            $.validator.unobtrusive.parse($modalContent);
        }
    });
    bootModal.on('hidden.bs.modal', function (e) {
        $(e.target).removeData('bs.modal').find(".modal-content").html('');
        $(this).remove();
    });

    $('.datepicker').datepicker({ format: 'dd/mm/yyyy', weekStart: 1 })

});
$(document).ready(function () {
    $(".date-picker").datepicker({
        format: 'dd-mm-yyyy',
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        clearBtn: true,
        language: "es",
        autoclose: true,
        yearRange: "-100:+5",
        beforeShow:function(input) {
            $(input).css({
                "position": "relative",
                "z-index": 99999999999999
            });
        }
    });

    $('.treeview > a').on("click", function (e) {
        localStorage.setItem("v_MenuId", e.currentTarget.id);
    });
    $('.treeview-menu > li > a').on("click", function (e) {
        localStorage.setItem("v_SubMenuId", e.currentTarget.id);
    });

    v_MenuId    = localStorage.getItem("v_MenuId");
    v_SubMenuId = localStorage.getItem("v_SubMenuId");
    if (v_MenuId != null && v_MenuId != "") {
        $('[id*=' + v_MenuId + ']').click();
    }
    if (v_SubMenuId != null && v_SubMenuId != "") {
        $('[id*=' + v_SubMenuId + ']').css('color', '#dd4b39');
    }
});

$(document)
    .ajaxStart(function (e) {
        fc_MostrarLoadPage()
    })
    .ajaxStop(function (event,request,settings) {
        fc_OcultarLoadPage();
    })

function fc_MostrarLoadPage() {
    $("#loading-page").show();
    $("body").append('<div class="modal-backgroup-ajax in"></div>');
}

function fc_OcultarLoadPage() {
    $("#loading-page").hide();
    $(".modal-backgroup-ajax").remove();
}
var v_Htmlraw_Success = '<div class="text-center"><img src="../Imagen/success2.jpg" style="width:100px;height:100px;z-index: 99999999 !important" alt="Alternate Text" /></div><div class="text-center" style="margin-top:-10px;"><h2 style="color: #492877;;" class="text-center"  {pTitulo} >' + '</h2></div><div class="text-center"><p style="color: #575757;" class="text-center"><strong> {pMensaje} ' + '</strong></p></div>';
var v_Htmlraw_warning = '<div class="text-center"><img src="../Imagen/warning.jpg" style="width:100px;height:100px;z-index: 99999999 !important;" alt="Alternate Text" /></div><div class="text-center" style="margin-top:-10px;"><h2 style="color: #492877;;" class="text-center">  {pTitulo}' + '</h2></div><div class="text-center"><p style="color: #575757;" class="text-center"><strong>  {pMensaje} ' + '</strong></p></div>';
var v_Htmlraw_Info = '<div class="text-center" ><img src="../Imagen/info.jpg" style="width:100px;height:100px;z-index: 99999999 !important" alt="Alternate Text" /></div><div class="text-center" style="margin-top:-10px;"><h2 style="color: #492877;;" class="text-center">  {pTitulo}' + '</h2></div><div class="text-center"><p style="color: #575757;" class="text-center"><strong>  {pMensaje} ' + '</strong></p> </div>';
var v_Htmlraw_Danger = '<div class="text-center"><img src="../Imagen/danger2.jpg" style="width:100px;height:100pxz-index: 99999999 !important;" alt="Alternate Text" /></div><div class="text-center" style="margin-top:-10px;"><h2 style="color: #492877;;" class="text-center">  {pTitulo}' + '</h2></div><div class="text-center"><p style="color: #575757;" class="text-center"><strong> {pMensaje} ' + '</strong></p></div>';


function fc_MensajeBootBox(pTipo, pTitulo, pMensaje) {
    var v_Htmlraw = '';
    if (pTipo   == "success") {
        v_Htmlraw = v_Htmlraw_Success.replace('{pTitulo}', pTitulo).replace('{pMensaje}', '<pre><div style="font-size:18pt;">' + pMensaje + '</div></pre>');
    }
    if (pTipo   == "warning") {
        v_Htmlraw = v_Htmlraw_warning.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);
    }
    if (pTipo   == "info") {
        v_Htmlraw = v_Htmlraw_Info.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);
    }
    if (pTipo   == "danger") {
        v_Htmlraw = v_Htmlraw_Danger.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);
    }
    bootbox.alert({
        message: v_Htmlraw 
    });
}

function fc_MensajeBootBoxConfirm(pTipo, pTitulo, pMensaje, pfuncionConfirma, pfuncionCancel) {
    var v_Htmlraw = '';
    if (pTipo   == "success") {
        v_Htmlraw   = v_Htmlraw_Success.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);
    }
    if (pTipo   == "warning") {
        v_Htmlraw   = v_Htmlraw_warning.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);;
    }
    if (pTipo   == "info") {
        v_Htmlraw   = v_Htmlraw_Info.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);;
    }
    if (pTipo   == "danger") {
        v_Htmlraw   = v_Htmlraw_Danger.replace('{pTitulo}', pTitulo).replace('{pMensaje}', pMensaje);;
    }
    bootbox.dialog({
        message : v_Htmlraw,
        buttons : {
            Cancel  : {
                label       : "Cancelar",
                className   : "btn-danger",
                callback    : function () {
                    pfuncionCancel();
                    return "Cancel";
                }
            },
            success : {
                label       : "Confirmar",
                className   : "btn-primary",
                callback    : function () {
                    pfuncionConfirma();
                    return "OK";
                }
            }
        }
    });
}
$(window).bind("resize", function () {
    
}).triggerHandler("resize");

function fc_ValidarEmail(pEmail) {
    var regex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var result = pEmail.replace(/\s/g, "").split(/,|;/);
    for (var i = 0; i < result.length; i++) {
        if (!regex.test(result[i])) {
            return false;
        }
    }
    return true;
}
$(window).on('resize.jqGrid', function () {

    $("table").jqGrid("setGridWidth", $("table").closest(".container-fluid").width());
});

function fc_Mensaje_Tiempo_Agotado(pData) {
    if (pData != null) {
        if (pData.indexOf('Tiempo Agotado') != -1) {
            var fc_Redireccionar = function () {
                location.href = '/';
            }
            fc_MensajeBootBoxConfirm('danger', "Tiempo Agotado", 'Tiempo de Espera Agotado, por favor ingrese nuevamente al Sistema', fc_Redireccionar, fc_Redireccionar);

        }
    }
}

function fc_jqgrid_responsive_table() {

    var $jqGridActuales = $("table");
    $jqGridActuales.each(function (i) {

        var v_AnchoJqgrid = $(this).closest(".ui-jqgrid").width();
        var v_Columnas = $(this).jqGrid('getGridParam', 'colModel')
        var v_TotalColumnas = 0;

        if (v_Columnas != undefined) {

            for (var a = 0; a < v_Columnas.length ; a++) {
                if (v_Columnas[a].hidden == false) {
                    v_TotalColumnas += v_Columnas[a].widthOrg;
                }
            }
            var v_NuevoTamanio = $(this).closest(".ui-jqgrid").parent().width();
            $(this).jqGrid("setGridWidth", v_NuevoTamanio, true);

            if (v_AnchoJqgrid < v_TotalColumnas) {
                fc_ReDefineAnchoColumna(v_Columnas, $(this)[0].id);
            }
        }

    });

}
function fc_ReDefineAnchoColumna(v_Columnas, pIdTabla) {

    for (var j = 0; j < v_Columnas.length ; j++) {

        $('.ui-jqgrid-labels > th:eq(' + j + ')').css('width', v_Columnas[j].widthOrg); // will set the column header widths
        $('#' + pIdTabla + ' tr').find('td:eq(' + j + ')').each(function () { $(this).css('width', v_Columnas[j].widthOrg); }) // will set the column widths
    }
}

function validateEmail(pEmail) {
    var regex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var result = pEmail.replace(/\s/g, "").split(/,|;/);
    for (var i = 0; i < result.length; i++) {
        if (!regex.test(result[i])) {
            return false;
        }
    }
    return true;
}

$('.Evitar_KeyPress').keypress(function (e) {
        return false;
});