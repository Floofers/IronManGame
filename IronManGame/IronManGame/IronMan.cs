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
    class IronMan :  Sprite
    {
        //switch your dictionary to key: enums value: list<rectangles>
        //have a proper way to switch between keys with the frames
        

        string frameType;
        int currentFrame;
        TimeSpan elapsedTime;
        KeyboardState ks;
        SpriteEffects effects;
        Dictionary<PlayerState, List<Rectangle>> frames;
        List<Rectangle> CurrentFrames;
        PlayerState playerState;
        TimeSpan goalTime;
        TimeSpan runningTime;

        int testelapsed;
        int testdelay;

        public IronMan(Texture2D texture, Vector2 position, Color color, Dictionary<PlayerState, List<Rectangle>> frames, TimeSpan runningTime)
            :base(texture, position, color)
        {
            this.frames = frames;
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
                if (CurrentFrames != frames[PlayerState.running])
                {
                    CurrentFrames = frames[PlayerState.running];
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
                if (CurrentFrames != frames[PlayerState.running])
                {
                    CurrentFrames = frames[PlayerState.running];
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
            spriteBatch.Draw(texture, position, frames[playerState][currentFrame], Color.White, 0f, Vector2.Zero, 3, effects, 0);

        }
    }
}
