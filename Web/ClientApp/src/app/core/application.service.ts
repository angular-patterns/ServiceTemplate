import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map, tap } from 'rxjs/operators';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ApplicationService extends BehaviorSubject<GridDataResult> {
    public loading: boolean;
    constructor ( private apollo: Apollo) {
        super(null);

    }
    applications(reviewbusinessId: string, state: any): void { 
        this.fetch(reviewbusinessId, state)
            .subscribe(x => super.next(x));
    }

    fetch(reviewBusinessId: string, state: any):Observable<any> {
        this.loading = true;
        return this.apollo.query({
            query: gql`
            query GetApplications($reviewBusinessId:String!, $skip: Int!, $take: Int!, $sort: [InputSortDescriptorType]) {
                applications(reviewBusinessId: $reviewBusinessId, skip: $skip, take: $take, sort: $sort) {
                  data {
                    applicationDisplay
                    applicationStatus
                    sin
                    firstName
                    lastName
                  }
                  total
                }
              }`,
            variables: {
                reviewBusinessId: reviewBusinessId,
                skip: state.skip,
                take: state.take,
                sort: state.sort
            },
            fetchPolicy: 'network-only'
        })
        .pipe(
            map(t => t.data as any),
            map(t => t.applications),
            map((t: any) => (<GridDataResult>{
                data: t.data,
                total: t.total
            })),
            tap(() => this.loading = false)
        );
    }

}