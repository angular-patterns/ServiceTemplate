import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddModelComponent } from './add-model/add-model.component';
import { ModelsListComponent } from './models-list/models-list.component';
import { ModelDetailComponent } from './model-detail/model-detail.component';
import { ModelsResolver } from './services/models.resolver';

const routes: Routes = [
  { path: '', component: ModelsListComponent, pathMatch: 'full', resolve: { list: ModelsResolver}},
  { path: 'add', component: AddModelComponent},
  { path: ':id', component: ModelDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModelsRoutingModule { }
