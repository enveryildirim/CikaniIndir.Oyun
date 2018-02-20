using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CikaniIndir
{
    public  abstract class AHedef
    {
         public int X;
         public int Y;
         public Rectangle Rec;
         public Texture2D tx_Hedef;
         public bool IsOlu = false;
         public int Hiz;
         public SpriteEffects se=SpriteEffects.FlipHorizontally;
         public abstract void Load(ContentManager cm);
         public abstract void Update(GraphicsDeviceManager gdm);
         public abstract void Draw(SpriteBatch sb);
    }
}
