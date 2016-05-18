//_______________________Login Listeners______________________________________
function loginlisteners() {
    $("#username,#password").keypress(function (e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            IniciarSesion($("#username").val(), $("#password").val(), $("#rol").attr("data-val"));
        }
    });

    $("#rol").click(function () {
        $("#options").toggle();
    })

    $("#options > label").click(function () {
        $("#options").toggle();
        $("#rol").html($(this).text());
        $("#rol").attr("data-val", $(this).attr("data-val"));
    })

    $("#iniciarsesion").click(function () {
        iniciarsesion($("#username").val(), $("#password").val(),$("#rol").attr("data-val"));
    })
}

loginlisteners();

//_______________________________administration listeners__________________________
function administration_listeners() {
    $("#perfiladm").click(function () {
        adm($("#datos").attr("data-userid"), "perfil", function () { perfiladmliteners(); });
    })

    $("#empresas").click(function () {
        adm($("#datos").attr("data-userid"), "empresas", function () { empresasliteners(); });
    })

    $("#usuarios").click(function () {
        adm($("#datos").attr("data-userid"), "usuarios", function () { usuariosliteners(); });
    })

    $("#productos").click(function () {
        adm($("#datos").attr("data-userid"), "productos", function () { productosliteners(); });
    })

    $("#propiedades").click(function () {
        adm($("#datos").attr("data-userid"), "propiedades", function () { propiedadesliteners(); });
    })

    $("#saliradm").click(function () {
        $("#dialogovalor,#dialogopropiedad").dialog("destroy");
        saliradm($("#datos").attr("data-userid"));
    })

    $("#dialogovalor,#dialogopropiedad").dialog(dialog_configurations());

    $("#cerrarvalor").click(function () {
        $("#nombrevalor").val("");
        $("#dialogovalor").dialog("close");
    })

    $("#agregarvalor").click(function () {
        agregarvalor($("#nombrevalor").val());
        actualizarvalorlistener();
        $("#nombrevalor").val("");
        $("#dialogovalor").dialog("close");
    })

    $("#actualizarvalor").click(function () {
        actualizarvalor($("#nombrevalor").val());
        $("#nombrevalor").val("");
        $("#dialogovalor").dialog("close");
    })
}

function perfiladmliteners() {

}

function empresasliteners() {

}

function usuariosliteners() {

}

function productosliteners() {

}

function propiedadesliteners() {
    
    $("#nuevoescalar").click(function () {
        escalar($("#datos").attr("data-userid"), "-1", 1);        
    })

    $(".actualizarescalar").click( function() {
        escalar($("#datos").attr("data-userid"), $(this).attr("id"), 2);
    })
}

function escalarlisteners() {

    $("#cerrarescalar").click(function () {
        $("#dialogopropiedad").empty();
        $("#dialogopropiedad").dialog("close");
    })

    $("#nuevovalor").click(function () {
        $("#actualizarvalor").hide();
        $("#agregarvalor").show();
        $("#dialogovalor").dialog("open");
    })

    actualizarvalorlistener();
    
    $("#registrarescalar").click(function () {
        var valores = getValues(document.getElementsByClassName("valor"));
        registrarescalar($("#nombreescalar").val(), valores);
    })

    $("#actualizarescalar").click(function () {
        var valores = getValues(document.getElementsByClassName("valor"));
        actualizarescalar($(this).attr("data-id"), $("#nombreescalar").val(), valores);
    })
}



