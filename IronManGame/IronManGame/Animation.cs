using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class Animation
    {
        List<Rectangle> frames;
        TimeSpan timer;

        public Animation(List<Rectangle> frames, TimeSpan timer)
        {
            this.frames = frames;
            this.timer = timer;
        }
    }
}
