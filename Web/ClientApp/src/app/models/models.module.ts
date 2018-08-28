import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';

import { ModelsRoutingModule } from './models-routing.module';
import { AddModelComponent } from './add-model/add-model.component';
import { ModelsListComponent } from './models-list/models-list.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModelsRoutingModule
  ],
  declarations: [AddModelComponent, ModelsListComponent]
})
export class ModelsModule { }
