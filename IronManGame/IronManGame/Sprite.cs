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
        Texture2D texture;
        Vector2 position;
        Color color;

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
        }
    }
}
