import { Injectable } from '@angular/core';
import { AuthenticatedUserModel } from '../../models/authenticated-user.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserSessionManager {

  private static userTokenStorageKey = 'userToken';
  private static userRoleNameStorageKey = 'userRole';

  private _userToken: string;
  private _userRole: string;
  private _userAuthorized = new Subject<boolean>();


  get isLoggedIn(): boolean {
    return this._userToken ? true : false;
  }

  get userToken(): string {
    return this._userToken;
  }

  get userRole(): string {
    return this._userRole;
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
    this._userRole = user.role;
    console.log(user);
    console.log(this._userToken);

    localStorage.setItem(UserSessionManager.userTokenStorageKey, this.userToken);
    localStorage.setItem(UserSessionManager.userRoleNameStorageKey, this.userRole);


    this._userAuthorized.next(true);
  }

  closeSession() {
    this._userToken = null;
    this._userRole = null;

    localStorage.removeItem(UserSessionManager.userTokenStorageKey);
    localStorage.removeItem(UserSessionManager.userRoleNameStorageKey);

    this._userAuthorized.next(false);
  }

  private handleStorageEvent = (event: StorageEvent): void => {
    if (event.key === UserSessionManager.userTokenStorageKey) {
      this._userToken = event.newValue;
      this._userAuthorized.next(true);
    }
    if (event.key === UserSessionManager.userRoleNameStorageKey) {
      this._userRole = event.newValue;
      this._userAuthorized.next(true);
    }
  }
}
