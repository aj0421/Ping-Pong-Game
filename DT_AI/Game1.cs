using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DT_AI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int windowSizeX;
        public int windowSizeY;
        Texture2D ballTex;
        Texture2D paddleTex;
        Ball ball;
        Paddle paddle;
        PlayerPaddle playerPaddle;
        DecisionNode decisionNode;
        Score score;
        bool turn = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            windowSizeX = graphics.PreferredBackBufferWidth = 900;
            windowSizeY = graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            score = new Score(Content.Load<SpriteFont>("Font"));
            ballTex = Content.Load<Texture2D>("ballis");
            paddleTex = Content.Load<Texture2D>("paddle");
            ball = new Ball(ballTex, new Vector2((windowSizeX / 2) - (ballTex.Width / 2), (windowSizeY / 2) - (ballTex.Height / 2)));
            paddle = new Paddle(paddleTex, new Vector2(windowSizeX - 20 - paddleTex.Width, (windowSizeY / 2) - (paddleTex.Height / 2)));
            playerPaddle = new PlayerPaddle(paddleTex, new Vector2(20, (windowSizeY / 2) - paddleTex.Height / 2));
            decisionNode = new DecisionNode();


        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ball.Update(gameTime, paddle, playerPaddle, score);
            playerPaddle.Update(gameTime);

            var root = decisionNode.MainDecision(paddle);
        
                root.Evaluate(ball);
          

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            score.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            playerPaddle.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
