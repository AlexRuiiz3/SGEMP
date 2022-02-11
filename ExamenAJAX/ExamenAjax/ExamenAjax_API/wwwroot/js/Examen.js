window.onload = inicializar;

var urlBase = "http://localhost:51482/api/";

function inicializar() {
    obtenerMostrarCategorias();
    document.getElementById("btnVerPlantas").addEventListener("click", verPlantas, false);
}

//METODOS CONEXION CON LA API
//GET
/*
 * Cabecera: function obtenerCategorias()
 * Comentario: Este metodo se encarga de comunicarse con la api y pedirle un listado de categorias y mostrra el contenido mediante otro metodo.
 * Entradas:Ninguna
 * Salidas: Ninguna
 * Precondiciones: Ninguna
 * Postcondiciones: Se obtendra y mostrara un listado de categorias que se encuentran en un base de datos SQL.Si ocurre algun tipo error se informara de ello y no se mostrara la lista.
 * 
 */
function obtenerMostrarCategorias() {
    var peticion = new XMLHttpRequest();
    peticion.open("GET", urlBase + "categorias");

    document.getElementById("imgCargando").hidden = false;
    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4) {
            if (peticion.status == 200) {
                var listadoCategorias = JSON.parse(peticion.responseText);
                if (listadoCategorias.length == 0) {
                    alert("No hay categorias");
                }
                document.getElementById("imgCargando").hidden = true;
                mostrarTablaDeCategorias(listadoCategorias);
            } else if (peticion.status == 404) {
                alert("No se pudo encontrar las categorias");
            } else {
                alert("Ha ocurrido un error tipo " + peticion.status);
            }
        }
    }
    peticion.send();
}
/*
 * Cabecera: function obtenerPlantasDeCategoria(idCategoria)
 * Comentario: Este metodo se encarga de comunicarse con la api y pedirle un listado de plantas a partir del id de una categoria
 * Entradas: idCategoria
 * Salidas: Ninguna
 * Precondiciones: Ninguna
 * Postcondiciones: Se obtendra y mostrara un listado de plantas a partir de una categoria, que se encuentran en un base de datos SQL.
 *                  Si ocurre algun tipo error se informara de ello y no se mostrara la lista.
 *
 */
function obtenerPlantasDeCategoria(idCategoria, nombreCategoria) {
var peticion = new XMLHttpRequest();
peticion.open("GET", urlBase + "plantas/" + idCategoria);

    peticion.onreadystatechange = function () {
        if (peticion.readyState == 4) {
            if (peticion.status == 200) {
                var listadoPlantas = JSON.parse(peticion.responseText);
                if (listadoPlantas.length == 0) {
                    alert("No hay categorias");
                }
                mostrarPlantasDeCategorias(listadoPlantas, nombreCategoria);
            } else if (peticion.status == 404) {
                alert("No se pudo encontrar las categorias");
            } else {
                alert("Ha ocurrido un error tipo " + peticion.status);
            }
        }
    }
    peticion.send();
}
//METODOS AÑADIDOS

/*
 * Cabecera: function mostrarTablaDeCategorias(listadoCategorias)
 * Comentario: Este metodo se encarga de mostra una tabla con la informacion de objetos Categoria que se encuentran en la lista que recibe
 * Entradas: listadoCategorias
 * Salidas: Ninguna
 * Precondiciones: Ninguna
 * Postcondiciones: Se mostrar una tabla con los datos de los objetos que hay en el lista que se recibe
 *
 */
function mostrarTablaDeCategorias(listadoCategorias) {
    var tabla = document.getElementById("tblCategorias");
    var thead = document.createElement("thead");
    tabla.appendChild(thead);

    let tr = document.createElement("tr");
    let th1 = document.createElement("th");
    th1.innerHTML = "Nombre";

    tr.appendChild(th1);
    thead.appendChild(tr);

    listadoCategorias.forEach(function (categoria, i, listadoCategorias) {
        var tr = document.createElement("tr");

        var tdNombre = document.createElement("td");
        tdNombre.innerHTML = categoria.nombre;

        var tdCheckBok = document.createElement("td");
        //checkBok
        var checkBok = document.createElement('input');
        checkBok.type = "checkbox";
        checkBok.value = categoria.id;
        checkBok.id = categoria.nombre;//Se guarda el nombre en el id

        tdCheckBok.appendChild(checkBok);

        tr.appendChild(tdNombre);
        tr.appendChild(tdCheckBok);

        tabla.appendChild(tr);
    })
}



/*
 * Cabecera: function mostrarPlantasDeCategorias(listadoPlantas)
 * Comentario: Este metodo se encaga de mostra la informacion que tengan la plantas que se encuentran en un listado de plantas
 * Entradas:listadoPlantas
 * Salidas: Ninguna
 * Precondiciones: Ninguna
 * Postcondiciones: Se mostrara la informacion de todas las plantas que hay en la lista de plantas que se recibe
 *
 */
/*
 * Para el nombre de la categoria(Se ve pero esta hecho de una manera muyyy fea(Se guarda en el id del input checbox)), se podria buscar por el id que tiene la planta. Tambien he pensado en hacer un modelo de una planta con Nombre de la categoria, asi este metodo recibirira un listado plantasConNombreCategoria
 * Habria que controlar el borrar las plantas de las categorias que hay, cuando se cambia de opcion en los checkbox
 */
function mostrarPlantasDeCategorias(listadoPlantas, nombreCategoria) {
    var titulo = document.createElement("h3");
    titulo.innerHTML = nombreCategoria;
    document.body.appendChild(titulo);
    listadoPlantas.forEach(function (planta, i, listadoPlantas) {
        var nombre = document.createElement("div");
        nombre.innerHTML = planta.nombre + " " + planta.precio + "€";
        document.body.appendChild(nombre);
    })
    var hr = document.createElement("hr");
    document.body.appendChild(hr);
}

/*
 * Cabecera: function verPlantas()
 * Comentario: Este metodo se encarga de obtener todos los inputs que hay y si se han checked se procede a llamar al metodo que se comunica con la api
 * Entradas: Ninguna
 * Salidas: Ninguna
 * Precondiciones: Ninguna
 * Postcondiciones: Se llamara al metodo obtenerPlantasDeCategoria pasandole el valor que tenga el 
 *
 */
function verPlantas() {
    var listaCheckBox = document.getElementsByTagName("input");
    var categoriasSeleccionadas = false;
    for (var i = 0; i < document.getElementsByTagName("input").length; i++) {
        if (listaCheckBox[i].checked) {//Si hay algun checkbox seleccionado
            obtenerPlantasDeCategoria(listaCheckBox[i].value, listaCheckBox[i].id);//Se llama al metodo que se comunica con la api, pasandole el id de la categoria.
            categoriasSeleccionadas = true;
        }
    }
    if (!categoriasSeleccionadas) {
        alert("No has seleccionado ninguna categoria");
    }
}

