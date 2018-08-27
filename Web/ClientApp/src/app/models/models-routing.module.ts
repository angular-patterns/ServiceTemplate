import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddModelComponent } from './add-model/add-model.component';

const routes: Routes = [
  { path:'add', component: AddModelComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModelsRoutingModule { }
