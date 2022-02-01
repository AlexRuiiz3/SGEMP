import { importType } from '@angular/compiler/src/output/output_ast';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormularioPersonaComponent } from './components/formulario-persona/formulario-persona.component';
import { ListadoComponent } from './components/listado/listado.component';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';

const routes: Routes = [
  {path: '',redirectTo:'tabla',pathMatch:'full',component: TablaPersonasComponent},
  {path: 'tabla',component: TablaPersonasComponent},
  {path: 'listado',component: ListadoComponent},
  {path: 'formulario',component: FormularioPersonaComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
