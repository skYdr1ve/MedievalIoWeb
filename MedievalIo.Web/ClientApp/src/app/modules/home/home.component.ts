import { Component, NgModule } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GameComponentModule } from "../game/game.component";
import { StatisticsPopupComponent } from "../statistics-popup/statistics-popup.component";
import { MaterialModule } from "../../material-module";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { ShopPopupComponent } from "../shop-popup/shop-popup.component";
import { WalletModel } from "../../models/wallet.model";
import { WalletService } from '../../shared/services/wallet.service';
import { NewsPopupComponent } from "../news-popup/news-popup.component";
import { Subscription } from 'rxjs';
import { UserSessionManager } from "../../shared/services/user-session.manager";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  model: any;
  walletModel: WalletModel;
  subscriptions: Subscription[] = [];

  constructor(private session: UserSessionManager,
    public statisticsPopup: MatDialog,
    public shopPopup: MatDialog,
    public newsPopup: MatDialog,
    private wallet: WalletService) {
  }

  ngOnInit() {
    this.model = this.getDefaultModel();
    this.getWallet();
  }

  getWallet(): void {
    this.wallet.getWallet().subscribe(result => {
      console.log(result);
      this.walletModel = result;
    });
    this.subscriptions.push(this.session.walletUpdated.subscribe(wallet => {
      console.log(wallet);
      this.walletModel = wallet;
    }));
  }

  statisticsInfo() {
    this.statisticsPopup.open(StatisticsPopupComponent, {
      data: {},
      panelClass: 'statistics-dialog',
      width: '700px',
    });
  }

  shop() {
    this.shopPopup.open(ShopPopupComponent, {
      data: {},
      panelClass: 'shop-dialog',
      width: '1000px',
    });
  }

  news() {
    this.newsPopup.open(NewsPopupComponent, {
      data: {},
      panelClass: 'news-dialog',
      width: '700px',
    });
  }

  getDefaultModel() {
    return {
      ['background-image']: 'images/fon.jpg',
      ['medivalIo-image']: 'images/medievalIo.png'
    };
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }
}

@NgModule({
  declarations: [HomeComponent],
  exports: [HomeComponent],
  imports: [
    CommonModule,
    GameComponentModule,
    MaterialModule,
    NgbModule
  ]
})
export class HomeModule { }
