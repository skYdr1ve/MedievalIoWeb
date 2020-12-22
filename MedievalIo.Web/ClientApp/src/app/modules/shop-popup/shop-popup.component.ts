import { Component, NgModule, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from "../../material-module";
import { StoreService } from "../../shared/services/store.service";

@Component({
  selector: 'shop-popup',
  templateUrl: './shop-popup.component.html',
  styleUrls: ['./shop-popup.component.css'],
})
export class ShopPopupComponent {
  previewItem: any;

  listItems: any[] = [
    { name: 'Two handed sword of shadows', onSale: true, coinsPrice: 100, saleCoinsPrice: 50, image: 'images/sword.png', description: "Some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png' },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
    { name: 'Two handed sword of shadows', coinsPrice: 100, image: 'images/sword.png', description: "some text,some text,some text,some text,some text,some text," },
  ];

  constructor(private store: StoreService,
    public dialogRef: MatDialogRef<ShopPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    this.store.getStoreItems("").subscribe(result => {
      console.log(result);
      this.listItems = result;
      this.previewItem = this.listItems[0];
    });
  }

  cancel(): void {
    this.dialogRef.close();
  }

  fullItem(item): void {
    this.previewItem = item;
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
