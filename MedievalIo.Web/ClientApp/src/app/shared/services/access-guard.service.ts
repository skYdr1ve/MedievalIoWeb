import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

import { UserSessionManager } from "./user-session.manager";

@Injectable({ providedIn: 'root' })
export class AccessGuardService implements CanActivate {
  constructor(private userSession: UserSessionManager,
    public router: Router) {
  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log('aaaaaaaaaaaaaaaaaa');
    if (this.userSession.isLoggedIn) {
      console.log('isLoggedIn');
      return true;
    }
    console.log('not');
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
