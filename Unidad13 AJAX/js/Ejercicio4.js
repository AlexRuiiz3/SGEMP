window.onload = inicializar;
var urlAPI = "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas";

function inicializar() {
    document.getElementById("btnCrear").addEventListener("click", activarCamposPersona, false);
    document.getElementById("btnAceptar").onclick = crearPersona;
    document.getElementById("btnVolver").addEventListener("click", volverAtras, false);
    obtenerPersonas();
}

function obtenerPersonas() {
    var peticion = new XMLHttpRequest();
    peticion.open("GET", urlAPI);
    document.getElementById("imgCargando").hidden = false;

    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4) {
            document.getElementById("imgCargando").hidden = true;
            if (peticion.status == 200) {
                var arrayPersonas = JSON.parse(peticion.responseText);
                crearTablaPersonas(arrayPersonas);
            } else if (peticion.status == 404) {
                document.getElementById("divMensajeError").innerHTML = "No se encontraron personas";
            } else {
                document.getElementById("divMensajeError").innerHTML = "A ocurrido un error.";
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
        let td1 = document.createElement("td");
        td1.innerHTML = persona.nombre;
        let td2 = document.createElement("td");
        td2.innerHTML = persona.apellidos;
        let td3 = document.createElement("td");
        td3.innerHTML = persona.telefono;
        let td4 = document.createElement("td");
        let td5 = document.createElement("td");

        var buttonEditar = document.createElement('input');
        buttonEditar.type = "button";
        buttonEditar.value = "Editar";
        buttonEditar.addEventListener('click', activarCamposPersonaConValores.bind(event, persona), false);

        td4.appendChild(buttonEditar);

        var buttonEliminar = document.createElement('input');
        buttonEliminar.type = "button";
        buttonEliminar.value = "Eliminar";
        buttonEliminar.addEventListener('click', eliminarPersona.bind(event, persona.id), false);

        td5.appendChild(buttonEliminar);

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);

        tbody.appendChild(tr);
        tabla.appendChild(tbody);
    })
}

function activarCamposPersona() {
    document.getElementById("tblPersonas").hidden = true;
    document.getElementById("btnCrear").hidden = true;
    document.getElementById("ZonaCrearPersona").hidden = false;
    document.getElementById("btnAceptar").onclick = crearPersona;
}
function activarCamposPersonaConValores(persona) {
    document.getElementById("tblPersonas").hidden = true;
    document.getElementById("btnCrear").hidden = true;
    document.getElementById("ZonaCrearPersona").hidden = false;
    document.getElementById("btnAceptar").onclick = actualizarPersona;

    document.getElementById("inputNombre").value = persona.nombre;
    document.getElementById("inputApellidos").value = persona.apellidos;
    document.getElementById("inputTelefono").value = "640215741";
    document.getElementById("inputDireccion").value = persona.direccion;
    document.getElementById("inputFechaNacimiento").value = "2021-12-09T00:00:00";
    //document.getElementById("inputFoto").value = "";//persona.foto;

    var selectDepartamentos = document.getElementById("selectDepartamento");
    var terminado = false;
    for (var i = 0; i < selectDepartamentos.options.length && !terminado; i++) {
        if (selectDepartamentos.options[i].value == persona.idDepartamento) {
            selectDepartamentos.options[i].selected = 'selected'
            terminado = true;
        }
    }

}
function volverAtras() {
    document.getElementById("tblPersonas").hidden = false;
    document.getElementById("btnCrear").hidden = false;
    document.getElementById("ZonaCrearPersona").hidden = true;

    document.getElementById("inputNombre").value = "";
    document.getElementById("inputApellidos").value = "";
    document.getElementById("inputTelefono").value = "";
    document.getElementById("inputDireccion").value = "";
    document.getElementById("inputFechaNacimiento").value = "";
    document.getElementById("selectDepartamento")[0].selected = "selected";
}



function crearPersona() {    
    var personaNueva = obtenerDatosYCrearPersona();
    if (personaNueva.nombre.length == 0 || personaNueva.apellidos.length == 0 || personaNueva.direccion.length == 0) {
        alert("Hay cambos que no pueden estar vacios");
    } else {
        var peticion = new XMLHttpRequest();
        peticion.open("POST", urlAPI);
        peticion.setRequestHeader('Content-type', 'application/json; charset=utf-8');

        var json = JSON.stringify(personaNueva);

        peticion.onreadystatechange = function () {
            if (peticion.readyState == 4) {
                if (peticion.status == 200) {
                    alert("Persona creada con exito");
                    window.location.reload();
                } else {
                    alert("Debido a un error no se puedo insertar la persona");
                }
            }
        };
        peticion.send(json);
    }
}

function actualizarPersona() {
    //alert("Da 405, no se permite PUT");
    
    var personaActualizar = obtenerDatosYCrearPersona();
    var peticion = new XMLHttpRequest();
    peticion.open("PUT", urlAPI+"/");
    peticion.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    var json = JSON.stringify(personaActualizar);

    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4) {
            if (peticion.status == 200) {
                alert("Persona actualizada con exito");
                window.location.reload();
            } else {
                alert(peticion.status);//"Debido a un error no se puedo actualizar la persona");
            }
        }
    }
    peticion.send(json);
    
}

function eliminarPersona(idPersona) {
    if (confirm("¿Quieres eliminar esta persona?")) {
        var peticion = new XMLHttpRequest();
        peticion.open("DELETE", urlAPI + "/" + idPersona);

        peticion.onreadystatechange = function () {
            if (peticion.readyState == 4) {
                if (peticion.status == 200) {
                    alert("Persona elimina con exito");
                    window.location.reload();
                } else {
                    alert("Debido a un error no se puedo eliminar la persona");
                }
            }
        }
        peticion.send();
    } else { }


}

function obtenerDatosYCrearPersona() {
    var nombre = document.getElementById("inputNombre").value;
    var apellidos = document.getElementById("inputApellidos").value;
    var telefono = "640215741"//document.getElementById("inputTelefono").value;
    var direccion = document.getElementById("inputDireccion").value;
    var fechaNacimiento = "2021-12-09T00:00:00"//document.getElementById("inputFechaNacimiento").value;
    var foto = "";//document.getElementById("inputFoto").value;

    var selectDepartamentos = document.getElementById("selectDepartamento");
    var idDepartamento = selectDepartamentos.options[selectDepartamentos.selectedIndex].value;

    var persona = new Persona(0,nombre, apellidos, telefono, direccion, fechaNacimiento, foto, idDepartamento);
    return persona;
}



