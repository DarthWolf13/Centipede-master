using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Centipede
{
    public class Centipede : GameEnvironment
    {
       

        public Centipede()
        {            
            Content.RootDirectory = "Content";
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(470, 550);
            SetFullScreen(false);

            gameStateManager.AddGameState("PlayingState", new PlayingState());
            gameStateManager.AddGameState("GameOverState", new GameOverState());
            gameStateManager.SwitchTo("PlayingState");
        }

    }
}
