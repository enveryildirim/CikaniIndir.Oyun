using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CikaniIndir
{
    class Kus:AHedef
    {
        int frameindex;
        float timer, delay = 85;
        Vector2 pozisyon;
        Vector2 velo;
        public override void Load(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            tx_Hedef = cm.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("bird");
            pozisyon = new Vector2(0,150);
        }

        public override void Update(GraphicsDeviceManager gdm)
        {
            throw new NotImplementedException();
        }
        public void UpdateT(GameTime gametime,GraphicsDeviceManager gdm)
        {
            /*timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
           
            if (Rec.X > gdm.PreferredBackBufferWidth - Rec.Width)
            {
                velo.X = -3;
                se = SpriteEffects.FlipHorizontally;
            }

            if (Rec.X < 0)
            {
                velo.X = 3;
                se = SpriteEffects.FlipVertically;
            }

            pozisyon += velo;
            Animasyon();*/
        }
        public void Animasyon()
        {
            if (timer >= delay)
            {
                if (frameindex > 0)
                    frameindex--;
                else frameindex = 3;
                Rec = new Rectangle(frameindex * 66, 0, 66, 74);
                timer = 0;
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
           // sb.Draw(tx_Hedef,pozisyon,Rec,Color.White);
        }
    }
}
