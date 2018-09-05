import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { AccountsModule } from './accounts/accounts.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReviewService } from './core/review.service';

@NgModule({
  imports:      [ 
    BrowserModule, 
    AppRoutingModule, 
    CoreModule,
    AccountsModule ,
    BrowserAnimationsModule, 
    GridModule
  ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ],
  exports: [AppComponent],
  providers: [

  ]
})
export class AppModule {
}
