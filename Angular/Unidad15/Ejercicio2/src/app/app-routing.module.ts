import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablaPersonasComponent } from './Components/tabla-personas/tabla-personas.component';
import { FormularioReactivoComponent } from './Components/formulario-reactivo/formulario-reactivo.component';

const routes: Routes = [
{path:'', redirectTo:'/tabla', pathMatch:'full'},
{path:'tabla', component:TablaPersonasComponent},
{path:'formulario', component:FormularioReactivoComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
