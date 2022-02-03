import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators} from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  templateUrl: './formulario-reactivo.component.html',
  styleUrls: ['./formulario-reactivo.component.css']
})
export class FormularioReactivoComponent implements OnInit {

  formularioPersona: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.formularioPersona = new FormGroup(
      {
      nombre: new FormControl('',[Validators.required]),
      apellidos: new FormControl('',[Validators.maxLength(20)])
      }
    );
  }

  saludar(){
    if(this.formularioPersona.valid){
      alert("Hola " + this.formularioPersona.controls.nombre.value + this.formularioPersona.controls.apellidos.value)
    }
  }
  
}
