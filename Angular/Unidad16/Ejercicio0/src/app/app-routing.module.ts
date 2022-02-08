import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablaPersonasComponent } from './componentes/tabla-personas/tabla-personas.component';

const routes: Routes = [
  {path:"",redirectTo:"/tabla",pathMatch:"full"},
  {path:"tabla",component:TablaPersonasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
