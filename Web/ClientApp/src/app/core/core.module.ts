import { NgModule } from '@angular/core';
import { HttpClientModule }from '@angular/common/http';
import { AccountService } from './account.service';
import {ApolloModule, Apollo} from 'apollo-angular';
import {HttpLinkModule, HttpLink} from 'apollo-angular-link-http';
import {InMemoryCache} from 'apollo-cache-inmemory';
import { ReviewService } from './review.service';

@NgModule({
  imports:      [ 
    HttpClientModule,
    ApolloModule,
    HttpLinkModule
 
  ],
  declarations: [ ],
  bootstrap:    [ ],
  exports: [

  ],
  providers: [
    AccountService,
    ReviewService
  ]
})
export class CoreModule {
  constructor(apollo: Apollo, httpLink: HttpLink) {
    apollo.create({
      // By default, this client will send queries to the
      // `/graphql` endpoint on the same host
      link: httpLink.create({uri: 'http://localhost:3697/graphql'}),
      cache: new InMemoryCache()
    });
  }
}
