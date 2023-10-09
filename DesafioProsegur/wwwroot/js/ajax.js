 //Funciones AJAX
function Ajax(
    tipo,
    url,
    objeto,
    async,
    bloquear,
    mensajeBloqueo,
    funcSuccess,
    funcError) {
    //if (bloquear) bloquearUI(mensajeBloqueo, true);
    if (async == undefined || async == null) async = false;

    $.ajax({
        type: tipo,
        url: url,
        data: objeto,
        async: async,
        success: function (obj) {
            //desbloquearUI();
            if (obj.success) {
                if (funcSuccess != undefined || funcSuccess != null) funcSuccess(obj);
                else return obj.innerObject;
            } else {
                if (funcError != undefined || funcError != null) funcError(obj)
                else MsjAlertaError("Error", obj.mensajeError);
            }
        },
        error: function (obj) {
            if (funcError != undefined || funcError != null) funcError(obj)
            else MsjAlertaError("Error", "Se produjo un error.");
        }
    });
}

//Bloqueo y desbloqueo de ajax
function bloquearUI(mensaje, giftBloqueo = false) {
    if (giftBloqueo) mensaje += ' <br/><div class="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div> ';

    $.blockUI({
        message: mensaje, css: {
            'font-size': '1.5rem',
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });
}

function desbloquearUI() {
    $.unblockUI();
}

function HandlerResponse(obj, funcSuccess, funcError) {
   
}