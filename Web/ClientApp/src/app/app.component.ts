import { Component, OnInit } from '@angular/core';
import { AccountService } from './core/account.service';
import { sampleProducts } from './products';
import { GroupDescriptor, DataResult, process, State,  SortDescriptor } from '@progress/kendo-data-query';
import { ReviewService } from './core/review.service';
import { GridDataResult, PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    ReviewService
  ]
})
export class AppComponent implements OnInit {
  view: Observable<GridDataResult>;
  public state: State = {
    skip: 0,
    take: 5,
    sort: [],
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };

  constructor(private reviewService: ReviewService) {
    this.view = reviewService;
    this.reviewService.reviews(this.state);
  }

  public ngOnInit(): void {    
  }



  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.reviewService.reviews(this.state);
  }
}
