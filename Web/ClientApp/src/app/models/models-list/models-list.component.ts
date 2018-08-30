import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../core/model.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-models-list',
  templateUrl: './models-list.component.html',
  styleUrls: ['./models-list.component.css']
})
export class ModelsListComponent implements OnInit {
  models: any[];
  constructor(private route: ActivatedRoute) {
    route.data.subscribe(t=> {
      
      this.models = t.list;
    });
   }

  ngOnInit() {
  }

}
