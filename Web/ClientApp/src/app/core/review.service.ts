import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map, tap } from 'rxjs/operators';
import { GridDataResult } from '@progress/kendo-angular-grid';


@Injectable()
export class ReviewService {
    public loading: boolean;
    constructor ( private apollo: Apollo) {

    }
    getReviews(skip: number, take: number, sort: any[]): Observable<any> {
        alert(JSON.stringify(sort));
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
              }
              
              `,
            variables: {
                skip: skip,
                take: take,
                sort: sort
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