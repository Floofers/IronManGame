using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class Animation : Sprite
    {
        TimeSpan elapsedTime;
        TimeSpan goalTime;
        int currentFrame;
        List<Rectangle> frames;
        public Animation(TimeSpan elapsedTime, TimeSpan goalTime, List<Rectangle> frames, int currentFrame, Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects effects)
            :base( texture,  position,  color,  scale,  rotation,  effects)
        {
            this.elapsedTime = elapsedTime;
            this.goalTime = goalTime;
            this.frames = frames;
            this.currentFrame = currentFrame;

        }

        public void Move()
        {
            if (elapsedTime >= goalTime)
            {
                
                if (currentFrame < frames.Count)
                {
                    if(currentFrame >= frames.Count-1)
                    {
                        currentFrame = 0;
                    }
                    currentFrame++;
                    elapsedTime = new TimeSpan();
                }
                
            }
            
        }
    }
}
