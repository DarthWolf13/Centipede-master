using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Player : SpriteGameObject
    {
        Vector2 StartPosition;
        private int speed = 200;

        public Player() : base("spr_player")
        {
            StartPosition = new Vector2(235, 500);

            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();

            this.Position = StartPosition;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.Left) || this.position.X + this.sprite.Width > Centipede.Screen.X)
                this.Velocity = new Vector2(-speed, 0);
            else if (inputHelper.IsKeyDown(Keys.Right) || this.position.X < 0)
                this.Velocity = new Vector2(speed, 0);
            else if (inputHelper.IsKeyDown(Keys.Up) || this.position.Y + this.sprite.Height > Centipede.Screen.Y)
                this.Velocity = new Vector2(0, -speed);
            else if (inputHelper.IsKeyDown(Keys.Down) || this.position.Y < 0)
                this.Velocity = new Vector2(0, speed);
            else this.Velocity = Vector2.Zero;

        }
    }
}
