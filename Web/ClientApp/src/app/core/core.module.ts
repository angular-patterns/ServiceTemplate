import { NgModule } from '@angular/core';
import { HttpClientModule }from '@angular/common/http';
import { AccountService } from './account.service';


@NgModule({
  imports:      [ HttpClientModule ],
  declarations: [ ],
  bootstrap:    [ ],
  exports: [

  ],
  providers: [
    AccountService
  ]
})
export class CoreModule {
}
