import { Component, OnInit } from '@angular/core';
import { PersonasserviceService } from 'src/app/services/personasservice.service';
import { Persona } from 'src/app/interfaces/persona';

@Component({
  selector: 'app-tabla-personas',
  templateUrl: './tabla-personas.component.html',
  styleUrls: ['./tabla-personas.component.css']
})


export class TablaPersonasComponent implements OnInit {

  listadoPersonas : Persona[];
  constructor(private personaService: PersonasserviceService) { }

  ngOnInit(): void {
    this.personaService.getPersonas().subscribe(personas => {this.listadoPersonas = personas})
  }
}
