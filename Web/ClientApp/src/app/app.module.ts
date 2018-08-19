import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { AccountsModule } from './accounts/accounts.module';

@NgModule({
  imports:      [ 
    BrowserModule, 
    AppRoutingModule, 
    CoreModule,
    AccountsModule ,
  ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ],
  exports: [AppComponent]
})
export class AppModule {
}
