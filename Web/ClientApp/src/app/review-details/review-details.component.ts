import { Component, OnInit, Input } from '@angular/core';

import { GroupDescriptor, DataResult, process, State,  SortDescriptor } from '@progress/kendo-data-query';
import { GridDataResult, PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs';
import { ReviewService } from '../core/review.service';
import { ApplicationService } from '../core/application.service';

@Component({
  selector: 'app-review-details',
  templateUrl: './review-details.component.html',
  styleUrls: ['./review-details.component.css'],
  providers: [
    ApplicationService
  ]
})
export class ReviewDetailsComponent implements OnInit {
  @Input() item: any;
  view: Observable<GridDataResult>;
  public state: State = {
    skip: 0,
    take: 5,
    sort: []
  };

  constructor(private applicationService: ApplicationService) {

  }

  public ngOnInit(): void {
    this.loadItems();
  }


  private loadItems(): void {
    this.applicationService.applications(this.item.businessId, this.state.skip, this.state.take, this.state.sort);
  }

  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.applicationService.applications(this.item.businessId, this.state.skip, this.state.take, this.state.sort);
  }
}
