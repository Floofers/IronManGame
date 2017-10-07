using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace IronManGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState ks;
        Texture2D IronManSheet;
        List<Rectangle> IdleFrames;
        public List<int> IdleOffSets;
        List<Rectangle> RunninFrames;
        List<Rectangle> CurrentFrames;
        TimeSpan idleTime;
        TimeSpan runningTime;
        TimeSpan goalTime;
        TimeSpan elapsedTime;
        int currentFrame;
        Vector2 IronManPosition;
        PlayerState playerState;
        SpriteEffects effects;
        IronMan ironMan;

        Dictionary<PlayerState, List<Rectangle>> frames;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            frames = new Dictionary<PlayerState, List<Rectangle>>();
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            IronManSheet = Content.Load<Texture2D>("IronManSpriteSheet");

            IronManPosition = new Vector2(0, Window.ClientBounds.Height - 120);
            

            RunninFrames = new List<Rectangle>();
            RunninFrames.Add(new Rectangle(1, 102, 29, 32));
            RunninFrames.Add(new Rectangle(36, 103, 27, 31));
            RunninFrames.Add(new Rectangle(68, 98, 26, 36));
            RunninFrames.Add(new Rectangle(99, 99, 16, 35));
            RunninFrames.Add(new Rectangle(120, 97, 22, 37));
            RunninFrames.Add(new Rectangle(147, 101, 30, 33));
            RunninFrames.Add(new Rectangle(182, 103, 29, 31));
            RunninFrames.Add(new Rectangle(216, 98, 26, 36));
            RunninFrames.Add(new Rectangle(247, 99, 19, 35));
            RunninFrames.Add(new Rectangle(271, 97, 24, 37));

            frames.Add(PlayerState.idle, IdleFrames);
            frames.Add(PlayerState.running, RunninFrames);


            CurrentFrames = IdleFrames;

            currentFrame = 0;
            elapsedTime = new TimeSpan();
            idleTime = TimeSpan.FromMilliseconds(100);
            runningTime = TimeSpan.FromMilliseconds(75);
            playerState = PlayerState.idle;
            goalTime = idleTime;
            effects = SpriteEffects.None;
            //ironMan = new IronMan(elapsedTime, goalTime, currentFrame, IronManSheet, IronManPosition, Color.White, new Vector2(3f), 0, SpriteEffects.None, runningTime, frames, IdleOffSets);
            ironMan = new IronMan(IronManSheet, new Vector2(IronManPosition.X + 100, IronManPosition.Y), Color.White, new Vector2(5, 10));
        }

        protected override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape))
                Exit();

            //ironMan.Move(gameTime, GraphicsDevice.Viewport, ks);
            ironMan.Update(gameTime, GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            ironMan.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
