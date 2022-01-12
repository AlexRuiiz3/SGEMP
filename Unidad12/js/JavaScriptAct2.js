window.onload = inicializar;

function inicializar() {
    document.getElementById("ButtonEnviar").addEventListener("click", mostrarDatosPersonas, false);

}

function mostrarDatosPersonas() {
    var inputNombre = document.getElementById("inputNombre").value;
    var inputApellidos = document.getElementById("inputApellidos").value;

    var persona = {
        nombre: inputNombre,
        apellidos: inputApellidos
    };
    alert("Nombre: " + persona.nombre + "Apellidos: " + persona.apellidos);
}