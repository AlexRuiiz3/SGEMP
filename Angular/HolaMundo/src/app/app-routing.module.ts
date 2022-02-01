import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';

const routes: Routes = [
{path: 'tablaPersonas', component: TablaPersonasComponent} //Para que en la url salga http://localhost:4200/tablaPersonas

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
