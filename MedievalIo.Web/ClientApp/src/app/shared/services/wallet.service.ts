import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { Observable, Subject } from 'rxjs';
import { WalletModel } from "../../models/wallet.model";

@Injectable()
export class WalletService {
  private _walletUpdated = new Subject<WalletModel>();
  walletUpdated = this._walletUpdated.asObservable();

  constructor(private http: ApiService) {
  }

  getWallet(): Observable<WalletModel> {
    return this.http.get<WalletModel>("Wallet/GetWallet");
  }
}
