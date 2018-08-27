import gql from 'graphql-tag';
import {Apollo} from 'apollo-angular';
import { Injectable } from '@angular/core';
const CREATE_MODEL = gql`
mutation CreateModelFromCSharp($source: String!, $typename: String!, $accountId: Int!) {
    createModel(fromCSharp: {cSharpSource: $source, typeName: $typename, accountId: $accountId}) {
        id
    }
}`;

const COMPILE_SOURCE = gql`
query Compile($source: String!) {
    compile(source: $source) {
      success
      errors {
        code
        message
        severity
        stackTrace
        location {
          end
          fragment
          isInSource
          start
        }
      }
    }
  }`;

@Injectable()
export class ModelService {
    constructor(private apollo: Apollo) {
        
    }

    createModelFromCSharp(source: string, typename: string, accountId: number) {
        return this.apollo.mutate({
            mutation: CREATE_MODEL,
            variables: { source: source, typename: typename, accountId: accountId }
        }).map(t=>t.data as any).map(t=>t.createModel);
    }

    compileSource(source: string) {
        return this.apollo.query({
            query: COMPILE_SOURCE,
            variables: { source: source }
        }).map(t=>t.data as any).map(t=>t.compile);

    }
}