window.onload = inicializar;

var urlBase = "http://localhost:51482/api/"

function inicializar() {

    document.getElementById("btnCrear").addEventListener("click", actualizarPrecioPlanta,false);
}

function creaPlanta() {
    var nombrePlanta = document.getElementById("inputNombrePlanta").value;

    var oPlanta = { ID:0, Nombre:nombrePlanta, Descripcion:"Hola", IdCategoria:1, Precio:12 };

    document.getElementById("divNombrePlanta").innerHTML = oPlanta.Nombre;
}

function actualizarPrecioPlanta() {
   
    var peticion = new XMLHttpRequest();
    peticion.open("Put", urlBase + "plantas");
    peticion.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    var oPlanta2 = { Id: 1, Nombre: "", Descripcion: "Hola", IdCategoria: 1, Precio: 12 };
    var json = JSON.stringify(oPlanta2);

    peticion.onreadystatechange = function(){
        if (peticion.readyState == 4) {
            if (peticion.status == 200) {
                alert("Planta actualizada"); //Aqui habria que controlar que el numero de filas afectadas que devuelve la api sea mayor que 0 entonces si se muestra el mensaje de exito
            } else if (peticion.status == 404) {
                alert("No se pudo encontrar la planta");
            } else {
                alert("Ha ocurrido un error " + peticion.status);
            }
        }
    }
    peticion.send(json);
}

