import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../core/account.service';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {
  accounts: any[];
  constructor(private accountService: AccountService) {
    this.accountService.getAccounts().subscribe(t=> {
      this.accounts = [...t.accounts];
    });
    this.accountService.accountAdded$.subscribe(t=> {
      this.accounts.push(t);
    });
  }
  ngOnInit() {

  }
  onDelete(item: any) {
    this.accountService.deleteAccount(item.accountId).subscribe(t=> {
      var i = this.accounts.indexOf(item);
      if (i >= 0){
         this.accounts.splice(i, 1);
      }
    });
  }

}
