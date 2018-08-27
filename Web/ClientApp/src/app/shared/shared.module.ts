import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MasterPageComponent } from './master-page/master-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    MasterPageComponent, 
    NavbarComponent, 
    HeaderComponent, FooterComponent
  ],
  exports: [
    MasterPageComponent
  ]

})
export class SharedModule { }
