import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable } from 'rxjs';
import { WalletModel } from "../../models/wallet.model";

@Injectable()
export class WalletService {
  constructor(private http: ApiService) {
  }

  getWallet(): Observable<WalletModel> {
    return this.http.get<WalletModel>("Wallet/GetWallet");
  }
}
