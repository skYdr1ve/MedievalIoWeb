import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable } from 'rxjs';
import { StoreItemModel } from "../../models/store-item.model";

@Injectable()
export class StoreService {
  constructor(private http: ApiService) {
  }

  getStoreItems(filter: string): Observable<StoreItemModel[]> {
    return this.http.get<StoreItemModel[]>(`Store/GetStoreItems?filter=${filter}`);
  }
}
