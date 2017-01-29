using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Switch
{
    public partial class Form1 : Form
    {
        double loc = 0;
        Ball bl = new Ball();
        const double Acceleration = -1.1;
        double V0 = 3.5;
        int Velocity = 0;
        double t = 0;
        int counter = 0;
        int v;
        Timer Movement = new Timer();
        Timer Checker = new Timer();
        Obstacles obs = new Obstacles(Color.Red, Color.Yellow, Color.Blue, Color.Green, 0, 100);
        PictureBox lb = new PictureBox();
        Queue<Obstacles> obstacles = new Queue<Obstacles>();
        Color[] arr = new Color[4] { Color.Red, Color.Yellow, Color.Blue, Color.Green };
        Change c;
        int ang = 0;
        Timer GetD = new Timer();
        Timer Smovement = new Timer();
        int G = 0;
        int getdcounter = 0;
        Button Slow = new Button();
        Button Normal = new Button();
        Queue<obstacle_two_lines> SlowLines;
        int mode = 0;
        Timer SlowDown = new Timer();
        Timer SlowDownChecker = new Timer();
        int countt = 0;
        double velo = -5;

        public Form1()
        {
            Slow.Click += new EventHandler(Slow_Click);
            Normal.Click += new EventHandler(Normal_Click);
            SlowDown.Tick += new EventHandler(SlowDown_Tick);
            SlowDownChecker.Tick += new EventHandler(SlowDownChecker_Tick);
            SlowDownChecker.Interval = 1;

            Slow.Size = new Size(80,40);
            Normal.Size = new Size(80, 40);

            Normal.Location = new Point(300, 400);
            Slow.Location = new Point(400, 400);

            Normal.Text = "Normal Mode";
            Slow.Text = "Slow Mode";

            Normal.BackColor = Color.White;
            Slow.BackColor = Color.White;
            this.Controls.Add(Normal);
            this.Controls.Add(Slow);

            this.Width = 700;
            this.Height = 900;
            SlowDown.Interval = 20 ;


        }

        private void SlowDownChecker_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SlowLines.Count; i++)
            {
                if (SlowLines.Peek().GetAngle()>42 && SlowLines.Peek().GetAngle()<48  && bl.GetColor() != SlowLines.Peek().GetColor())
                {
                     if (bl.GetLocy() < SlowLines.Peek().GetY1()+5 && bl.GetLocy()>SlowLines.Peek().GetY1()-5)
                    {
                        Environment.Exit(0);
                    }
                }
                SlowLines.Enqueue(SlowLines.Dequeue());
                
            }

        }

        private void SlowDown_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SlowLines.Count; i++)
            {
                SlowLines.Peek().Move();
                SlowLines.Enqueue(SlowLines.Dequeue());
            }
            
            Invalidate();

        }

        private void Normal_Click(object sender, EventArgs e)
        {
            mode = 1;
            bl.SetColor(Color.Blue);
            InitializeComponent();
            Movement.Tick += new EventHandler(Movement_Tick);
            Checker.Tick += new EventHandler(Checker_Tick);
            GetD.Tick += new EventHandler(GetD_Tick);
            GetD.Interval = 1;
            Checker.Interval = 1;
            Movement.Interval = 1;
            lb.Size = new Size(50, 50);
            lb.Location = new Point(100, 100);
            this.Controls.Add(lb);
            this.Controls.Add(lb);
            this.Width = 700;
            this.Height = 900;

            c = new Change(arr, bl.GetColor(), 4, 100);

            obstacles.Enqueue(new Obstacles(Color.Red, Color.Yellow, Color.Blue, Color.Green, 0, 200));
            obstacles.Enqueue(new Obstacles(Color.Red, Color.Yellow, Color.Blue, Color.Green, 0, -200));
            this.Controls.Remove(Normal);
            this.Controls.Remove(Slow);
        }

        private void Slow_Click(object sender, EventArgs e)
        {
            mode = 2;
            Smovement.Tick += new EventHandler(Smovement_Tick);
            Smovement.Interval = 1;                     
            SlowLines = new Queue<obstacle_two_lines>();
            SlowLines.Enqueue(new obstacle_two_lines(300,210,Color.Blue));
            SlowLines.Enqueue(new obstacle_two_lines(500, 210, Color.Red));
            SlowDown.Enabled = true;
            SlowDownChecker.Enabled = true;
            bl.SetColor(Color.Blue);
            InitializeComponent();
            this.Width = 700;
            this.Height = 900;
            this.Controls.Remove(Normal);
            this.Controls.Remove(Slow);
        }

        private void Smovement_Tick(object sender, EventArgs e)
        {          
            bl.Move(bl.GetLocx(),bl.GetLocy() + Convert.ToInt32(velo));
            Invalidate();
            Smovement.Interval = 1;
        }

        private void GetD_Tick(object sender, EventArgs e)
        {
            getdcounter++;
            if (bl.GetLocy() <= 400)
            {
                if (getdcounter<G*100)
                {
                    DownQue();
                    c.GetDown();
                }
                else
                {
                    getdcounter = 0; 
                    GetD.Enabled = false;
                }
            }
            
         
        }

        private void Checker_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (bl.GetLocy() > obstacles.Peek().returny()[0] - 10 && bl.GetLocy() < obstacles.Peek().returny()[0] + 10)
                {
                    if (bl.GetColor() != obstacles.Peek().getcolorby0())
                    {
                        Environment.Exit(0);
                    }
                }
                if (bl.GetLocy() > obstacles.Peek().returny()[1] - 10 && bl.GetLocy() < obstacles.Peek().returny()[1] + 10)
                {
                    if (bl.GetColor() != obstacles.Peek().getcolorby1())
                    {
                        Environment.Exit(0);
                    }
                }
                obstacles.Enqueue(obstacles.Dequeue());
            }
            
            lb.BackColor = obstacles.Peek().getcolorby0();

            if (bl.GetLocy()>c.returny()-5 && bl.GetLocy() < c.returny() + 5)
            {
                bl.SetColor(c.randcolor());
                c.setlocy(-100);
            }
        }

        private void Movement_Tick(object sender, EventArgs e)
        {
            counter++;
            t = counter/4;
            G = (800 - bl.GetLocy()) / 5;
           

            if (t>9)
            {
                t = 9;
            }

            loc = -1*(V0*t) + -1 *(0.5*Acceleration* (Math.Pow(t, 2)));           
            Velocity = Convert.ToInt32(V0 + (Acceleration * t));
            int locint = Convert.ToInt32(loc);
            bl.Move(bl.GetLocx(), bl.GetLocy() + locint);



            for (int i = 0; i < obstacles.Count(); i++)
            {
                obstacles.Peek().angleup();
                obstacles.Enqueue(obstacles.Dequeue()); 
            }

            
            this.Refresh();
            Invalidate();

           Velocity = 10;
         
           
            Movement.Interval = Math.Abs(Velocity);
            if (obstacles.Peek().returny()[1]>700)
            {
                Obstacles o = obstacles.Dequeue();
                o.deafult();
                obstacles.Enqueue(o);
            }
        }
        public void DownQue()
        {
            for (int i = 0; i < obstacles.Count(); i++)
            {
                obstacles.Peek().GetDown();
                obstacles.Enqueue(obstacles.Dequeue());
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (mode == 1)
            {
                
                bl.draw(g);
                
                for (int i = 0; i < obstacles.Count(); i++)
                {
                    obstacles.Peek().Draw(g);
                    obstacles.Enqueue(obstacles.Dequeue());
                }
                c.Draw(g);
            }
            if (mode == 2)
            {
                for (int i = 0; i < SlowLines.Count; i++)
                {
                    SlowLines.Peek().Draw(g);
                    SlowLines.Enqueue(SlowLines.Dequeue());
                }
                bl.draw(g);
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (mode == 1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        counter = 0;
                        GetD.Enabled = true;
                        break;
                    case Keys.Enter:
                        Movement.Enabled = true;
                        Checker.Enabled = true;
                        break;

                }
            }
            if (mode == 2)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        Smovement.Enabled = true;
                        break;
                    case Keys.Space:
                        velo = -1;
                        Smovement.Interval = 5;
                        break;
                }
            }
            

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (mode == 2)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        velo = -5;
                        break;
                }
            }
            
                
        }
    }
}
