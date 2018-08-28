import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../core/model.service';

@Component({
  selector: 'app-models-list',
  templateUrl: './models-list.component.html',
  styleUrls: ['./models-list.component.css']
})
export class ModelsListComponent implements OnInit {
  models: any[];
  constructor(private modelService: ModelService) {
    modelService.getModels().subscribe(t=> {
      this.models = t;
    });
   }

  ngOnInit() {
  }

}
