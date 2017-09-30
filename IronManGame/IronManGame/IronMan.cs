﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class IronMan : Animation
    {
        KeyboardState ks;
        SpriteEffects effects;
        Dictionary<PlayerState, List<Rectangle>> ironManFrames;
        PlayerState playerState;
        TimeSpan runningTime;
        List<int> IdleFramesOffSets;
        Viewport viewport;

        public IronMan(TimeSpan elapsedTime, TimeSpan goalTime, int currentFrame, Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects effects, TimeSpan runningTime, Dictionary<PlayerState, List<Rectangle>> ironManFrames, List<int> IdleFramesOffSets)
            : base(elapsedTime, goalTime, new List<Rectangle>(), currentFrame, texture, position, color, scale, rotation, effects)
        {
            this.runningTime = runningTime;
            this.ironManFrames = ironManFrames;
            this.frames = ironManFrames[PlayerState.idle];
            this.IdleFramesOffSets = IdleFramesOffSets;

        }


        public void Move(GameTime gameTime, Viewport viewport, KeyboardState keystate)
        {
            this.viewport = viewport;
            //Console.WriteLine(this.position.ToString());

            ks = keystate;
            base.Move(gameTime);

            if (ks.IsKeyDown(Keys.D))
            {
                frames = ironManFrames[PlayerState.running];

                goalTime = runningTime;
                currentFrame = 0;
                position = new Vector2(position.X, viewport.Height - frames[currentFrame].Height * 3);
                effects = SpriteEffects.None;
                position.X += 3;

            }
            else if (ks.IsKeyDown(Keys.A))
            {
                playerState = PlayerState.running;


                goalTime = runningTime;
                currentFrame = 0;
                position = new Vector2(position.X, viewport.Height - frames[currentFrame].Height * 3);
                effects = SpriteEffects.FlipHorizontally;
                position.X -= 3;

            }
            else
            {
                frames = ironManFrames[PlayerState.idle];
                position = new Vector2(position.X, viewport.Height - frames[currentFrame].Height * 3);
                
            }



        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Console.WriteLine(position.ToString());
            switch (playerState)
            {
                case PlayerState.idle:
                    spriteBatch.Draw(texture, position, ironManFrames[playerState][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);
                    if (ks.IsKeyDown(Keys.D))
                    {
                        playerState = PlayerState.running;
                    }
                    break;
                case PlayerState.running:
                    spriteBatch.Draw(texture, position, ironManFrames[playerState][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);
                    break;

            }


        }
    }
}
