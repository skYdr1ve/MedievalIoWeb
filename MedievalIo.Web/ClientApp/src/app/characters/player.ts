enum HealthState {
  IDLE,
  DAMAGE,
  DEAD
}

export default class Player extends Phaser.Physics.Arcade.Sprite {
  private healthState = HealthState.IDLE
  private damageTime = 0;

  private _health = 3;

  private knives?: Phaser.Physics.Arcade.Group;

  private sword: Phaser.Physics.Arcade.Sprite;

  get health() {
    return this._health;
  }

  constructor(scene: Phaser.Scene, x: number, y: number, texture: string, frame?: string | number) {
    super(scene, x, y, texture, frame);
    scene.physics.add.existing(this);
    scene.sys.displayList.add(this);
    scene.sys.updateList.add(this);
    scene.physics.world.enableBody(this, 0);

    this.body.setSize(this.width * 0.5, this.height * 0.8);

    this.anims.play('faune-idle-down');

    /*
    this.sword = this.scene.physics.add.sprite(this.x - 8, this.y, 'sword');
    this.sword.setScale(0.5);
    this.scene.input.on('pointerdown', (pointer) => {
      this.attack();
    });

    this.scene.input.on('pointermove', (pointer) => {
      const offSet = 90;

      var angleDeg = (Math.atan2(pointer.y - this.sword.y, pointer.x - this.sword.x) * 180 / Math.PI);
      angleDeg += offSet;
      this.sword.setAngle(angleDeg);
    });
    */
  }

  setKnives(knives: Phaser.Physics.Arcade.Group) {
    this.knives = knives;
  }

  handleDamage(dir: Phaser.Math.Vector2) {
    if (this._health <= 0) {
      return;
    }

    if (this.healthState === HealthState.DAMAGE) {
      return;
    }

    --this._health;

    if (this._health <= 0) {
      // TODO: die
      this.healthState = HealthState.DEAD;
      this.anims.play('faune-faint');
      this.setVelocity(0, 0);
    }
    else {
      this.setVelocity(dir.x, dir.y);

      this.setTint(0xff0000);

      this.healthState = HealthState.DAMAGE;
      this.damageTime = 0;
    }
  }

  private throwKnife() {
    if (!this.knives) {
      return;
    }

    const knife = this.knives.get(this.x, this.y, 'knife') as Phaser.Physics.Arcade.Image;
    if (!knife) {
      return;
    }

    const parts = this.anims.currentAnim.key.split('-');
    const direction = parts[2];

    const vec = new Phaser.Math.Vector2(0, 0);

    switch (direction) {
      case 'up':
        vec.y = -1;
        break;

      case 'down':
        vec.y = 1;
        break;

      default:
      case 'side':
        if (this.scaleX < 0) {
          vec.x = -1;
        }
        else {
          vec.x = 1;
        }
        break;
    }

    const angle = vec.angle();

    knife.setActive(true);
    knife.setVisible(true);

    knife.setRotation(angle);

    knife.x += vec.x * 16;
    knife.y += vec.y * 16;

    knife.setVelocity(vec.x * 300, vec.y * 300);
  }

  private attack() {
    const sword = this.scene.physics.add.image(this.x, this.y, 'sword');
    if (!sword) {
      return;
    }
  }

  preUpdate(t: number, dt: number) {
    super.preUpdate(t, dt);

    switch (this.healthState) {
      case HealthState.IDLE:
        break;

      case HealthState.DAMAGE:
        this.damageTime += dt;
        if (this.damageTime >= 250) {
          this.healthState = HealthState.IDLE;
          this.setTint(0xffffff);
          this.damageTime = 0;
        }
        break;
    }
  }

  update(cursors: Phaser.Types.Input.Keyboard.CursorKeys) {
    if (this.healthState === HealthState.DAMAGE
      || this.healthState === HealthState.DEAD
    ) {
      return;
    }

    if (Phaser.Input.Keyboard.JustDown(cursors.space!)) {
      this.throwKnife();
      return;
    }

    const speed = 100;

    const leftDown = cursors.left.isDown;
    const rightDown = cursors.right.isDown;
    const upDown = cursors.up.isDown;
    const downDown = cursors.down.isDown;

    if (leftDown && upDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(-speed, -speed);

      this.scaleX = -1;
      this.body.offset.x = 24;
    }
    else if (leftDown && downDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(-speed, speed);

      this.scaleX = -1;
      this.body.offset.x = 24;
    }
    else if (rightDown && upDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(speed, -speed);

      this.scaleX = 1;
      this.body.offset.x = 8;
    }
    else if (rightDown && downDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(speed, speed);

      this.scaleX = 1;
      this.body.offset.x = 8;
    }
    else if (leftDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(-speed, 0);

      this.scaleX = -1;
      this.body.offset.x = 24;
    }
    else if (rightDown) {
      this.anims.play('faune-run-side', true);
      this.setVelocity(speed, 0);

      this.scaleX = 1;
      this.body.offset.x = 8;
    }
    else if (upDown) {
      this.anims.play('faune-run-up', true);
      this.setVelocity(0, -speed);
    }
    else if (downDown) {
      this.anims.play('faune-run-down', true);
      this.setVelocity(0, speed);
    }
    else {
      const parts = this.anims.currentAnim.key.split('-');
      parts[1] = 'idle';
      this.anims.play(parts.join('-'));
      this.setVelocity(0, 0);
    }
  }
}
