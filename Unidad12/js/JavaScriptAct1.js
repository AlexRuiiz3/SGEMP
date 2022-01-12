window.onload = inicializar;
function inicializar() {
    //  document.getElementById("BotonSaludar").addEventListener("click",mandarSaludo,false);
    document.getElementById("BotonSaludar").onclick = mandarSaludo;
}

function mandarSaludo() {
    alert("ola q ase");
}