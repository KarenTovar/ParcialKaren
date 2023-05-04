import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './Components/clientes/clientes.component';
import { FarmaciaComponent } from './Components/farmacia/farmacia.component';
import { FarmacosComponent } from './Components/farmacos/farmacos.component';
import { FormClientesComponent } from './Components/Forms/form-clientes/form-clientes.component';
import { FormFarmaciaComponent } from './Components/Forms/form-farmacia/form-farmacia.component';
import { FormFarmacosComponent } from './Components/Forms/form-farmacos/form-farmacos.component';

const routes: Routes = [
  {path:"clientes", component:ClientesComponent},
  {path:"farmacia", component:FarmaciaComponent},
  {path:"farmacos", component:FarmacosComponent},
  {path:"create-cliente", component:FormClientesComponent},
  {path:"create-farmacos", component:FormFarmacosComponent},
  {path:"create-farmacia", component:FormFarmaciaComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
