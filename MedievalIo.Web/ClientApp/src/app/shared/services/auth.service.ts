import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { LoginModel } from '../../models/login.model';
import { AuthenticatedUserModel } from '../../models/authenticated-user.model';
import { UserSessionManager } from './user-session.manager';
import { CookieService } from 'ngx-cookie-service';
import { RegisterModel } from "../../models/register.model";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: ApiService,
    private userSession: UserSessionManager,
    private cookieService: CookieService) {

    http.get<number>('Authentication/CookieExpiration').subscribe(result => {
      if (!this.cookieService.check('isAuthorized')) {
          this.logOut(() => { });
          return;
        }
      });
  }

  restoreUserSession() {
    this.http.get<AuthenticatedUserModel>('Authentication/User').subscribe(result => {
      this.userSession.updateSession(result);
    });
  }

  logIn(loginModel: LoginModel = null, next?: (value: any) => void) {
    if (loginModel) {
      this.http.post<AuthenticatedUserModel>('Authentication/Login', loginModel).subscribe(result => {
        if (result) {
          this.userSession.startSession(result);
          this.cookieService.set('isAuthorized', 'true');
        }
        next(result);
      });
    }
  }

  logOut(next?: (value: any) => void) {
    this.http.get<boolean>('Authentication/Logout').subscribe(result => {
      if (result) {
        this.userSession.closeSession();
        this.cookieService.delete('isAuthorized');
      }
      next(result);
    });
  }

  register(registerModel: RegisterModel): Observable<boolean> {
    return this.http.post<boolean>('Authentication/Register', registerModel);
  }

  
}
