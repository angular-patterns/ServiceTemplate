import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RulesetsRoutingModule } from './rulesets-routing.module';
import { RulesetListComponent } from './ruleset-list/ruleset-list.component';

@NgModule({
  imports: [
    CommonModule,
    RulesetsRoutingModule
  ],
  declarations: [RulesetListComponent]
})
export class RulesetsModule { }
