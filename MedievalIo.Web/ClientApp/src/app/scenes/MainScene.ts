import { debugDraw } from '../shared/utils/debug'
import { createEnemyAnims } from "../anims/enemyAnims";
import { createCharacterAnims } from "../anims/characterAnims";

import Enemy from "../enemies/enemy";
import Player from "../characters/player";

import { sceneEvents } from "../events/EventsCenter"

export default class MainScene extends Phaser.Scene {
  private cursors!: Phaser.Types.Input.Keyboard.CursorKeys;
  private player!: Player;

  private knives!: Phaser.Physics.Arcade.Group
  private enemies!: Phaser.Physics.Arcade.Group

  private playerEnemiesCollider?: Phaser.Physics.Arcade.Collider;

  constructor() {
    super('mainScene');
  }

  preload() {
    this.cursors = this.input.keyboard.createCursorKeys();
    this.input.mouse.disableContextMenu();
  }

  create() {
    this.scene.run('game-ui');

    createEnemyAnims(this.anims);
    createCharacterAnims(this.anims);

    const map = this.make.tilemap({ key: 'dungeon' });
    const tileset = map.addTilesetImage('dungeon', 'tiles', 16, 16);

    const groundLayer = map.createStaticLayer('Ground', tileset);
    const wallsLayer = map.createStaticLayer('Walls', tileset);

    wallsLayer.setCollisionByProperty({ collides: true });

    this.knives = this.physics.add.group({
      classType: Phaser.Physics.Arcade.Image,
      maxSize: 3
    });

    //debugDraw(wallsLayer, this);
    this.player = new Player(this, 128, 128, 'faune', 'walk-down-3.png');
    this.player.setKnives(this.knives);
    //this.player = this.physics.add.sprite(128, 128, 'faune', 'walk-down-3.png');
    //this.player.body.setSize(this.player.width * 0.5, this.player.height * 0.8);

    this.cameras.main.startFollow(this.player, true);
    this.cameras.main.zoom = 3;

    this.enemies = this.physics.add.group({
      classType: Enemy,
      createCallback: (go) => {
        const enemyGo = go as Enemy;
        enemyGo.body.onCollide = true;
      }
    });

    this.enemies.get(256, 128, 'lizard');

    this.physics.add.collider(this.player, wallsLayer);
    this.physics.add.collider(this.enemies, wallsLayer);

    this.physics.add.collider(this.knives, wallsLayer, this.handleKnifeWallCollision, undefined, this);
    this.physics.add.collider(this.knives, this.enemies, this.handleKnifeEnemyCollision, undefined, this);

    this.playerEnemiesCollider = this.physics.add.collider(this.enemies, this.player, this.handlePlayerEnemyCollision, undefined, this);
  }

  private handleKnifeWallCollision(obj1: Phaser.GameObjects.GameObject, obj2: Phaser.GameObjects.GameObject) {
    this.knives.killAndHide(obj1);
  }

  private handleKnifeEnemyCollision(obj1: Phaser.GameObjects.GameObject, obj2: Phaser.GameObjects.GameObject) {
    this.knives.killAndHide(obj1);
    this.enemies.killAndHide(obj2);
  }

  private handlePlayerEnemyCollision(obj1: Phaser.GameObjects.GameObject, obj2: Phaser.GameObjects.GameObject) {
    const enemy = obj2 as Enemy;

    const dx = this.player.x - enemy.x;
    const dy = this.player.y - enemy.y;

    const dir = new Phaser.Math.Vector2(dx, dy).normalize().scale(200);

    this.player.handleDamage(dir);

    sceneEvents.emit('player-health-changed', this.player.health);

    if (this.player.health <= 0) {
      this.playerEnemiesCollider.destroy();;
    }
  }

  update(time: number, delta: number): void {
    if (this.player) {
      this.player.update(this.cursors);
    }
  }
}
