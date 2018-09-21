import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../../core/account.service';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {
  formGroup: FormGroup;
  constructor(private fb: FormBuilder, private accountService : AccountService) { 
    this.initForm();
  }

  ngOnInit() {
  }
  initForm() {
    this.formGroup = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onSubmit() {
    if (this.formGroup.valid) {
      var account = this.formGroup.value;
      this.accountService.addAccount(account.username, account.password).then(t=> {
        this.initForm();
      });
    }
  }
}
