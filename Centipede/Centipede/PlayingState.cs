using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class PlayingState : GameObjectList
    {
        Player player;
        Bullet bullet;
        public GameObjectList snakeSegments;
        public GameObjectList mushrooms;
        public Score score;

        public PlayingState()
        {
            player = new Player();
            bullet = new Bullet();
            snakeSegments = new GameObjectList();
            mushrooms = new GameObjectList();
            score = new Score();

            this.Add(new SpriteGameObject("spr_background"));           
            this.Add(bullet);
            this.Add(player);
            this.Add(snakeSegments);
            this.Add(mushrooms);
            this.Add(score);

            for (int i = 0; i < SnakeSegment.snakeLenght; i++)
            {
                if (i < SnakeSegment.snakeLenght - 1)
                {
                    this.snakeSegments.Add(new SnakeSegment(i * 32, 0, "spr_snakebody"));
                }

                if (i == SnakeSegment.snakeLenght - 1)
                {
                    this.snakeSegments.Add(new SnakeSegment(i * 32, 0, "spr_snakehead"));
                }
            }

            for (int i = 0; i < Mushroom.mushAmount; i++)
            {
                this.mushrooms.Add(new Mushroom());
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.Space))
            {
                bullet.FirePosition = new Vector2(player.Position.X + (player.Width - bullet.Width) / 2, player.Position.Y + 20);
                bullet.Fire();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (SnakeSegment snakeSegment in snakeSegments.Objects)
            {
                foreach (Mushroom mushroom in mushrooms.Objects){

                    if (snakeSegment.CollidesWith(mushroom)){
                        snakeSegment.Bounce();
                    }
                }
            }

            foreach (Mushroom mushroom in mushrooms.Objects)
            {
                if (bullet.CollidesWith(mushroom))
                {
                    bullet.Reset();
                    mushrooms.Remove(mushroom);
                    break;
                }                
            }

            foreach (SnakeSegment snakeSegment in snakeSegments.Objects)
            {
                if (player.CollidesWith(snakeSegment))
                {
                    Centipede.GameStateManager.SwitchTo("GameOverState");
                }
            }
        }
    }
}
