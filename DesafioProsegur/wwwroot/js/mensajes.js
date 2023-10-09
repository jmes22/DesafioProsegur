function msjAlerta(title, message) {
    const toastLiveExample = document.getElementById('liveToast');

    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
    const boton = '<button type="button" class="btn-close" style="float: right;" data-bs-dismiss="toast" aria-label="Close"></button>';
    $("#toast_site").html(boton + "<p><strong>" + title + "</strong><hr>" + message + "</p>");

    toastBootstrap.show();
    
}

function MsjAlertaExito(title, message) {
    $("#toast_site").removeClass("alert-danger");
    $("#toast_site").removeClass("alert-info");
    $("#toast_site").addClass("alert-success");

    msjAlerta(title, message);
}

function MsjAlertaInformacion(title, message) {
    $("#toast_site").removeClass("alert-danger");
    $("#toast_site").removeClass("alert-success");
    $("#toast_site").addClass("alert-info");

    msjAlerta(title, message);
}

function MsjAlertaError(title, message) {
    $("#toast_site").removeClass("alert-info");
    $("#toast_site").removeClass("alert-success");
    $("#toast_site").addClass("alert-danger");

   msjAlerta(title, message);
}

function CrearMsjAlertaConLista(title, message, lista, tiempo, clase) {
    var msjLista = ArmarListaError(lista);
    var alerta = '<div class="alert ' + clase + ' alert-dismissible fade show" style="width: unset; float: right;" id="msj_alerta" role="alert">';
    alerta += '<button type="button" class="close" data-dismiss="alert" aria-label="Cerrar"> <span aria-hidden="true">&times;</span></button>';
    $("#div_msj_alerta").html(alerta + "<p style='font-size: 1.3em'><strong>" + title + "</strong><br/> " + (message == null ? "" : message) + "</p>" + msjLista + "</div >'");
    $("#div_msj_alerta").fadeIn(1000);
    window.setTimeout(function () {
        $("#div_msj_alerta").fadeOut(1000);
    }, tiempo);
}

function MsjAlertaErrorConLista(title, message, lista, tiempo = 10000) {
    var clase = "alert-danger";
    crearMsjAlertaConLista(title, message, lista, tiempo, clase);
}

function ArmarListaError(lista) {
    var msjLista = "";
    $.each(lista, function (key, value) {
        msjLista = msjLista + "- " + value + "<br/>";
    });
    return msjLista;
}