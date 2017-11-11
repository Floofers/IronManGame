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
        Texture2D image;
        Vector2 position;
        Color tint;
        Vector2 scale;
        float rotation;
        SpriteEffects effects;
        Character character;

        List<Rectangle> bulletFrames = new List<Rectangle>();
        //bulletFrames.Add(new Rectangle(1, 743, 16, 8));
        //bulletFrames.Add(new Rectangle(22, 743, 16, 8));


        public Shot( List<Rectangle>bulletFrames, Texture2D image, Vector2 position, SpriteEffects effects) 
            : base(TimeSpan.FromMilliseconds(75), bulletFrames, image, position, Color.White, new Vector2(3, 3), 0, effects)
        {
    
            this.bulletFrames = new List<Rectangle>();
            this.image = image;
            this.position = position;
            this.effects = effects;
        }

        public void Move()
        {
            position.X += 5;
        }        
    }
}
