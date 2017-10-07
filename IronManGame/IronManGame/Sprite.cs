using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Color color;
        public  Rectangle sourceRectangle;
        public Vector2 origin;
        Vector2 scale;
        float rotation;
        public SpriteEffects effects;

        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation, SpriteEffects effects)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
            this.scale = scale;
            this.rotation = rotation;
            this.effects = effects;

            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, 0);
        }
    }
}
