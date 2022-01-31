using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    public class Score
    {
        public int playerScore;
        public int AiScore;

        private SpriteFont font;

        public Score(SpriteFont font)
        {
            this.font = font;
        }

        public void  Draw(SpriteBatch sb)
        {
            sb.DrawString(font, playerScore.ToString(), new Vector2(650, 20), Color.White);    
            sb.DrawString(font, AiScore.ToString(), new Vector2(250, 20), Color.White);    
        }
    }
}
