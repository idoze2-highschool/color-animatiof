using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Color_Switch
{
    class Obstacles
    {
        public Color[] colors = new Color[4];
        private int stangle = 0;
        private int y = 0;
        private int x = 200;
        private int[] rey = new int[2];
        public Color c = new Color();
        private int number = 3;
        

        public Obstacles(Color a , Color b , Color c, Color d , int stan , int locy)
        {
            this.colors[0] = a;
            this.colors[1] = b;
            this.colors[2] = c;
            this.colors[3] = d;
            this.stangle = stan;
            this.y = locy;
        }

        public void Draw(Graphics g)
        {
            g.DrawArc(new Pen(colors[0], 5), x, y,200 , 200, stangle, 90);
            g.DrawArc(new Pen(colors[1], 5),x, y, 200, 200, stangle+90 , 90);
            g.DrawArc(new Pen(colors[2], 5), x , y , 200, 200, stangle + 180, 90);
            g.DrawArc(new Pen(colors[3], 5), x, y, 200, 200, stangle + 270, 90);
            
        }
        public void GetDown()
        {
            this.y++;
        }
        public void deafult()
        {
            this.y = -200;
        }
        public int [] returny()
        {
            this.rey[0] = y + 200;
            this.rey[1] = y;
            return rey;
        }
        public Color getcolorby0()
        {

            int num = number + 2;
            if (num > 3)
            {
                num = num - 4;
            }
            return this.colors[num];
        }
        public Color getcolorby1()
        {
            
            return this.colors[number];
        }
        public void angleup()
        {
            this.stangle--;

            if (stangle ==360)
            {
                stangle = 0;
            }
            if (stangle%90 == 0)
            {
                
                number++;
                if (number>3)
                {
                    number = number - 4;
                }
            }
        }
        
    }
}
