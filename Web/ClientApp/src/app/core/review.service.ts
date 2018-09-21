import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map, tap } from 'rxjs/operators';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GroupDescriptor, DataResult, process } from '@progress/kendo-data-query';

@Injectable()
export class ReviewService extends BehaviorSubject<GridDataResult> {
    public loading: boolean;
    constructor ( private apollo: Apollo) {
        super(null);

    }
    reviews(state: any): void {

        this.fetch(state)
            .subscribe(x => { 
                var dr: DataResult = process(x.data, { group: state.group });
                dr.total = x.total;
                console.log(dr);
                super.next(dr);
            });
    }

    fetch(state: any): Observable<GridDataResult> {
      console.log(JSON.stringify(state));
        this.loading = true;
        return this.apollo.query({
            query: gql`
query GetReviews($state: InputQueryStateType!) {
  reviews(state: $state) {
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
                state: state
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
