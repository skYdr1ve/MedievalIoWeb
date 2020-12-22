import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

import { UserSessionManager } from "./user-session.manager";
import { AuthService } from "./auth.service";
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class AccessGuardService implements CanActivate {
  constructor(private userSession: UserSessionManager,
    public router: Router,
    private authService: AuthService,
    private toastr: ToastrService) {
  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.authService.restoreUserSession();
    if (this.userSession.isLoggedIn) {
      console.log("aaaaaaaaaaaaaaaa");
      return true;
    }


    console.log("bbbbbbbbbbbbbb");
    this.toastr.warning('To play Medieval IO, you need to be logged in.', 'Warning');
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
