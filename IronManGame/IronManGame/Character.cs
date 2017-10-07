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
        Dictionary<PlayerState, Animation> animations;
        SpriteEffects effects;

        public PlayerState CurrentState { get; private set; }

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

        protected RunningState runningState;
        protected JumpingState jumpingState;

        Vector2 speed;
        float gravity = .5f;
        float velocity;
        protected bool isJumping = false;

        public Character(Vector2 speed)
        {
            animations = new Dictionary<PlayerState, Animation>();
            this.speed = speed;
            velocity = speed.Y;
        }

        public virtual void Update(GameTime gameTime, Viewport viewport)
        {
            if (CurrentState == PlayerState.idle)
            {
                animations[PlayerState.idle].effects = animations[PlayerState.running].effects;
            }
            if (CurrentState == PlayerState.running)
            {
                if (runningState == RunningState.Left)
                {
                    animations[CurrentState].effects = SpriteEffects.FlipHorizontally;
                    animations[CurrentState].position = new Vector2(animations[CurrentState].position.X - speed.X, animations[CurrentState].position.Y);

                }
                if (runningState == RunningState.Right)
                {
                    animations[CurrentState].effects = SpriteEffects.None;
                    animations[CurrentState].position = new Vector2(animations[CurrentState].position.X + speed.X, animations[CurrentState].position.Y);
                }
            }
            if (CurrentState == PlayerState.jumping || isJumping == true)
            {
                velocity -= gravity;
                animations[CurrentState].position = new Vector2(animations[CurrentState].position.X, animations[CurrentState].position.Y - velocity);

                if (animations[CurrentState].position.Y > viewport.Height - 120)
                {
                    animations[CurrentState].position.Y = viewport.Height - 120;
                    velocity = speed.Y;
                    ChangeState(PlayerState.jumping);
                    isJumping = false;
                }

                if (jumpingState == JumpingState.InitialJump)
                {
                    
                }
                if (jumpingState == JumpingState.InAir)
                {

                }
                if (jumpingState == JumpingState.Falling)
                {

                }
            }
            //switch (CurrentState)
            //{
            //    case PlayerState.idle:

            //        animations[PlayerState.idle].effects = animations[PlayerState.running].effects;
            //        break;
            //    case PlayerState.running:

            //        if (runningState == RunningState.Left)
            //        {
            //            animations[CurrentState].effects = SpriteEffects.FlipHorizontally;
            //            animations[CurrentState].position = new Vector2(animations[CurrentState].position.X - speed.X, animations[CurrentState].position.Y);

            //        }
            //        if (runningState == RunningState.Right)
            //        {
            //            animations[CurrentState].effects = SpriteEffects.None;
            //            animations[CurrentState].position = new Vector2(animations[CurrentState].position.X + speed.X, animations[CurrentState].position.Y);
            //        }
            //        break;
            //    case PlayerState.jumping:

            //        velocity -= gravity;
            //        animations[CurrentState].position = new Vector2(animations[CurrentState].position.X, animations[CurrentState].position.Y - velocity);

            //        if (animations[CurrentState].position.Y > viewport.Height - 120)
            //        {
            //            velocity = speed.Y;
            //            ChangeState(PlayerState.idle);
            //        }

            //        if (jumpingState == JumpingState.InitialJump)
            //        {

            //        }
            //        if (jumpingState == JumpingState.InAir)
            //        {

            //        }
            //        if (jumpingState == JumpingState.Falling)
            //        {

            //        }
            //        break;
            //}

            animations[CurrentState].origin = new Vector2(animations[CurrentState].sourceRectangle.Width / 2, animations[CurrentState].sourceRectangle.Height / 2);
            animations[CurrentState].Update(gameTime);

            foreach (KeyValuePair<PlayerState, Animation> item in animations)
            {
                item.Value.position = animations[CurrentState].position;
            }
        }

        protected void ChangeState(PlayerState playerState)
        {
            CurrentState = playerState;
        }

        protected void AddAnimations(PlayerState playerState, Animation animation)
        {
            animations.Add(playerState, animation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animations[CurrentState].Draw(spriteBatch);
        }
    }
}
