import { Byte } from "@angular/compiler/src/util";

export interface Persona {
    id:Number;
    nombre:String;
    apellidos:String;
    telefono:String;
    direccion:String;
    foto:Byte[];
    fechaNacimiento:Date;
    idDepartamento:Number;
}
