import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModelService } from '../../core/model.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-model-detail',
  templateUrl: './model-detail.component.html',
  styleUrls: ['./model-detail.component.css']
})
export class ModelDetailComponent implements OnInit {
  model: any;
  formGroup: FormGroup;
  constructor(private route: ActivatedRoute, private modelService: ModelService) {
    this.model = {};
    this.populate();
    
    var id = this.route.snapshot.params.id;
    this.modelService.getModel(id).subscribe(t=> {
      this.model = t;
      this.populate();
    });
  }

  ngOnInit() {
  }

  populate() {
    this.formGroup = new FormGroup({
      'modelId': new FormControl(this.model.id),
      'accountId': new FormControl(this.model.accountId),
      'namespace': new FormControl(this.model.namespace),
      'typename': new FormControl(this.model.typeName),
      'jsonSchema': new FormControl(this.model.jsonSchema),
      'cSharpSource': new FormControl(this.model.cSharpSource)
    });


  }

}
