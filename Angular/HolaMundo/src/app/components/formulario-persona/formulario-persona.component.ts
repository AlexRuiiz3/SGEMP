import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-formulario-persona',
  templateUrl: './formulario-persona.component.html',
  styleUrls: ['./formulario-persona.component.css']
})
export class FormularioPersonaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  saludar(): void{
    alert(this.example);
  }

}
