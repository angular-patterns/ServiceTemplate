import { Component } from '@angular/core';
import { AccountService } from './core/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string;
  constructor() {
  }
}
