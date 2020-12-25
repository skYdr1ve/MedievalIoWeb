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
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from "./material-module";
import { StatisticsService } from "./shared/services/statistics.service";
import { StoreService } from "./shared/services/store.service";
import { WalletService } from "./shared/services/wallet.service";
import { NewsService } from "./shared/services/news.service";

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
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MaterialModule
  ],
  providers: [
    ApiService,
    UserSessionManager,
    AuthService,
    StatisticsService,
    StoreService,
    WalletService,
    NewsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
