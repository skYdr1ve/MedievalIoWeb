import { Component, OnInit, NgModule, HostListener  } from '@angular/core';

import Phaser from 'phaser';
import Preloader from "../../scenes/Preloader";
import MainScene from "../../scenes/MainScene";
import GameUI from "../../scenes/gameUI";

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  screenHeight: number;
  screenWidth: number;
  phaserGame: Phaser.Game;
  config: Phaser.Types.Core.GameConfig;
  constructor() {
    this.getScreenSize();
    this.config = {
      type: Phaser.AUTO,
      width: this.screenWidth,
      height: this.screenHeight-7,
      scene: [Preloader, MainScene, GameUI],
      parent: 'gameContainer',
      physics: {
        default: 'arcade',
        arcade: {
          gravity: { y: 0 },
          debug: false
        }
      }
    };
  }

  @HostListener('window:resize', ['$event'])
  getScreenSize(event?) {
    this.screenHeight = window.innerHeight;
    this.screenWidth = window.innerWidth;
    console.log(this.screenHeight, this.screenWidth);
  }

  ngOnInit() {
    this.phaserGame = new Phaser.Game(this.config);
    console.log(this.config);
    console.log(this.phaserGame);
  }
}

@NgModule({
  declarations: [GameComponent],
  exports: [GameComponent],
  imports: [
  ]
})
export class GameComponentModule { }
