import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';

import { ModelsRoutingModule } from './models-routing.module';
import { AddModelComponent } from './add-model/add-model.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModelsRoutingModule
  ],
  declarations: [AddModelComponent]
})
export class ModelsModule { }
