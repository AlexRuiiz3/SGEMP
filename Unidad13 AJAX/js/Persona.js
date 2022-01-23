class Persona {
    constructor(nombre, apellidos,telefono,direccion,fechanNacimiento,foto,IDdepartamento) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.fechanNacimiento = fechanNacimiento;
        this.foto = foto;
        this.IDdepartamento = IDdepartamento;
    }
    get getNombre() {
        return this.nombre;
    }
    get getApellidos() {
        return this.apellidos;
    }
    get getTelefono() {
        return this.telefono
    }
    get getDireccion() {
        return this.direccion;
    }
    get getFechaNacimiento() {
        return this.fechanNacimiento
    }
    get getFoto() {
        return this.foto;
    }
    get getIDdepartamento() {
        return this.IDdepartamento
    } 
}