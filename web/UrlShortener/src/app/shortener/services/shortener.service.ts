import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Link } from '../models/shortener.model';

@Injectable({
  providedIn: 'root'
})
export class ShortenerService {

  constructor(
    private httpClient: HttpClient) { }

  public shortenUrl(link: string): Observable<Link> {
    
    const body = {
      Link: link
    };

    return this.httpClient.post<Link>(`${environment.api}/Shortener`, body);
  }
}
