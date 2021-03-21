import { Injectable } from '@angular/core';
import { AuthenticatedUserModel } from '../../models/authenticated-user.model';
import { Subject } from 'rxjs';
import { WalletModel } from '../../models/wallet.model';

@Injectable({
  providedIn: 'root'
})
export class UserSessionManager {
  private static userTokenStorageKey = 'userToken';
  private static userIdStorageKey = 'userId';
  private static userRoleNameStorageKey = 'isAdmin';
  private static userWalletStorageKey = 'userWallet';

  private _userToken: string;
  private _userId: string;
  private _isAdmin: string;
  private _userWallet: WalletModel;
  private _userAuthorized = new Subject<boolean>();
  private _walletUpdated = new Subject<WalletModel>();

  userAuthorized = this._userAuthorized.asObservable();
  walletUpdated = this._walletUpdated.asObservable();

  get isLoggedIn(): boolean {
    console.log(this._userToken);
    return this._userToken ? true : false;
  }

  get userToken(): string {
    return this._userToken;
  }

  get userId(): string {
    return this._userId;
  }

  get isAdmin(): string {
    return this._isAdmin;
  }

  get userWallet(): WalletModel {
    return this._userWallet;
  }

  set userWallet(value: WalletModel) {
    this._userWallet = value;
    localStorage.setItem(UserSessionManager.userWalletStorageKey, JSON.stringify(this._userWallet));
    this._walletUpdated.next(this._userWallet);
  }

  constructor() {
    window.addEventListener('storage', this.handleStorageEvent);
  }

  updateSession(user: AuthenticatedUserModel) {
    if (user) {
      this.startSession(user);
    } else {
      this.closeSession();
    }
  }

  startSession(user: AuthenticatedUserModel) {
    this._userToken = user.token;
    this._userId = user.userId;
    this._isAdmin = user.isAdmin;
    this._userWallet = user.wallet;

    localStorage.setItem(UserSessionManager.userTokenStorageKey, this.userToken);
    localStorage.setItem(UserSessionManager.userIdStorageKey, this.userId);
    localStorage.setItem(UserSessionManager.userRoleNameStorageKey, this.isAdmin);
    localStorage.setItem(UserSessionManager.userWalletStorageKey, JSON.stringify(this.userWallet));

    this._userAuthorized.next(true);
    this._walletUpdated.next(this._userWallet);
  }

  closeSession() {
    this._userToken = null;
    this._userId = null;
    this._isAdmin = null;
    this._walletUpdated.next({ coins: 0, gems: 0 } as WalletModel);

    localStorage.removeItem(UserSessionManager.userTokenStorageKey);
    localStorage.removeItem(UserSessionManager.userIdStorageKey);
    localStorage.removeItem(UserSessionManager.userRoleNameStorageKey);
    localStorage.removeItem(UserSessionManager.userWalletStorageKey);

    this._userAuthorized.next(false);
  }

  private handleStorageEvent = (event: StorageEvent): void => {
    if (event.key === UserSessionManager.userTokenStorageKey) {
      this._userToken = event.newValue;
      this._userAuthorized.next(true);
    }
    if (event.key === UserSessionManager.userRoleNameStorageKey) {
      this._isAdmin = event.newValue;
      this._userAuthorized.next(true);
    }
    if (event.key === UserSessionManager.userIdStorageKey) {
      this._userId = event.newValue;
      this._userAuthorized.next(true);
    }
    if (event.key === UserSessionManager.userWalletStorageKey) {
      this._userWallet = JSON.parse(event.newValue);
      this._walletUpdated.next(this._userWallet);
    }
  }
}
