import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ModelService } from '../../core/model.service';
import { ModelValidator } from '../../core/model.validator';
import { Observable, fromEvent, merge } from 'rxjs';
import { CompileValidator } from '../../core/compile.validator';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-model',
  templateUrl: './add-model.component.html',
  styleUrls: ['./add-model.component.css']
})
export class AddModelComponent implements OnInit, AfterViewInit {
  formGroup: FormGroup;
  accountCtrl: FormControl;
  typenameCtrl: FormControl;
  sourceCtrl: FormControl;

  hideRules: boolean;
  @ViewChild('source') source;
  @ViewChild('typename') typename;

  get errors() {
    if (this.formGroup.get('source').hasError('compile')) {
      return this.formGroup.get('source').errors.errors;
    }
    return [];
  }
  constructor(private modelService: ModelService, private router: Router, private route: ActivatedRoute) { 

    this.accountCtrl = new FormControl('');
    this.sourceCtrl = new FormControl('', { validators: Validators.required, asyncValidators: CompileValidator.create(this.modelService, this.onCompileResult.bind(this)) });
    this.typenameCtrl = new FormControl('', { asyncValidators: ModelValidator.create(this.modelService, this.sourceCtrl)} ),
    this.hideRules = true;
    this.formGroup = new FormGroup({
      'accountId': this.accountCtrl,
      'typename': this.typenameCtrl,
      'source': this.sourceCtrl
    });
    
  }

  onCompileResult(result: boolean) {
    if (result)
      this.typenameCtrl.setValue(this.typenameCtrl.value);
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    merge(
      fromEvent(this.source.nativeElement, 'keypress'),
      fromEvent(this.typename.nativeElement, 'keypress')
    ).subscribe(t=> {
      //alert('hey');
    });
  }

  toggleRules() {
    this.hideRules = !this.hideRules;
  }

  onAddModel(value: any) {
    if (this.formGroup.valid) {
      this.modelService.createModelFromCSharp(
        value.source, value.typename, value.accountId
      ).subscribe(t=> {
        this.router.navigate(['../'], { relativeTo: this.route});
      });
    }
  }

}
