using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class IronMan :  Sprite
    {

        public enum PlayerState
        {
            idle,
            running
        }

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

        Dictionary<PlayerState, Animation> animations;


        public IronMan(Texture2D texture, Vector2 position, Color color)
            :base(texture, position, color)
        {
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
        }


    }
}
