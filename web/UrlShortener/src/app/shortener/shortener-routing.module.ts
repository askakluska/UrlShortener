import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShortenerComponent } from './controlers/shortener.component';

const routes: Routes = [
  {
    path: '', component: ShortenerComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShortenerRoutingModule { }
