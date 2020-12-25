import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable } from 'rxjs';
import { StoreItemModel } from "../../models/store-item.model";
import { BuyItemModel } from "../../models/buyItem.model";
import { EquipItemModel } from "../../models/equipItem.model";
import { UserItemInfoModel } from "../../models/user-item-info.model";

@Injectable()
export class StoreService {
  constructor(private http: ApiService) {
  }

  getStoreItems(filter: string): Observable<StoreItemModel[]> {
    return this.http.get<StoreItemModel[]>(`Store/GetStoreItems?filter=${filter}`);
  }

  buyItem(model: BuyItemModel): Observable<boolean> {
    return this.http.post<boolean>("Store/BuyItem", model);
  }

  equipItem(model: EquipItemModel): Observable<boolean> {
    return this.http.post<boolean>("Store/EquipItem", model);
  }

  getUserItems(id: string): Observable<UserItemInfoModel[]> {
    return this.http.get<UserItemInfoModel[]>(`Store/GetUserItems?userId=${id}`);
  }
}
