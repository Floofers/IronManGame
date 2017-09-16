using Microsoft.Xna.Framework;
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
        int currentFrame;
        List<Rectangle> frames;
        public Animation(TimeSpan elapsedTime, List<Rectangle> frames, int currentFrame)
        {
            this.elapsedTime = elapsedTime;
            this.frames = frames;
            this.currentFrame = currentFrame;
        }
    }
}
