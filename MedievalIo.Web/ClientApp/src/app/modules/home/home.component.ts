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

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  model: any;
  walletModel: WalletModel;

  constructor(public statisticsPopup: MatDialog,
    public shopPopup: MatDialog,
    private wallet: WalletService) {
  }

  ngOnInit() {
    this.model = this.getDefaultModel();

    this.wallet.getWallet().subscribe(result => {
      this.walletModel = result;
    });
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

  getDefaultModel() {
    return {
      ['background-image']: 'images/fon.jpg',
      ['medivalIo-image']: 'images/medievalIo.png'
    };
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
