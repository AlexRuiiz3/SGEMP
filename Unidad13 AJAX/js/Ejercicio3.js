window.onload = inicializar;

function inicializar() {
    document.getElementById("btnBorrar").addEventListener("click", borrar,false);

}

function borrar() {
    var id = document.getElementById("txtBox").value;
    var peticion = new XMLHttpRequest();
    peticion.open("DELETE", "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas/"+id);

    peticion.onreadystatechange = function () {

        if (peticion.readyState < 4) {

        } else {
            if (peticion.status == 200) {
                document.getElementById("divMensaje").innerHTML = "Persona eliminada con exito";
            } else if (peticion.status == 404) {
                document.getElementById("divMensaje").innerHTML = "Persona no encontrada";
            }
        }
    }
    peticion.send();
}