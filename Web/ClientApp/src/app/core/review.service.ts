import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { map } from 'rxjs/operators';


@Injectable()
export class ReviewService {
    constructor ( private apollo: Apollo) {

    }
    getReviews(): Observable<any> {
        return this.apollo.query({
            query: gql`
            query GetReviews {
                reviews {
                  recordCount
                  total
                  percentage
                  businessId
                  message
                  category
                  subCategory
                }
              }`
        })
        .pipe(
            map(t => t.data)
        );
    }
}