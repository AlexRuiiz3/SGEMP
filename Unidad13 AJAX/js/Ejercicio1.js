window.onload = inicializar;

function inicializar() {

    document.getElementById("btnSaludar").addEventListener("click", saludar,false);

}

function saludar() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "Hola.html");
    llamada.onreadystatechange = function () {

        if (llamada.readyState == 4 && llamada.status == 200) {
            document.getElementById("divSaludo").innerHTML = llamada.responseText;
        }
    }
    llamada.send();

}