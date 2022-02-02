import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl} from '@angular/forms';

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
      nombre: new FormControl('',[]),
      apellidos: new FormControl('',[])
      }
    );
  }

  saludar(){
    alert("Hola "+this.formularioPersona.controls.apellidos.value)
  }

}
