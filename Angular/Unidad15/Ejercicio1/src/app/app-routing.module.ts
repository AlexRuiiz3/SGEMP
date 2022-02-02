import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablaPersonasComponent } from './Components/tabla-personas/tabla-personas.component';
import { ListadoPersonasComponent } from './Components/listado-personas/listado-personas.component';
import { FormularioPersonasComponent } from './Components/formulario-personas/formulario-personas.component';

const routes: Routes = [
  {path:'', redirectTo:'/tabla', pathMatch:'full'},
  {path:'tabla', component:TablaPersonasComponent},
  {path:'formulario', component:FormularioPersonasComponent},
  {path:'listado', component:ListadoPersonasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
