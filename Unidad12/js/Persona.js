class Persona {
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
    get getNombre() {
        return this.nombre;
    }
    get getApellidos() {
        return this.apellidos
    }
}