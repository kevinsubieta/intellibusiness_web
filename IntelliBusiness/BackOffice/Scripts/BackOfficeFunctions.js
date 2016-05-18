var root = $("#datos").attr("data-root");

//___________________Login methods_______________
function Errorlogin() { $("#error-login").css("display", "block"); }
//____________________UI MEthods __________________
function BloquearPantalla() { $.blockUI({ message: "" }); }
function DesbloquearPantalla() { $.unblockUI(); }

//____________________Ajaxs_________________________________________________
function run_Ajax(url, parameters, partial, callback) {
    BloquearPantalla();
    $.ajax({
        url: url,
        data: parameters,
        cache: false,        
        traditional: true,
        type: "POST",
        success: function (data, textStatus, jQXHR) { }
    }).done(function (html) {
        if (partial.length > 0) $(partial).html(html);
        callback();
        DesbloquearPantalla();
    }).error(function () { DesbloquearPantalla(); });
}

//______________________________________Ajaxs Callers_____________________________________________

function iniciarsesion(user, pass, type) {
    run_Ajax(root + "home/iniciarsesion", { user: user, pass: pass,type: parseInt(type) }, "", function () { });
}

function entraradm(userid) {
    $("#datos").attr("data-userid", userid);
    var f = function () {
        $("body").removeClass("body-login");
        administration_listeners();
    }
    run_Ajax(root + "administration/Index", { userid: parseInt(userid) }, "#render", f);
}

function adm(userid, method, callback) {
    run_Ajax(root + "administration/" + method, { userid: parseInt(userid) }, "#render_adm", callback );
}

function saliradm(userid) {
    $("#datos").attr("data-userid", "");
    var f = function () {
        $("body").addClass("body-login");
        loginlisteners();
    }
    run_Ajax(root + "administration/Salir", { userid: parseInt(userid) }, "#render", f);
}

function escalar(userid, escalarid, modo) {
    var f = function () {
        $("#dialogopropiedad").dialog("open");
        escalarlisteners();
    }

    run_Ajax(root + "administration/escalar", { userid: parseInt(userid), escalarid: parseInt(escalarid), modo: modo }, "#dialogopropiedad", f );
}

function registrarescalar(nombre,valores) {
    var f = function(){
        $("#dialogopropiedad").dialog("close");
        adm($("#datos").attr("data-userid"), "propiedades", function () { propiedadesliteners(); });
    }
    run_Ajax(root + "administration/registrarescalar", { nombre: nombre, valores: valores }, "", f);
}

function actualizarescalar(escalarid, nombre, valores) {
    var f = function () {
        $("#dialogopropiedad").dialog("close");
        adm($("#datos").attr("data-userid"), "propiedades", function () { propiedadesliteners(); });
    }
    run_Ajax(root + "administration/actualizarescalar", { escalarid: parseInt(escalarid), nombre: nombre, valores: valores }, "", f);
}

//_________________________________________dialog methods________________________

function dialog_configurations() {
    return {
        autoOpen: false,
        modal: true,
        closeOnEscape: true,
        draggable: false,
        resizable: false,
        //width: 500,
        //height: 500,
        dialogClass: "dialogo"
    }
}

//_______________________________escalar methods__________________

function getValues(lista) {
    var valores = [];
    for (var i = 0; i < lista.length; i++) {
        valores[i] = $(lista[i]).attr("data-values").toString();
    }
    return valores;
}

function actualizarvalorlistener() {
    $(".actualizarvalor").unbind("click");
    $(".actualizarvalor").click(function () {
        $(this).parent().prev().children("label").attr("id", "marcavalor");
        $("#nombrevalor").val($("#marcavalor").text());
        //$("#nombrevalor").val($(this).attr("data-values"));
        $("#actualizarvalor").show();
        $("#agregarvalor").hide();
        $("#dialogovalor").dialog("open");
    });
}

function agregarvalor(nombre) {//id valor accion
    if ($("#valorescontainer").children("table").length == 0) {
        $("#valorescontainer").append('<table class="tabla"><tbody id="bodytabla"><tr><td><label data-values="-1,'+nombre+',1" class="label-negro valor">' +
            nombre + '</label></td><td><button class="actualizarvalor">Actualizar</button><button class="quitarvalor">Quitar</button></td></tr></tbody></table>');
    } else {
        $("#bodytabla").append('<tr><td><label data-values="-1,' + nombre + ',1" class="label-negro valor">' +
            nombre + '</label></td><td><button class="actualizarvalor">Actualizar</button><button class="quitarvalor">Quitar</button></td>');
    }    
}

function actualizarvalor(nombre) {
    $("#marcavalor").text(nombre);
    var values = $("#marcavalor").attr("data-values").split(",");
    if ($(values[2]) == "1" ) {
        $("#marcavalor").attr("data-values", "-1," + nombre + ",1");
    } else {
        $("#marcavalor").attr("data-values", values[0] + "," + nombre + ",2");
    }
    $("#marcavalor").removeAttr("id");
}
