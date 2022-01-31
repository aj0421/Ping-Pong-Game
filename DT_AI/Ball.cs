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
    class Ball
    {
        #region Variables

        private Random random;

        public bool isPlaying;
        public bool isTurn;

        protected Texture2D texture;

        public Vector2 position;
        public Vector2 velocity;
        private Vector2? startPos = null;

        private float? startSpeed;
        public float speed;
        private float timer = 0f;

        public int speedIncrement = 10;

        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            }
        }

        #endregion

        #region Methods

  
        public Ball(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            speed = 3f;
            random = new Random();

        }
        public void Update(GameTime gameTime, Paddle paddle, PlayerPaddle playerPaddle, Score score)
        {
            if (startPos == null)
            {
                startPos = position;
                startSpeed = speed;
                Restart();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                isPlaying = true;

            if (!isPlaying)
                return;

            if (position.X >= 450)
            {
                isTurn = true;
            }
            else
            {
                isTurn = false;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > speedIncrement)
            {
                speed++;
                timer = 0;
            }

            CollisionCheck(paddle, playerPaddle);

            if (position.Y <= 0 || position.Y + texture.Height >= 700)
            {
                velocity.Y = -velocity.Y;
            }

            if (position.X <= 0)
            {
                score.AiScore++;
                Restart();
            }
            if (position.X + texture.Width >= 900)
            {
                score.playerScore++;
                Restart();
            }

            position += velocity * speed;
        }
        private void Restart()
        {
            var direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    velocity = new Vector2(1, 1);
                    break;
                case 1:
                    velocity = new Vector2(1, -1);
                    break;
                case 2:
                    velocity = new Vector2(-1, -1);
                    break;
                case 3:
                    velocity = new Vector2(-1, 1);
                    break;
            }

            position = (Vector2)startPos;
            speed = (float)startSpeed;
            timer = 0;
            isPlaying = false;

        }

        #region collision
        private void CollisionCheck(Paddle paddle, PlayerPaddle playerPaddle)
        {

            if (this.velocity.X > 0 && this.IsTouchingLeft(paddle))
                this.velocity.X = -this.velocity.X;
            if (this.velocity.X < 0 && this.IsTouchingRight(paddle))
                this.velocity.X = -this.velocity.X;
            if (this.velocity.Y > 0 && this.IsTouchingTop(paddle))
                this.velocity.Y = -this.velocity.Y;
            if (this.velocity.Y < 0 && this.IsTouchingBottom(paddle))
                this.velocity.Y = -this.velocity.Y;
            if (this.velocity.X > 0 && this.IsTouchingLeft(playerPaddle))
                this.velocity.X = -this.velocity.X;
            if (this.velocity.X < 0 && this.IsTouchingRight(playerPaddle))
                this.velocity.X = -this.velocity.X;
            if (this.velocity.Y > 0 && this.IsTouchingTop(playerPaddle))
                this.velocity.Y = -this.velocity.Y;
            if (this.velocity.Y < 0 && this.IsTouchingBottom(playerPaddle))
                this.velocity.Y = -this.velocity.Y;

        }

        protected bool IsTouchingLeft(Paddle m)
        {
            return this.hitbox.Right + this.velocity.X > m.hitbox.Left &&
                    this.hitbox.Left < m.hitbox.Left &&
                     this.hitbox.Bottom > m.hitbox.Top &&
                     this.hitbox.Top < m.hitbox.Bottom;
        }
        protected bool IsTouchingRight(Paddle m)
        {
            return this.hitbox.Left + this.velocity.X < m.hitbox.Right &&
                    this.hitbox.Right > m.hitbox.Right &&
                     this.hitbox.Bottom > m.hitbox.Top &&
                     this.hitbox.Top < m.hitbox.Bottom;
        }
        protected bool IsTouchingTop(Paddle m)
        {
            return this.hitbox.Bottom + this.velocity.Y > m.hitbox.Top &&
                    this.hitbox.Top < m.hitbox.Top &&
                     this.hitbox.Right > m.hitbox.Left &&
                     this.hitbox.Left < m.hitbox.Right;
        }
        protected bool IsTouchingBottom(Paddle m)
        {
            return this.hitbox.Top + this.velocity.Y < m.hitbox.Bottom &&
                    this.hitbox.Bottom > m.hitbox.Bottom &&
                     this.hitbox.Right > m.hitbox.Left &&
                     this.hitbox.Left < m.hitbox.Right;
        }
        protected bool IsTouchingLeft(PlayerPaddle m)
        {
            return this.hitbox.Right + this.velocity.X > m.hitbox.Left &&
                    this.hitbox.Left < m.hitbox.Left &&
                     this.hitbox.Bottom > m.hitbox.Top &&
                     this.hitbox.Top < m.hitbox.Bottom;
        }
        protected bool IsTouchingRight(PlayerPaddle m)
        {
            return this.hitbox.Left + this.velocity.X < m.hitbox.Right &&
                    this.hitbox.Right > m.hitbox.Right &&
                     this.hitbox.Bottom > m.hitbox.Top &&
                     this.hitbox.Top < m.hitbox.Bottom;
        }
        protected bool IsTouchingTop(PlayerPaddle m)
        {
            return this.hitbox.Bottom + this.velocity.Y > m.hitbox.Top &&
                    this.hitbox.Top < m.hitbox.Top &&
                     this.hitbox.Right > m.hitbox.Left &&
                     this.hitbox.Left < m.hitbox.Right;
        }
        protected bool IsTouchingBottom(PlayerPaddle m)
        {
            return this.hitbox.Top + this.velocity.Y < m.hitbox.Bottom &&
                    this.hitbox.Bottom > m.hitbox.Bottom &&
                     this.hitbox.Right > m.hitbox.Left &&
                     this.hitbox.Left < m.hitbox.Right;
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        #endregion
    }
}
