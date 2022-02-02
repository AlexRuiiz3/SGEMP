import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListadoPersonasComponent } from './Components/listado-personas/listado-personas.component';
import { TablaPersonasComponent } from './Components/tabla-personas/tabla-personas.component';
import { FormularioPersonasComponent } from './Components/formulario-personas/formulario-personas.component';

@NgModule({
  declarations: [
    AppComponent,
    ListadoPersonasComponent,
    TablaPersonasComponent,
    FormularioPersonasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
