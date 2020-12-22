import { Injectable } from '@angular/core';
import { AuthenticatedUserModel } from '../../models/authenticated-user.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserSessionManager {

  private static userTokenStorageKey = 'userToken';
  private static userIdStorageKey = 'userId';
  private static userRoleNameStorageKey = 'isAdmin';

  private _userToken: string;
  private _userId: string;
  private _isAdmin: string;
  private _userAuthorized = new Subject<boolean>();

  userAuthorized = this._userAuthorized.asObservable();

  get isLoggedIn(): boolean {
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

    localStorage.setItem(UserSessionManager.userTokenStorageKey, this.userToken);
    localStorage.setItem(UserSessionManager.userIdStorageKey, this.userId);
    localStorage.setItem(UserSessionManager.userRoleNameStorageKey, this.isAdmin);
    this._userAuthorized.next(true);
  }

  closeSession() {
    this._userToken = null;
    this._userId = null;
    this._isAdmin = null;

    localStorage.removeItem(UserSessionManager.userTokenStorageKey);
    localStorage.removeItem(UserSessionManager.userIdStorageKey);
    localStorage.removeItem(UserSessionManager.userRoleNameStorageKey);

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
  }
}
