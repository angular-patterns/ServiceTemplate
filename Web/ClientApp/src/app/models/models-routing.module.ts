import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddModelComponent } from './add-model/add-model.component';
import { ModelsListComponent } from './models-list/models-list.component';

const routes: Routes = [
  { path: '', component: ModelsListComponent, pathMatch: 'full'},
  { path:'add', component: AddModelComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModelsRoutingModule { }
