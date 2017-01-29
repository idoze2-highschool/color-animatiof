using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Color_Switch
{
    class obstacle_two_lines
    {
        private int Locy1;
        private int Locx1;
        private int Locy2;
        private int Locx2;

        private int Locy3;
        private int Locx3;
        private int Locy4;
        private int Locx4;

        private int angle = 0;
        private Color c;
        
        public obstacle_two_lines(int locy , int locx, Color c)
        {
            this.Locy1 = locy;
            this.Locx1 = locx;
            this.Locy2 = Locy1-180;
            this.Locx2 = Locx1;

            this.Locx3 = Locx1 + 180;
            this.Locy3 = Locy1;
            this.Locx4 = Locx2 + 180;
            this.Locy4 = Locy2;
      
            
            
            this.c = c;
            
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(c, 6), Locx1, Locy1, Locx2, Locy2);
            g.DrawLine(new Pen(c, 6), Locx3, Locy3, Locx4, Locy4);

        }
        public void Move()
        {
            angle++;
            if (angle<46)
            {
                Locx1-=2;
                Locx2+=2;
                Locy1-=2;
                Locy2+=2;

                Locx3 += 2;
                Locx4 -= 2;
                Locy3 -= 2;
                Locy4 += 2;

            } 
            if (angle<91 && angle>45)
            {
                Locx1+=2;
                Locx2-=2;
                Locy1-=2;
                Locy2+=2;

                Locx3 -= 2;
                Locx4 += 2;
                Locy3 -= 2;
                Locy4 += 2;
            }
            if (angle == 90)
            {
                angle = 0;
                int temp = Locy1;
                Locy1 = Locy2;
                Locy2 = temp;

                int temp2 = Locy3;
                Locy3 = Locy4;
                Locy4 = temp2;
                
            }
            
        }
        public  int GetAngle()
        {
            return this.angle;
        }
        public int GetY1()
        {
            return this.Locy1;
        }
        public Color GetColor()
        {
            return this.c;
        }
    }
}
