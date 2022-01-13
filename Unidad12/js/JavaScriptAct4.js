window.onload = inicializar;

var tabla;
function inicializar() {
    tabla = document.getElementById("tabla");
    document.getElementById("buttonRecorreCeldas").addEventListener("click", recorrerCeldas, false);
    document.getElementById("buttonAnhadeFila").addEventListener("click", anhadirFila, false);
    document.getElementById("buttonBorrarFila").addEventListener("click", borrarFila, false);
}

function recorrerCeldas() {
    var valoresTabla = document.getElementsByTagName("th");
    var resultado = "";
    for (var i = 0; i < valoresTabla.length; i++) {
        resultado += valoresTabla[i].textContent + ", ";
    }
    alert(resultado);
}
/*
 * function recorrerCeldas() {
    for (let i in tabla.rows) {
        let row = tabla.rows[i]
        //iterate through rows
        //rows would be accessed using the "row" variable assigned in the for loop
        for (let j in row.cells) {
            resultado += row.cells[j].textContent
            //iterate through columns
            //columns would be accessed using the "col" variable assigned in the for loop
        }
    }
    alert(resultado);
}
 * 
 */ 
function anhadirFila() {
    var fila = tabla.insertRow(tabla.rows.length);

    var celda1 = fila.insertCell(0);
    var celda2 = fila.insertCell(1);

    celda1.innerHTML = "Celda" + tabla.rows.length + 1;
    celda2.innerHTML = "Celda" + tabla.rows.length + 2;
}

function borrarFila() {
    tabla.deleteRow(tabla.rows.length -1);
    
}

