import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { RulesetsComponent } from './rulesets/rulesets.component';

@NgModule({
  imports:      [ 
    BrowserModule, 
    AppRoutingModule, 
    CoreModule,
    SharedModule
  ],
  declarations: [ AppComponent, RulesetsComponent ],
  bootstrap:    [ AppComponent ],
  exports: [AppComponent]
})
export class AppModule {
}
