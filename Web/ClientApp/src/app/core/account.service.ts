import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';

@Injectable()
export class AccountService {
    constructor(private http: HttpClient, private apollo: Apollo) {

    }
    getAccounts(): Observable<any> {          
        return this.apollo.query({
            query: gql`
            {
                accounts {
                    accountId
                    username
                    password
                }
            }
            `
        });
    }

    deleteAccount(accountId: number) {
        return this.apollo.mutate({
            mutation: gql`
            mutation DeleteAccount($accountId:Int!) {
                deleteAccount(id: $accountId)
            }`,
            variables: {
                'accountId': accountId
            }
        });
        
    }
}
