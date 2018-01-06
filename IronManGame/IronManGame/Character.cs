using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    public class Character
    {
        //Dictionary<PlayerState, Animation> animations;

        Dictionary<PlayerState, KeyValuePair<List<Rectangle>, TimeSpan>> animations;

        protected Animation currentAnimation;

        protected enum RunningState
        {
            Left,
            Right
        }

        protected enum JumpingState
        {
            InitialJump,
            InAir,
            Falling
        }
        public PlayerState CurrentState;
        protected RunningState runningState;
        protected JumpingState jumpingState;

        Vector2 speed;
        Vector2 bulletPosition;
        int bulletSpeed = 3;
        float gravity = .5f;
        float velocity;
        protected bool isJumping = false;

        public Character(Vector2 speed)
        {
            animations = new Dictionary<PlayerState, KeyValuePair<List<Rectangle>, TimeSpan>>();
            currentAnimation = null;

            this.speed = speed;
            velocity = speed.Y;
        }

        public virtual void Update(GameTime gameTime, Viewport viewport)
        {
            if (StateEquals(PlayerState.idle))
            {
                currentAnimation.position.Y = viewport.Height - (currentAnimation.sourceRectangle.Height + 80);
                isJumping = false;
            }

            if (StateEquals(PlayerState.running))
            {
                if (runningState == RunningState.Left)
                {
                    currentAnimation.effects = SpriteEffects.FlipHorizontally;
                    currentAnimation.position = new Vector2(currentAnimation.position.X - speed.X, currentAnimation.position.Y);
                    //currentAnimation.position.X++;
                }
                if (runningState == RunningState.Right)
                {
                    currentAnimation.effects = SpriteEffects.None;
                    currentAnimation.position = new Vector2(currentAnimation.position.X + speed.X, currentAnimation.position.Y);
                }
            }

            if (StateEquals(PlayerState.jumping) || isJumping)
            {
                velocity -= gravity;
                currentAnimation.position = new Vector2(currentAnimation.position.X, currentAnimation.position.Y - velocity);
                if (currentAnimation.position.Y > viewport.Height - 120)
                {
                    currentAnimation.position.Y = viewport.Height - 120;
                    velocity = speed.Y;
                    ChangeState(PlayerState.idle);
                }
            }

            if (StateEquals(PlayerState.shooting))
            {
                bulletPosition.X -= bulletSpeed;
            }

            if (StateEquals(PlayerState.crouching))
            {
                currentAnimation.position.Y = viewport.Height - (currentAnimation.sourceRectangle.Height) * 3;
            }
            currentAnimation.Update(gameTime);

            if (StateEquals(PlayerState.shootingWhileRunning))
            {
                bulletPosition.X -= bulletSpeed;
                if (currentAnimation.effects == SpriteEffects.None)
                {
                    currentAnimation.position = new Vector2(currentAnimation.position.X + speed.X, currentAnimation.position.Y);
                }
                if (currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    currentAnimation.position = new Vector2(currentAnimation.position.X - speed.X, currentAnimation.position.Y);
                }
            }
            if (StateEquals(PlayerState.shootingWhileCrouching))
            {
                bulletPosition.X -= bulletSpeed;
                if (currentAnimation.effects == SpriteEffects.None)
                {
                    bulletPosition.X += bulletSpeed;
                }
                if (currentAnimation.effects == SpriteEffects.FlipHorizontally)
                {
                    bulletPosition.X -= bulletSpeed;
                }
            }
        }

        protected void ChangeState(PlayerState playerState)
        {
            if (!StateEquals(playerState))
            {
                currentAnimation.frames = animations[playerState].Key;
                currentAnimation.goalTime = animations[playerState].Value;
                currentAnimation.currentFrame = 0;
                CurrentState = playerState;
            }
        }

        protected bool StateEquals(PlayerState playerState)
        {
            return playerState == CurrentState;
        }

        protected void AddAnimations(PlayerState playerState, List<Rectangle> frames, TimeSpan animationTime)
        {
            animations.Add(playerState, new KeyValuePair<List<Rectangle>, TimeSpan>(frames, animationTime));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }
    }
}
