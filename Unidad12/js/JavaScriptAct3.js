window.onload = inicializar;

var selectModeloCoches;

function inicializar() {
    selectModeloCoches = document.createElement("select");
    document.body.appendChild(selectModeloCoches);
    llenarSelectModelosCoche();//Se llama para inicializar el select de los modelos coche

    document.getElementById("marcaCoches").addEventListener("change", llenarSelectModelosCoche, false);
}

function llenarSelectModelosCoche() {
    let marcaSeleccionada = document.getElementById("marcaCoches").value;
    let modelosSeleccionados;

    switch (marcaSeleccionada) {
        case "Renault":
            modelosSeleccionados = ["Modelo Renault1", "Modelo Renault2", "Modelo Renault3"];
            break;

        case "Opel":
            modelosSeleccionados = ["Modelo opel1", "Modelo opel2", "Modelo opel3", "Modelo opel4"];
            break;

        case "Ford":
            modelosSeleccionados = ["Modelo Ford1", "Modelo Ford2"];
            break;
    }
    selectModeloCoches.innerText = null; //Se limpia el contenido que tenga el select 
    anhadirOpcionesASelect(selectModeloCoches, modelosSeleccionados);
}

function anhadirOpcionesASelect(select,valoresOpciones) {
    let opt;
    for (var i = 0; i < valoresOpciones.length; i++) {
        opt = document.createElement('option');
        opt.text = valoresOpciones[i];
        select.appendChild(opt);
    }

}

