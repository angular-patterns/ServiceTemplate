import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map } from 'rxjs/operators';


@Injectable()
export class AccountService {
    accountAdded$: Observable<Account>;
    _accountAdded: Subject<Account>;
    constructor(private http: HttpClient, private apollo: Apollo) {
        this._accountAdded = new Subject<Account>();
        this.accountAdded$ = this._accountAdded.asObservable();
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
        })
        .pipe(
            map(t=>t.data)
        );
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

    addAccount(username: string, password: string) {
        return this.apollo.mutate({
            mutation: gql`
                mutation AddAccount($username:String!, $password:String!) {
                    createAccount(username: $username, password: $password) {
                        accountId
                        username
                        password
                    }
                }
            `,
            variables: {
                'username': username,
                'password': password
            }
        }).pipe(
            map(t=>t.data.createAccount)
        ).toPromise()
        .then(t=> {
            this._accountAdded.next(t);
        });


    }
}
