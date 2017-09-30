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
    class IronMan : Character
    {
        KeyboardState ks;
        public IronMan (Texture2D image, Vector2 position, Color tint, Vector2 speed)
            :base(speed)
        {
            List<Rectangle> idleFrames = new List<Rectangle>();
            idleFrames.Add(new Rectangle(1, 1, 30, 40));
            idleFrames.Add(new Rectangle(36, 1, 30, 40));
            idleFrames.Add(new Rectangle(71, 2, 32, 39));
            idleFrames.Add(new Rectangle(108, 3, 31, 38));
            idleFrames.Add(new Rectangle(145, 3, 31, 38));
            idleFrames.Add(new Rectangle(181, 4, 30, 37));
            idleFrames.Add(new Rectangle(216, 1, 29, 40));

            Animation idleAnimation = new Animation(TimeSpan.FromMilliseconds(100), idleFrames, image, position, tint, new Vector2(3), 0, SpriteEffects.None);

            AddAnimations(PlayerState.idle, idleAnimation);

            List<Rectangle> runningFrames = new List<Rectangle>();
            runningFrames.Add(new Rectangle(1, 102, 29, 32));
            runningFrames.Add(new Rectangle(36, 103, 27, 31));
            runningFrames.Add(new Rectangle(68, 98, 26, 36));
            runningFrames.Add(new Rectangle(99, 99, 16, 35));
            runningFrames.Add(new Rectangle(120, 97, 22, 37));
            runningFrames.Add(new Rectangle(147, 101, 30, 33));
            runningFrames.Add(new Rectangle(182, 103, 29, 31));
            runningFrames.Add(new Rectangle(216, 98, 26, 36));
            runningFrames.Add(new Rectangle(247, 99, 19, 35));
            runningFrames.Add(new Rectangle(271, 97, 24, 37));

            Animation runningAnimation = new Animation(TimeSpan.FromMilliseconds(75), runningFrames, image, position, tint, new Vector2(3), 0, SpriteEffects.None);

            AddAnimations(PlayerState.running, runningAnimation);

            ChangeState(PlayerState.idle);
        }

        public void Update()
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.D))
            {
                ChangeState(PlayerState.running);
                runningState = RunningState.Right;
            }
            if(ks.IsKeyDown(Keys.A))
            {
                runningState = RunningState.Left;
            }
        }
    }
}
