import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map, tap } from 'rxjs/operators';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ReviewService extends BehaviorSubject<GridDataResult> {
    public loading: boolean;
    constructor ( private apollo: Apollo) {
        super(null);

    }
    reviews(state: any): void {
        this.fetch(state)
            .subscribe(x => super.next(x));
    }

    fetch(state: any): Observable<GridDataResult> {

        this.loading = true;
        return this.apollo.query({
            query: gql`
            query GetReviews($skip: Int!, $take: Int!, $sort: [InputSortDescriptorType]) {
                reviews(skip: $skip, take: $take, sort: $sort) {
                  data {
                    recordCount
                    total
                    percentage
                    businessId
                    message
                    category
                    subCategory
                  }
                  total
                }
              }`,
            variables: {
                skip: state.skip,
                take: state.take,
                sort: state.sort
            },
            fetchPolicy: 'network-only'
        })
        .pipe(
            map(t => t.data as any),
            map(t => t.reviews),
            map((t: any) => (<GridDataResult>{
                data: t.data,
                total: t.total
            })),
            tap(() => this.loading = false)
        );
    }
}