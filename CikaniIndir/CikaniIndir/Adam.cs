using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CikaniIndir
{
    public class Adam:AHedef
    {
        public Adam(int x, int y, int hiz,string ad)
        {
            X = x;
            Y = y;
            Hiz = hiz;
            c_adi = ad;
        }
        string c_adi = "adam";
        public override void Load(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            tx_Hedef = cm.Load<Texture2D>(c_adi);
            int temp=Y/10;
            Rec = new Microsoft.Xna.Framework.Rectangle(X,Y,tx_Hedef.Width+temp,tx_Hedef.Height+temp);
           
        }

        public override void Update(GraphicsDeviceManager gdm)
        {
            if (Rec.X > gdm.PreferredBackBufferWidth - Rec.Width)
            { 
                Hiz = -Hiz;
                se = SpriteEffects.FlipHorizontally;
            }

            if (Rec.X < 0)
            {
                Hiz = Hiz < 0 ? -Hiz : Hiz;
                se = SpriteEffects.FlipVertically;
            }

            Rec.X += Hiz;
        }
        SoundEffect ses;
        public void Ot(ContentManager cm)
        {
            ses = cm.Load<SoundEffect>(c_adi+"ses");
            ses.Play();
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            sb.Draw(tx_Hedef,Rec,Color.White);
        }
    }
    public enum resim 
    {
        abla,dog,gulme,kedi,uyku
    }
}
