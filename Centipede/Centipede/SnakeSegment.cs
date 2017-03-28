using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class SnakeSegment : SpriteGameObject
    {
        Vector2 StartPosition;
        private int speed = 200;
        public static int snakeLenght = 10;

        public SnakeSegment(int x, int y, string assetname) : base(assetname)
        {
            StartPosition = new Vector2(x, y);
            this.position = StartPosition;
            this.Velocity = new Vector2(speed, 0);
        }

        public void Bounce()
        {                        
            this.position = new Vector2(this.position.X, position.Y + 32);
            this.Velocity *= -1;            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.position.X < 0 || this.position.X + this.sprite.Width > Centipede.Screen.X)
            {
                Bounce();
            }
        }
    }
}
