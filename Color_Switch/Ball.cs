using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Color_Switch
{
    class Ball 
    {
        private Color color;
        private SolidBrush brush = new SolidBrush(Color.White);
        private int locx;
        private int locy;

        public Color GetColor()
        {
            return this.color;
        }
        public void SetColor(Color c)
        {
            this.color = c;
            this.brush.Color = c;
        }

        public SolidBrush GetBrush()
        {
            return this.brush;
        }


        public int GetLocx()
        {
                return this.locx;
        }

        public int GetLocy()
        {
                return this.locy;
        }

        public Ball()
        {
            this.color = Color.White;
            this.brush.Color = Color.White;
            this.locx = 300;
            this.locy = 800;
        }

        public void Move(int x,int y)
        {
            this.locx = x;
            this.locy = y;
        }

        public void draw(Graphics g)
        {
            g.DrawEllipse(new Pen(color), locx, locy, 10, 10);
            g.FillEllipse(brush, locx, locy, 10, 10);
        }
        
    }
}
