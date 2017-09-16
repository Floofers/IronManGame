using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Color color;
        protected Rectangle sourceRetangle;
        Vector2 origin;
        Vector2 scale;

        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
            this.scale = scale;

            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            sourceRetangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Draw()
    }
}
