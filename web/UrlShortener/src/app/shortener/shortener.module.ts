import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShortenerComponent } from './controlers/shortener.component';
import { ShortenerRoutingModule } from './shortener-routing.module';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [
    ShortenerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ShortenerRoutingModule,
  ]
})
export class ShortenerModule { }
