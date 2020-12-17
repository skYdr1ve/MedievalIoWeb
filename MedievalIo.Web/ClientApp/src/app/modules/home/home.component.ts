import { Component, NgModule } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GameComponentModule } from "../game/game.component";
import { StatisticsPopupComponent } from "../statistics-popup/statistics-popup.component";
import { MaterialModule } from "../../material-module";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  model: any;

  constructor(public statisticsPopup: MatDialog) {
  }

  ngOnInit() {
    this.model = this.getDefaultModel();
  }

  statisticsInfo() {
    this.statisticsPopup.open(StatisticsPopupComponent, {
      data: {},
      width: '700px',
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
