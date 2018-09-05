import { Component, OnInit } from '@angular/core';
import { AccountService } from './core/account.service';
import { sampleProducts } from './products';
import { GroupDescriptor, DataResult, process } from '@progress/kendo-data-query';
import { ReviewService } from './core/review.service';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  reviews: any[];
  public pageSize = 10;
  public skip = 0;

  constructor(private reviewService: ReviewService) {

  }
  public groups: GroupDescriptor[] = [];

  public gridView: DataResult;

  public ngOnInit(): void {
    this.loadItems();
  }

  public groupChange(groups: GroupDescriptor[]): void {
    this.groups = groups;
    this.loadItems();
  }
  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.loadItems();
  }

  private loadItems(): void {
    this.reviewService.getReviews().subscribe(t => {
      alert('hey');
      this.reviews = t.reviews;
      this.gridView = {
        data: this.reviews.slice(this.skip, this.skip + this.pageSize),
        total: this.reviews.length
      };
      //this.gridView = process(this.reviews, { group: this.groups });
    });
  }
}
