window.onload = inicializar;
var urlAPI = "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas";

function inicializar() {
    document.getElementById("btnCrear").addEventListener("click", activarCamposPersona, false);
    document.getElementById("btnAceptar").addEventListener("click", crearPersona, false);
    document.getElementById("btnVolver").addEventListener("click", volverAtras, false);
    obtenerPersonas();
}

function obtenerPersonas() {
    var peticion = new XMLHttpRequest();
    peticion.open("GET","https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas");

    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4) {
            if (peticion.status == 200) {
                var arrayPersonas = JSON.parse(peticion.responseText);
                crearTablaPersonas(arrayPersonas);
            } else if (peticion.status == 404) {
                document.getElementById("divMensajeError").innerHTML = "No se encontraron personas";
            }
        }
    }
    peticion.send();
}

function crearTablaPersonas(arrayPersonas) {
    var tabla = document.getElementById("tblPersonas");
    var thead = document.createElement("thead");
    tabla.appendChild(thead);

    let tr = document.createElement("tr");
    let th1 = document.createElement("th");
    th1.innerHTML = "Nombre";
    let th2 = document.createElement("th");
    th2.innerHTML = "Apellidos";
    let th3 = document.createElement("th");
    th3.innerHTML = "telefono";
    tr.appendChild(th1);
    tr.appendChild(th2);
    tr.appendChild(th3);
    thead.appendChild(tr);

    var tbody = document.createElement("tbody");
    arrayPersonas.forEach(function (persona, i, arrayPersonas) {
        let tr = document.createElement("tr");
        let th1 = document.createElement("td");
        th1.innerHTML = persona.nombre;
        let th2 = document.createElement("td");
        th2.innerHTML = persona.apellidos;
        let th3 = document.createElement("td");
        th3.innerHTML = persona.telefono;

        tr.appendChild(th1);
        tr.appendChild(th2);
        tr.appendChild(th3);

        tbody.appendChild(tr);
        tabla.appendChild(tbody);
    })
}

function activarCamposPersona() {
    document.getElementById("tblPersonas").hidden = true;
    document.getElementById("btnCrear").hidden = true;
    document.getElementById("ZonaCrearPersona").hidden = false;
}
function activarCamposPersonaConValores() {

}
function volverAtras() {
    document.getElementById("tblPersonas").hidden = false;
    document.getElementById("btnCrear").hidden = false;
    document.getElementById("ZonaCrearPersona").hidden = true;

}

function crearPersona() {
    var nombre = document.getElementById("inputNombre").value;
    var apellidos = document.getElementById("inputApellidos").value;
    var telefono = "640215741"//document.getElementById("inputTelefono").value;
    var direccion = document.getElementById("inputDireccion").value;
    var fechaNacimiento = "2021-12-09T00:00:00"//document.getElementById("inputFechaNacimiento").value;
    var foto = "";//document.getElementById("inputFoto").value;

    var selectDepartamentos = document.getElementById("selectDepartamento");
    var idDepartamento = selectDepartamentos.options[selectDepartamentos.selectedIndex].value;

    if (nombre.length == 0 || apellidos.length == 0 || direccion.length == 0) {
        alert("Hay cambos que no pueden estar vacios");
    } else {
        var personaNueva = new Persona(nombre, apellidos, telefono, direccion, fechaNacimiento, foto, idDepartamento);
        var peticion = new XMLHttpRequest();
        peticion.open("POST", "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas/");
        peticion.setRequestHeader('Content-type','application/json; charset=utf-8');

        var json = JSON.stringify(personaNueva);

        peticion.onreadystatechange = function () {
            if (peticion.readyState == 4) {
                if (peticion.status == 200) {
                    alert("Persona creada con exito");
                    volverAtras();
                } else {
                    alert(peticion.status);//"Debido a un error no se puedo insertar la persona");
                }
            }
        };
        peticion.send(json);
    }
}


