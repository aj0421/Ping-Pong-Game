using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    class Paddle 
    {
        #region Variables

  
        protected Texture2D _texture;
        public Vector2 position;
        public Vector2 velocity;
        public float speed;

        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)_texture.Width, (int)_texture.Height);
            }
        }
        #endregion

        #region Methods
    
        public Paddle(Texture2D texture, Vector2 position) 
        {
            this._texture = texture;
            this.position = position;
            speed = 5f;
        }
      
        public bool MoveUp()
        {
            velocity.Y = -speed;
            position += velocity;
            position.Y = MathHelper.Clamp(position.Y, 0, 700 - _texture.Height);
            velocity = Vector2.Zero;
            return true;
        }
        public bool MoveDown()
        {
            velocity.Y = speed;
            position += velocity;
            position.Y = MathHelper.Clamp(position.Y, 0, 700 - _texture.Height);
            velocity = Vector2.Zero;
            return true;
        }
        public bool DoNothing()
        {
            return true;
        }
      
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, Color.Red);
        }
        #endregion
    }
}
