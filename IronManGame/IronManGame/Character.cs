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

        protected RunningState runningState;

        Vector2 speed;

        public Character(Vector2 speed)
        {
            animations = new Dictionary<PlayerState, Animation>();
            this.speed = speed;
        }

        public virtual void Update(GameTime gameTime)
        {
            switch (CurrentState)
            {
                case PlayerState.idle:
                    break;
                case PlayerState.running:

                    if (runningState == RunningState.Left)
                    {
                        effects = SpriteEffects.None;
                        animations[CurrentState].position = new Vector2(animations[CurrentState].position.X - speed.X, animations[CurrentState].position.Y);
                        
                    }
                    if (runningState == RunningState.Right)
                    {
                        effects = SpriteEffects.FlipHorizontally;
                        animations[CurrentState].position = new Vector2(animations[CurrentState].position.X + speed.X, animations[CurrentState].position.Y);
                    }
                    break;
            }

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
