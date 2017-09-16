using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class IronMan :  Animation
    {
        //IMPORTANT NOTES FOR INSTRUCTOR:  CLEAN UP BOTH THE ANIMATION AND IRONMAN CLASSES
            // ANIMATION CLASS SHOULD HAVE A PROPER IMPLEMENTATION OF FRAMES AND FRAMETYPES (DICTIONARY)
            // THE IRONMAN CLASS SHOULD INHERIT FROM THE ANIMATION CLASS PROPERLY WITH MINIMAL CHANGE TO THE FRAME SWITCHING FUNCTIONALITY
            // REDO BOTH CLASSES WITH DENNIS (IF NEEDED) IN ORDER TO PROVIDE A BETTER UNDERSTANDING AND PROPER IMPLEMENTATION

        string frameType;
        int currentFrame;
        TimeSpan elapsedTime;
        KeyboardState ks;
        SpriteEffects effects;
        Dictionary<PlayerState, List<Rectangle>> frameTypes;
        List<Rectangle> CurrentFrames;
        PlayerState playerState;
        TimeSpan goalTime;
        TimeSpan runningTime;

        

        int testelapsed;
        int testdelay;

        public IronMan(TimeSpan elapsedTime, Dictionary<PlayerState, List<Rectangle>> frames, int currentFrame, Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects effects, TimeSpan runningTime)
            :base(elapsedTime, new List<Rectangle>(), currentFrame, texture,  position,  color,  scale,  rotation,  effects)
        {
            this.frameTypes = frames;
            currentFrame = 0;
            CurrentFrames = frames[PlayerState.idle];
            //CurrentFrames = frames["runningFrames"];
            this.runningTime = runningTime;

            testdelay = 50;
            testelapsed = 0;
            
        }


        public void Move(GameTime gameTime, Viewport viewport)
        {
            //Console.WriteLine(this.position.ToString());
            
            ks = Keyboard.GetState();
            elapsedTime += gameTime.ElapsedGameTime;

            testelapsed += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ks.IsKeyDown(Keys.D))
            {
                playerState = PlayerState.running;
                if (CurrentFrames != frameTypes[PlayerState.running])
                {
                    CurrentFrames = frameTypes[PlayerState.running];
                    currentFrame = 0;
                    elapsedTime = new TimeSpan();
                    goalTime = runningTime;
                    position = new Vector2(position.X, viewport.Height - CurrentFrames[currentFrame].Height * 3);
                }
                currentFrame++;
                elapsedTime = new TimeSpan();
                effects = SpriteEffects.None;
                position.X += 3;
            }

            else if (ks.IsKeyDown(Keys.A))
            {
                playerState = PlayerState.running;
                if (CurrentFrames != frameTypes[PlayerState.running])
                {
                    CurrentFrames = frameTypes[PlayerState.running];
                    currentFrame = 0;
                    elapsedTime = new TimeSpan();
                    goalTime = runningTime;
                    position = new Vector2(position.X, viewport.Height - CurrentFrames[currentFrame].Height * 3);
                }
                elapsedTime = new TimeSpan();
                effects = SpriteEffects.FlipHorizontally;
                position.X -= 3;
            }
            else
            {
                playerState = PlayerState.idle;
            }

            if (elapsedTime >= goalTime)
            {

                if (currentFrame >= CurrentFrames.Count - 1)
                {
                    currentFrame = 0;

                }
                else
                {
                    currentFrame++;
                }
                position = new Vector2(position.X, viewport.Height - CurrentFrames[currentFrame].Height * 3);
                elapsedTime = new TimeSpan();
            }

            if (testelapsed >= testdelay)
            {
                

                if (currentFrame >= CurrentFrames.Count - 1)
                {
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                }
                testelapsed = 0;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Console.WriteLine(position.ToString());
            //switch (playerState)
            //{
            //    case PlayerState.idle:
            //        spriteBatch.Draw(texture, position, frames["idleFrames"][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);
            //        if(ks.IsKeyDown(Keys.D))
            //        {
            //            playerState = PlayerState.running;
            //        }
            //        break;
            //    case PlayerState.running:
            //        spriteBatch.Draw(texture, position, frames["runningFrames"][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);
            //        break;

            //}
            spriteBatch.Draw(texture, position, frameTypes[playerState][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);

        }
    }
}
