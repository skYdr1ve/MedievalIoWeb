import { Component, NgModule } from '@angular/core';
import { GameComponentModule } from "../game/game.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  model: any;

  ngOnInit() {
    this.model = this.getDefaultModel();
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
    GameComponentModule
  ]
})
export class HomeModule { }
