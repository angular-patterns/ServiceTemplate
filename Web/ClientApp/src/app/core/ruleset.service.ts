import gql from 'graphql-tag';
import {Apollo} from 'apollo-angular';
import { Injectable } from '@angular/core';


const GET_RULESETS = gql`
query GetRulesets {
    ruleSets {
      id
      title
      businessId
      model {
          namespace
          typeName          
      }
      createdOn
      modelId
    }
  }`;

@Injectable()
export class RulesetService {

}
