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
        PlayerState CurrentState;

        public IronMan (Texture2D image, Vector2 position, Color tint, Vector2 speed)
            :base(speed)
        {
            currentAnimation = new Animation(TimeSpan.Zero, null, image, position, tint, new Vector2(3), 0, SpriteEffects.None);

            List<Rectangle> idleFrames = new List<Rectangle>();
            idleFrames.Add(new Rectangle(1, 1, 30, 40));
            idleFrames.Add(new Rectangle(36, 1, 30, 40));
            idleFrames.Add(new Rectangle(71, 2, 32, 39));
            idleFrames.Add(new Rectangle(108, 3, 31, 38));
            idleFrames.Add(new Rectangle(145, 3, 31, 38));
            idleFrames.Add(new Rectangle(181, 4, 30, 37));
            idleFrames.Add(new Rectangle(216, 1, 29, 40));
            
            AddAnimations(PlayerState.idle, idleFrames, TimeSpan.FromMilliseconds(100));

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

            AddAnimations(PlayerState.running, runningFrames, TimeSpan.FromMilliseconds(75));

            List<Rectangle> jumpingFrames = new List<Rectangle>();
            jumpingFrames.Add(new Rectangle(1, 305, 32, 38));
            jumpingFrames.Add(new Rectangle(38, 297, 27, 46));
            jumpingFrames.Add(new Rectangle(70, 305, 32, 38));
            jumpingFrames.Add(new Rectangle(107, 305, 32, 38));
            jumpingFrames.Add(new Rectangle(144, 307, 32, 36));
            jumpingFrames.Add(new Rectangle(818, 304, 32, 39));
           
            AddAnimations(PlayerState.jumping, jumpingFrames, TimeSpan.FromMilliseconds(100));

            List<Rectangle> fallingFrames = new List<Rectangle>();
            fallingFrames.Add(new Rectangle(218, 296, 27, 47));
            fallingFrames.Add(new Rectangle(250, 297, 27, 46));
            fallingFrames.Add(new Rectangle(282, 296, 26, 46));
            fallingFrames.Add(new Rectangle(313, 297, 27, 46));
            fallingFrames.Add(new Rectangle(345, 297, 27, 46));

            AddAnimations(PlayerState.falling, fallingFrames, TimeSpan.FromMilliseconds(100));

            List<Rectangle> shootingFrames = new List<Rectangle>();
            shootingFrames.Add(new Rectangle(1, 426, 41, 37));
            shootingFrames.Add(new Rectangle(47, 425, 39, 38));

            AddAnimations(PlayerState.shooting, shootingFrames, TimeSpan.FromMilliseconds(500));

            //List<Rectangle> bulletFrames = new List<Rectangle>();
            //bulletFrames.Add(new Rectangle(1, 743, 16, 8));
            //bulletFrames.Add(new Rectangle(22, 743, 16, 8));

            List<Shot> bullets = new List<Shot>();

            ChangeState(PlayerState.idle);
        }

        public override void Update(GameTime gameTime, Viewport viewport)
        {
            ks = Keyboard.GetState();
            
            //if (ks.IsKeyUp(Keys.D) &&  CurrentState != PlayerState.jumping)
            //{
            //    ChangeState(PlayerState.jumping);
                
            //}
            //else if (ks.IsKeyUp(Keys.A) && CurrentState == PlayerState.jumping)
            //{
            //    ChangeState(PlayerState.jumping);
                
            //}
            if (ks.IsKeyDown(Keys.D))
            {
                ChangeState(PlayerState.running);
                runningState = RunningState.Right;
            }
            else if (ks.IsKeyDown(Keys.A))
            {
                ChangeState(PlayerState.running);
                runningState = RunningState.Left;
            }
            else if (ks.IsKeyDown(Keys.W))
            {
                ChangeState(PlayerState.jumping);
                jumpingState = JumpingState.InitialJump;
                isJumping = true;
            }
            else if (ks.IsKeyDown(Keys.Space))
            {
                ChangeState(PlayerState.shooting);

                
            }
            else if (StateEquals(PlayerState.jumping) && ks.IsKeyUp(Keys.W))
            {
                isJumping = true;
            }
            else if(ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.W))
            {
                ChangeState(PlayerState.idle);
                isJumping = false;
            }

            base.Update(gameTime, viewport);
        }
    }
}
