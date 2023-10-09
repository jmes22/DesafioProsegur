$(document).ready(function () {
    // Manejar el evento de clic en los elementos del menú
    $(".nav-link").click(function () {
        // Quitar la clase "active" de todos los elementos del menú
        $(".nav-item").removeClass("active");
        // Agregar la clase "active" al elemento de menú clicado
        $(this).closest(".nav-item").addClass("active");
    });
});