import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GameComponent } from "./modules/game/game.component";
import { ApiService } from "./shared/services/api.service";
import { UserSessionManager } from "./shared/services/user-session.manager";
import { AuthService } from "./shared/services/auth.service";
import { LogInComponent } from './modules/log-in/log-in.component';
import { AppRoutingModule } from "./app-routing.module";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    LogInComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    ApiService,
    UserSessionManager,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
