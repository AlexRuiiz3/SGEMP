window.onload = inicializar;

function inicializar() {

    document.getElementById("btnEnviar").addEventListener("click", obtenerApellido, false);

}

function obtenerApellido() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas");
    llamada.onreadystatechange = function () {
        if (llamada.readyState == 4 && llamada.status == 200) {
            var arrayPersonas = JSON.parse(llamada.responseText);
            document.getElementById("divApellidos").innerHTML = arrayPersonas[0].apellidos;
        }
    }
    llamada.send();
}