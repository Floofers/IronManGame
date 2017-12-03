using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class Shot : Animation
    {
        float speed;

        public Shot(Texture2D image, Vector2 position, SpriteEffects effects, float speed) 
            : base(TimeSpan.FromMilliseconds(100), null, image, position, Color.White, new Vector2(3), 0f, effects)
        {
            List<Rectangle> bulletFrames = new List<Rectangle>();
            bulletFrames.Add(new Rectangle(1, 743, 16, 8));
            bulletFrames.Add(new Rectangle(22, 743, 16, 8));

            frames = bulletFrames;
            sourceRectangle = frames[0];

            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            position.X += speed;
            base.Update(gameTime);
        }
    }
}
