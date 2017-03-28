using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Bullet : SpriteGameObject
    {
        Vector2 StartPosition;
        public Vector2 FirePosition;
        private int speed = 200;

        public Bullet() : base("spr_bullet")
        {
            StartPosition = new Vector2(-100, -100);

            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();

            this.Velocity = Vector2.Zero;
            this.Position = StartPosition;
        }

        public void Fire()
        {
            this.Position = FirePosition;
            this.Velocity = new Vector2(0, -speed);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayingState PS = GameWorld as PlayingState;

            foreach (SnakeSegment snakeSegment in PS.snakeSegments.Objects)
            {
                if (this.CollidesWith(snakeSegment))
                {
                    this.Reset();
                    PS.mushrooms.Add(new Mushroom(snakeSegment.Position));
                    PS.snakeSegments.Remove(snakeSegment);
                    PS.score.ScoreValue += 10;
                    break;
                }
            }
        }

    }
}
