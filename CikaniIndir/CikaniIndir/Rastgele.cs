using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CikaniIndir
{
    public class Rastgele
    {
        public  int X;
        public  int Y;
        public  int Hiz;
        public static Rastgele R(int max)
        {
            Random r = new Random();
            Rastgele ra = new Rastgele();
            ra.X=r.Next(max);
            ra.Y=r.Next(max);
            ra.Hiz = r.Next(1,5);
            return ra;
        }
        
    }
    
}
