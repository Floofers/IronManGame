﻿using Microsoft.Xna.Framework;
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
        public enum PlayerState
        {
            idle,
            running
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState ks;
        Texture2D IronManSheet;
        List<Rectangle> IdleFrames;
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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            IronManSheet = Content.Load<Texture2D>("IronManSpriteSheet");

            IdleFrames = new List<Rectangle>();
            IdleFrames.Add(new Rectangle(1, 1, 30, 40));
            IdleFrames.Add(new Rectangle(36, 1, 30, 40));
            IdleFrames.Add(new Rectangle(71, 2, 32, 39));
            IdleFrames.Add(new Rectangle(108, 3, 31, 38));
            IdleFrames.Add(new Rectangle(145, 3, 31, 38));
            IdleFrames.Add(new Rectangle(181, 4, 30, 37));
            IdleFrames.Add(new Rectangle(216, 1, 29, 40));

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

            CurrentFrames = IdleFrames;

            currentFrame = 0;
            elapsedTime = new TimeSpan();
            idleTime = TimeSpan.FromMilliseconds(100);
            runningTime = TimeSpan.FromMilliseconds(75);
            playerState = PlayerState.idle;
            goalTime = idleTime;
            effects = SpriteEffects.None;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ks = Keyboard.GetState();
            elapsedTime += gameTime.ElapsedGameTime;

            if (ks.IsKeyDown(Keys.D))
            {
                playerState = PlayerState.running;
                if (CurrentFrames != RunninFrames)
                {
                    CurrentFrames = RunninFrames;
                    currentFrame = 0;
                    elapsedTime = new TimeSpan();
                    goalTime = runningTime;
                    IronManPosition = new Vector2(IronManPosition.X, GraphicsDevice.Viewport.Height - CurrentFrames[currentFrame].Height * 3);
                }
                effects = SpriteEffects.None;
                IronManPosition.X += 3;
            }
            else if(ks.IsKeyDown(Keys.A))
            {
                playerState = PlayerState.running;
                if (CurrentFrames != RunninFrames)
                {
                    CurrentFrames = RunninFrames;
                    currentFrame = 0;
                    elapsedTime = new TimeSpan();
                    goalTime = runningTime;
                    IronManPosition = new Vector2(IronManPosition.X, GraphicsDevice.Viewport.Height - CurrentFrames[currentFrame].Height * 3);
                }
                effects = SpriteEffects.FlipHorizontally;
                IronManPosition.X -= 3;
            }
            else if (ks.IsKeyDown(Keys.Space))
            {

            }
            else
            {
                playerState = PlayerState.idle;
                if(CurrentFrames != IdleFrames)
                {
                    CurrentFrames = IdleFrames;
                    currentFrame = 0;
                    elapsedTime = new TimeSpan();
                    goalTime = idleTime;
                    IronManPosition = new Vector2(IronManPosition.X, GraphicsDevice.Viewport.Height - CurrentFrames[currentFrame].Height * 3);
                }
            }

            if (elapsedTime >= goalTime)
            {
                currentFrame++;
                if (currentFrame >= CurrentFrames.Count)
                {
                    currentFrame = 0;

                }

                IronManPosition = new Vector2(IronManPosition.X, GraphicsDevice.Viewport.Height - CurrentFrames[currentFrame].Height * 3);
                elapsedTime = new TimeSpan();
            }

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

            spriteBatch.Draw(IronManSheet, IronManPosition, CurrentFrames[currentFrame], Color.White, 0, Vector2.Zero, 3, effects, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
