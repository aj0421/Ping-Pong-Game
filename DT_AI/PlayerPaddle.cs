using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    class PlayerPaddle 
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

        public PlayerPaddle(Texture2D texture, Vector2 position) 
        {
            this._texture = texture;
            this.position = position;
            speed = 10f;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -speed;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = speed;
            }

            position += velocity;

            position.Y = MathHelper.Clamp(position.Y, 0, 700 - _texture.Height);
            velocity = Vector2.Zero;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, Color.Black);
        }

        #endregion
    }
}
