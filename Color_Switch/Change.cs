using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Color_Switch
{
    class Change
    {
        private Random r = new Random();
        private Color[] c;
        private Color lastcolor = new Color();
        private int locy = 0;
        
        

        public Change(Color[] arr , Color n , int num , int y)
        {
            this.c = new Color[num];
            this.c = arr;
            this.locy = y;
            this.lastcolor = n;
        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < this.c.Length; i++)
            {
                g.DrawArc(new Pen(c[i], 10), 300, locy, 10, 10, i*90, 90);
            }
            
        }
        public void GetDown()
        {
            this.locy++;
        }
        public int returny()
        {
            return this.locy;
        }
        public Color randcolor()
        {
           
            Color co = this.c[r.Next(0, this.c.Length)];

            while (co == lastcolor)
            {
                co = this.c[r.Next(0, this.c.Length)];
            }

            this.lastcolor = co;
            return co;
            
        }
        public void setlocy(int y)
        {
            this.locy = y;
        }

        
    }
}
