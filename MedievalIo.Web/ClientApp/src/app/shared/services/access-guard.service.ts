import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

import { UserSessionManager } from "./user-session.manager";
import { AuthService } from "./auth.service";

@Injectable({ providedIn: 'root' })
export class AccessGuardService implements CanActivate {
  constructor(private auth: AuthService,
    private userSession: UserSessionManager,
    public router: Router) {
  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const result = await this.auth.restoreUserSessionObservable().toPromise();

    this.auth.updateSession(result);

    if (this.userSession.isLoggedIn) {
      return true;
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
