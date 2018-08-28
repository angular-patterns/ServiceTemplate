import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ModelService } from '../../core/model.service';
import { CompileValidator } from '../../core/compile.validator';

@Component({
  selector: 'app-add-model',
  templateUrl: './add-model.component.html',
  styleUrls: ['./add-model.component.css']
})
export class AddModelComponent implements OnInit {
  formGroup: FormGroup;
  hideRules: boolean;
  get errors() {
    if (this.formGroup.get('source').hasError('compile')) {
      return this.formGroup.get('source').errors.errors;
    }
    return [];
  }
  constructor(private modelService: ModelService) { 
    this.hideRules = true;
    this.formGroup = new FormGroup({
      'accountId': new FormControl('', Validators.required),
      'typename': new FormControl('', Validators.required),
      'source': new FormControl('', Validators.required, CompileValidator.create(this.modelService))
    });
  }

  ngOnInit() {
  }

  toggleRules() {
    this.hideRules = !this.hideRules;
  }

  onAddModel(value: any) {
    if (this.formGroup.valid) {
      this.modelService.createModelFromCSharp(
        value.source, value.typename, value.accountId
      ).subscribe(t=> {
        alert(t.id);
      });
    }
  }

}
