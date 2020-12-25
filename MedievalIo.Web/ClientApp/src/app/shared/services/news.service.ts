import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable } from 'rxjs';
import { NewsModel } from "../../models/news.model";

@Injectable()
export class NewsService {
  constructor(private http: ApiService) {
  }

  getNews(): Observable<NewsModel[]> {
    return this.http.get<NewsModel[]>(`News/GetNews`);
  }
}
