import { Clipboard } from '@angular/cdk/clipboard';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Link } from '../models/shortener.model';
import { ShortenerService } from '../services/shortener.service';

@Component({
  selector: 'app-shortener',
  templateUrl: './shortener.component.html',
  styleUrls: ['./shortener.component.scss']
})
export class ShortenerComponent implements OnInit {

  public fullLink = '';
  public shortLink = '';
  public showInfo = false;
  public infoMessage?: string;
  public alertClass?: "warning" | "success" | "danger";

  constructor(private _shorternerService: ShortenerService,
    private _clipboard: Clipboard) { }

  ngOnInit(): void {

  }

  public submit() {
    if (this.fullLink.length < 1) {
      this.infoMessage = "Please provide link!";
      this.alertClass = 'warning';
      this.showInfo = true;
      return;
    }

    this.showInfo = false;
    this._shorternerService.shortenUrl(this.fullLink).subscribe({
      next: (res: Link) => {
        this.shortLink = `${environment.api}/Shortener/${res.shortenValue}`;
      },
      error: (err: HttpErrorResponse) => {
        this.infoMessage = err.error.detail;
        this.alertClass = 'danger'
        this.showInfo = true;
      }
    })
  }

  public copy() {
    this._clipboard.copy(this.shortLink)
    this.infoMessage = "Link copied into clipboard!";
    this.alertClass = 'success'
    this.showInfo = true;
  }

}
