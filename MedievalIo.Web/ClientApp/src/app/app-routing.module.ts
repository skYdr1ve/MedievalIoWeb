import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from "./modules/home/home.component";
import { LogInComponent } from "./modules/log-in/log-in.component";
import { AccessGuardService } from "./shared/services/access-guard.service";
import { GameComponent } from "./modules/game/game.component";

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AccessGuardService] },
  { path: 'game', component: GameComponent },
  { path: 'login', component: LogInComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
