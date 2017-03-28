using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Score : TextGameObject
    {
        public int score;

        public Score(string assetname = "GameFont", int layer = 0, string id = "") : base(assetname, layer, id)
        {
            this.Text = "Score: 0";
            this.Position = new Vector2(300, 50);
        }

        public int ScoreValue
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                this.Text = "Score: " + value;
            }
        }
    }
}
