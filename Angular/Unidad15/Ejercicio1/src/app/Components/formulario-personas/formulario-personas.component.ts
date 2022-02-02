import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';

@Component({
  selector: 'app-formulario-personas',
  templateUrl: './formulario-personas.component.html',
  styleUrls: ['./formulario-personas.component.css']
})
export class FormularioPersonasComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit(): void {
  }

  saludar(){
    alert((<HTMLInputElement>document.getElementById("iputNombre")).value+" "+(<HTMLInputElement>document.getElementById("iputApellidos")).value);
  }

  volver(){
    this.location.back();
  }
}
