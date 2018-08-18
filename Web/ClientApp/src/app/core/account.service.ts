import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AccountService {
    constructor(private http: HttpClient) {

    }
    getAccounts(): Observable<any> {
        var gql = {
            query: `{
                accounts {
                    accountId
                    username
                    password
                }
            }` 
        };
          
        return this.http.post('http://localhost:3697/graphql', gql, { withCredentials: true });
    }

    deleteAccount(accountId: number) {
        var gql = {
            query: `
            
            mutation {
                deleteAccount(id: ${accountId})
            }` 
        };
        return this.http.post('http://localhost:3697/graphql', gql, { withCredentials: true });
    }
}
