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
  }
  
`
const VALIDATE_MODEL = gql`
query ValidateModel($source: String!, $typename: String!) {
    validateModel(source: $source, typename: $typename) {
      success
      typeFound
      compileSucceeded
      compileErrors {
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

const GET_MODELS = gql`
query GetModels {
    models {
      id
      accountId
      namespace
      typeName
      jsonSchema
      cSharpSource
    }
  }`;

const GET_MODEL = gql`
query GetModel($id:Int!) {
    models(id:$id) {
      id
      accountId
      namespace
      typeName
      jsonSchema
      cSharpSource
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

    validateModel(source: string, typename: string) {
        return this.apollo.query({
            query: VALIDATE_MODEL,
            variables: { source: source, typename: typename }
        }).map(t=>t.data as any).map(t=>t.validateModel);

    }

    getModels() {
        return this.apollo.query({
            query: GET_MODELS,
            fetchPolicy: 'network-only'
        }).map(t=>t.data as any).map(t=>t.models);
    }

    getModel(id: number) {
        return this.apollo.query({
            query: GET_MODEL,
            variables: { id: id }
        }).map(t=>t.data as any).map(t=>t.models[0]);
    }
}