import { Component, NgModule, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from "../../material-module";
import { StoreService } from "../../shared/services/store.service";
import { BuyItemModel } from "../../models/buyItem.model";
import { UserSessionManager } from "../../shared/services/user-session.manager";
import { ToastrService } from "ngx-toastr";
import { Subscription } from 'rxjs';
import { WalletService } from "../../shared/services/wallet.service";
import { EquipItemModel } from "../../models/equipItem.model";

@Component({
  selector: 'shop-popup',
  templateUrl: './shop-popup.component.html',
  styleUrls: ['./shop-popup.component.css'],
})
export class ShopPopupComponent {
  previewItem: any;
  userItems: any[];
  listItems: any[];
  subscriptions: Subscription[] = [];
  constructor(private store: StoreService,
    private session: UserSessionManager,
    private toastr: ToastrService,
    private wallet: WalletService,
    public dialogRef: MatDialogRef<ShopPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.subscriptions.push(session.walletUpdated.subscribe(() => { this.getUsersItems(); }));
  }

  ngOnInit(): void {
    this.getSword();
    this.getUsersItems();
  }

  cancel(): void {
    this.dialogRef.close();
  }

  fullItem(item): void {
    this.previewItem = item;
  }

  getUrl(url): string {
    return `images/items/${url}.png`;
  }

  getUsersItems(): void {
    this.store.getUserItems(this.session.userId).subscribe(result => {
      console.log(result);
      this.userItems = result;
    });
  }

  getSword(): void {
    this.previewItem = null;
    this.listItems = null;
    this.store.getStoreItems("?_filter=type=='1'").subscribe(result => {
      console.log(result);
      this.listItems = result;
      if (this.listItems) {
        this.previewItem = this.listItems[0];
      }
    });
  }

  getArmor(): void {
    this.previewItem = null;
    this.listItems = null;
    this.store.getStoreItems("?_filter=type=='2'").subscribe(result => {
      this.listItems = result;
      if (this.listItems) {
        this.previewItem = this.listItems[0];
      }
    });
  }

  getHelmet(): void {
    this.previewItem = null;
    this.listItems = null;
    this.store.getStoreItems("?_filter=type=='3'").subscribe(result => {
      this.listItems = result;
      if (this.listItems) {
        this.previewItem = this.listItems[0];
      }
    });
  }

  getTrail(): void {
    this.previewItem = null;
    this.listItems = null;
    this.store.getStoreItems("?_filter=type=='4'").subscribe(result => {
      this.listItems = result;
      if (this.listItems) {
        this.previewItem = this.listItems[0];
      }
    });
  }

  buyItem(item): void {
    this.store.buyItem({ itemId: item.id, userId: this.session.userId } as BuyItemModel).subscribe(result => {
      if (result) {
        this.wallet.getWallet().subscribe(x => this.session.userWallet = x);
        this.toastr.success('Success');
        this.getUsersItems();
      } else {
        this.toastr.error('Unexpected error.', 'Error');
      }
    });
  }

  equipItem(item): void {
    this.store.equipItem({ itemId: item.id, userId: this.session.userId } as EquipItemModel).subscribe(result => {
      if (result) {
        this.toastr.success('Success');
        this.getUsersItems();
      } else {
        this.toastr.error('Unexpected error.', 'Error');
      }
    });
  }

  checkItemToBuy(item): boolean {
    if (this.userItems) {
      return !this.userItems.some(x => x.itemId === item.id);
    }

    return true;
  }

  checkItemToEquip(item): boolean {
    if (this.userItems) {
      return !this.userItems.some(x => x.itemId === item.id && x.equipped);
    }

    return true;
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }
}

@NgModule({
  declarations: [ShopPopupComponent],
  exports: [ShopPopupComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    NgbModule,
    MatButtonModule,
    MaterialModule,
  ]
})
export class ShopPopupModule { }
