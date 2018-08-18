import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../core/account.service';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {
  data: any;
  constructor(private accountService: AccountService) {
    this.accountService.getAccounts().subscribe(t=> {
      this.data = t.data;
    });
  }
  ngOnInit() {

  }
  onDelete(item: any) {
    this.accountService.deleteAccount(item.accountId).subscribe(t=> {
      var i = this.data.accounts.indexOf(item);
      if (i >= 0){
        this.data.accounts.splice(i, 1);
      }
    });
  }

}
