using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    public class Animation : Sprite
    {
        protected TimeSpan elapsedTime;
        public TimeSpan goalTime;
        public int currentFrame;
        public List<Rectangle> frames;

        public Animation(TimeSpan goalTime, List<Rectangle> frames, Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects effects)
            : base(texture, position, color, scale, rotation, effects)
        {
            elapsedTime = TimeSpan.Zero;
            currentFrame = 0;
            this.goalTime = goalTime;
            this.frames = frames;
        }

        public virtual void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            Console.WriteLine(currentFrame);
            if (elapsedTime >= goalTime)
            {

                currentFrame++;

                if (currentFrame >= frames.Count)
                {
                    currentFrame = 0;
                }

                elapsedTime = TimeSpan.Zero;
            }

            sourceRectangle = frames[currentFrame];
        }
    }
}
