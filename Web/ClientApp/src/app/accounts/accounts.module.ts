import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AddAccountComponent } from './add-account/add-account.component';
import { AccountListComponent } from './account-list/account-list.component';


@NgModule({
  imports:      [ 
    CommonModule
  ],
  declarations: [ 
    AddAccountComponent, 
    AccountListComponent
  ],
  bootstrap:    [ ],
  exports: [
    AddAccountComponent,
    AccountListComponent
  ],
  providers: [
  ]
})
export class AccountsModule {
}
