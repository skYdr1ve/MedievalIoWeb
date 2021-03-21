export default class Preloader extends Phaser.Scene {
  constructor() {
    super('preloader');
  }

  preload() {
    this.load.image('tiles', 'tiles/dungeon_tiles.png');
    this.load.tilemapTiledJSON('dungeon', 'tiles/dungeon-1.json');

    this.load.atlas('faune', 'character/fauna.png', 'character/fauna.json');
    this.load.atlas('lizard', 'enemies/lizard.png', 'enemies/lizard.json');

    this.load.image('ui-heart-empty', 'ui/ui_heart_empty.png');
    this.load.image('ui-heart-full', 'ui/ui_heart_full.png');

    this.load.image('knife', 'weapons/weapon_knife.png');
    this.load.image('sword', 'weapons/weapon_sword.png');

    this.load.image('slash', 'weapons/slash.png');
  }

  create() {
    this.scene.start('mainScene');
  }
}
