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
    class IronMan : Character
    {
        KeyboardState prevKs;

        TimeSpan shootingTime;

        bool ifSpace = false;
        List<Rectangle> frames;

        List<Shot> bullets = new List<Shot>();

        Viewport vp;

        List<Rectangle> idleFrames;
        bool isDoubleJump = false;

        int jumpCount = 0;

        public IronMan(Texture2D image, Vector2 position, Color tint, Vector2 speed, Viewport vp)
            : base(speed)
        {

            currentAnimation = new Animation(TimeSpan.Zero, frames, image, position, tint, new Vector2(3), 0, SpriteEffects.None);
            List<Rectangle> idleFrames = new List<Rectangle>();
            idleFrames.Add(new Rectangle(1, 1, 30, 40));
            idleFrames.Add(new Rectangle(36, 1, 30, 40));
            idleFrames.Add(new Rectangle(71, 2, 32, 39));
            idleFrames.Add(new Rectangle(108, 3, 31, 38));
            idleFrames.Add(new Rectangle(145, 3, 31, 38));
            idleFrames.Add(new Rectangle(181, 4, 30, 37));
            idleFrames.Add(new Rectangle(216, 1, 29, 40));
            this.vp = vp;
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

            AddAnimations(PlayerState.shooting, shootingFrames, TimeSpan.FromMilliseconds(250));

            List<Rectangle> crouchingFrames = new List<Rectangle>();
            crouchingFrames.Add(new Rectangle(1, 229, 27, 28));
            crouchingFrames.Add(new Rectangle(33, 229, 27, 28));

            AddAnimations(PlayerState.crouching, crouchingFrames, TimeSpan.FromMilliseconds(1000));

            List<Rectangle> shootingWhileRunningFrames = new List<Rectangle>();
            shootingWhileRunningFrames.Add(new Rectangle(1, 473, 35, 32));
            shootingWhileRunningFrames.Add(new Rectangle(41, 474, 34, 31));
            shootingWhileRunningFrames.Add(new Rectangle(80, 469, 33, 36));
            shootingWhileRunningFrames.Add(new Rectangle(118, 470, 26, 35));
            shootingWhileRunningFrames.Add(new Rectangle(149, 468, 29, 37));
            shootingWhileRunningFrames.Add(new Rectangle(183, 472, 35, 33));
            shootingWhileRunningFrames.Add(new Rectangle(223, 474, 34, 31));
            shootingWhileRunningFrames.Add(new Rectangle(262, 469, 33, 36));
            shootingWhileRunningFrames.Add(new Rectangle(300, 470, 31, 35));
            shootingWhileRunningFrames.Add(new Rectangle(336, 468, 33, 37));
            AddAnimations(PlayerState.shootingWhileRunning, shootingWhileRunningFrames, TimeSpan.FromMilliseconds(75));

            List<Rectangle> shootingWhileChrouchingFrames = new List<Rectangle>();
            shootingWhileChrouchingFrames.Add(new Rectangle(1, 510, 38, 27));
            shootingWhileChrouchingFrames.Add(new Rectangle(1, 510, 38, 27));
            AddAnimations(PlayerState.shootingWhileCrouching, shootingWhileChrouchingFrames, TimeSpan.FromMilliseconds(2));

            List<Rectangle> doubleJumpFrames = new List<Rectangle>();
            doubleJumpFrames.Add(new Rectangle(1, 383, 32, 38));
            doubleJumpFrames.Add(new Rectangle(38, 381, 37, 40));
            doubleJumpFrames.Add(new Rectangle(80, 357, 41, 64));
            doubleJumpFrames.Add(new Rectangle(126, 348, 49, 73));
            doubleJumpFrames.Add(new Rectangle(181, 352, 49, 69));
            doubleJumpFrames.Add(new Rectangle(235, 359, 50, 62));
            doubleJumpFrames.Add(new Rectangle(290, 359, 51, 62));
            doubleJumpFrames.Add(new Rectangle(346, 386, 32, 35));
            doubleJumpFrames.Add(new Rectangle(383, 386, 32, 35));
            doubleJumpFrames.Add(new Rectangle(420, 385, 32, 36));
            doubleJumpFrames.Add(new Rectangle(457, 386, 32, 35));
            doubleJumpFrames.Add(new Rectangle(494, 382, 32, 39));
            doubleJumpFrames.Add(new Rectangle(531, 374, 27, 47));
            doubleJumpFrames.Add(new Rectangle(563, 375, 27, 46));
            doubleJumpFrames.Add(new Rectangle(595, 374, 26, 47));
            doubleJumpFrames.Add(new Rectangle(626, 375, 27, 46));
            doubleJumpFrames.Add(new Rectangle(658, 375, 27, 46));

            AddAnimations(PlayerState.doubleJumping, doubleJumpFrames, TimeSpan.FromMilliseconds(300));

            ChangeState(PlayerState.idle);
            shootingTime = TimeSpan.Zero;
            this.idleFrames = idleFrames;

            currentAnimation.frames = idleFrames;
        }

        public void Update(GameTime gameTime, Viewport viewport, KeyboardState ks)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);
            }

            //running right
            if (ks.IsKeyDown(Keys.D))
            {
                ChangeState(PlayerState.running);
                runningState = RunningState.Right;
            }

            //running left
            else if (ks.IsKeyDown(Keys.A))
            {
                ChangeState(PlayerState.running);
                runningState = RunningState.Left;
            }

            //jumping
            else if (ks.IsKeyDown(Keys.W))
            {
                jumpCount++;
                ChangeState(PlayerState.jumping);

                isJumping = true;
            }

            //shooting
            else if (ks.IsKeyDown(Keys.Space) && prevKs.IsKeyUp(Keys.Space) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S))
            {
                ChangeState(PlayerState.shooting);
                float speed = 9;

                ifSpace = true;

                if (currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    speed *= -1;
                }

                bullets.Add(new Shot(currentAnimation.texture, currentAnimation.position, currentAnimation.effects, speed));

            }

            //running right
            if (ks.IsKeyDown(Keys.D) && ks.IsKeyDown(Keys.Space) && prevKs.IsKeyUp(Keys.Space))
            {
                float speed = 9;
                ChangeState(PlayerState.shootingWhileRunning);
                if (currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    speed *= -1;
                }
                bullets.Add(new Shot(currentAnimation.texture, currentAnimation.position, currentAnimation.effects, speed));
                ifSpace = true;
            }

            //running left
            if (ks.IsKeyDown(Keys.A) && ks.IsKeyDown(Keys.Space) && prevKs.IsKeyUp(Keys.Space))
            {
                float speed = 9;
                ChangeState(PlayerState.shootingWhileRunning);
                if (currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    speed *= -1;
                }
                bullets.Add(new Shot(currentAnimation.texture, currentAnimation.position, currentAnimation.effects, speed));
                ifSpace = true;
            }

            //shooting
            if (ks.IsKeyDown(Keys.S) && ks.IsKeyDown(Keys.Space) && prevKs.IsKeyUp(Keys.Space))
            {
                float speed = 0;
                if(currentAnimation.effects == SpriteEffects.None)
                {
                    speed = 9;
                }
                if(currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    speed = -9;
                }
                ChangeState(PlayerState.shootingWhileCrouching);
                
                bullets.Add(new Shot(currentAnimation.texture, currentAnimation.position, currentAnimation.effects, speed));
                ifSpace = true;
            }

            //shooting (kinda)
            if (ifSpace)
            {
                shootingTime += TimeSpan.FromMilliseconds(1);
                if (shootingTime >= TimeSpan.FromMilliseconds(10))
                {
                    shootingTime = TimeSpan.Zero;
                    ifSpace = false;
                }
            }

            // crouching
            else if (ks.IsKeyDown(Keys.S))
            {
                ChangeState(PlayerState.crouching);
            }

            //idle checking
            else if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.W) && !isJumping|| currentAnimation.frames == idleFrames)
            {
                ChangeState(PlayerState.idle);

            }

            //crouching (not jumping)
            if (ks.IsKeyDown(Keys.S) && ks.IsKeyDown(Keys.W))
            {
                ChangeState(PlayerState.crouching);
            }

            //crouching
            else if (ks.IsKeyUp(Keys.S) && CurrentState == PlayerState.crouching)
            {
                currentAnimation.position.Y = viewport.Height - (currentAnimation.sourceRectangle.Height) * 3;
            }

            //bullets
            if (bullets.Count >= 1)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].position.X >= vp.Width)
                    {
                        bullets.Remove(bullets[i]);
                    }

                    else if (currentAnimation.effects == SpriteEffects.FlipHorizontally && bullets[i].position.X <= 0)
                    {
                        bullets.Remove(bullets[i]);
                    }

                }
            }

            //double jumping
            if(jumpCount == 1)
            {
                if (prevKs.IsKeyUp(Keys.W) && StateEquals(PlayerState.jumping))
                {
                    if(ks.IsKeyDown(Keys.W))
                    {
                        isDoubleJump = true;
                        ChangeState(PlayerState.doubleJumping);
                        //need to add code for magic
                    }
                    else
                    {
                        jumpCount = 0;
                    }
                }

                else
                {
                    jumpCount = 0;
                }
            }
            base.Update(gameTime, viewport);
            prevKs = ks;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(spriteBatch);

            }

            //if crouched shooting left, draw him offset

            base.Draw(spriteBatch);
        }
    }
}
