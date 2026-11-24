using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class GameObject
    {

            public Texture2D Texture;
            public Vector2 Positions;
            public Vector2 Velocity;
            public float Rotation;
            public bool IsAccelerating = false;
            public void Draw(SpriteBatch sb, GameTime gt)
            {
                sb.Draw
                   (Texture,
                    Positions,
                    null,
                    Color.White,
                    Rotation + MathF.PI / 2,
                    new Vector2(Texture.Width / 2, Texture.Height / 2),
                    1,
                    SpriteEffects.None,
                    0);

            }





      
    }
}
