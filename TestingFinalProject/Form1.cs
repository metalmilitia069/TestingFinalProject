using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingFinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        Rectangle rect; //= new Rectangle(125, 125, 50, 50);

        Rectangle mousePivot = new Rectangle(MousePosition.X, MousePosition.Y, 10, 10);
        Point rectanglePivot = new Point(0, 0);




        bool isMouseDown = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //rect = new Rectangle(125, 125, 50, 50);
            //rect = new Rectangle(200, 200, 50, 50);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), mousePivot);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePivot.X = e.X;
            mousePivot.Y = e.Y;


            Refresh();
            if (isMouseDown == true)
            {
                if (rect.IntersectsWith(mousePivot))
                {
                    rectanglePivot.X = e.Location.X - (rect.Width / 2);
                    rectanglePivot.Y = e.Location.Y - (rect.Height / 2);

                    rect.Location = rectanglePivot;

                    //if (rect.Right > pictureBox1.Width)
                    //{
                    //    rect.X = pictureBox1.Width - rect.Width;
                    //}
                    //if (rect.Top < 0)
                    //{
                    //    rect.Y = 0;
                    //}
                    //if (rect.Left < 0)
                    //{
                    //    rect.X = 0;
                    //}
                    //if (rect.Bottom > pictureBox1.Height)
                    //{
                    //    rect.Y = pictureBox1.Height - rect.Height;
                    //}
                    //Refresh();   


                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle rect1 = new Rectangle(125, 125, 50, 50);
            
            rect1 = rect;
            Point gravity = new Point(0, 0);
            gravity = rect.Location;
            Point stop = new Point(0, 0);
            stop = rect.Location;
            pictureBox3.Top = pictureBox2.Location.Y + pictureBox2.Height / 2;
            if (rect.IntersectsWith(pictureBox2.Bounds))
            {
                rect.Bottom.Equals((pictureBox2.Top - (pictureBox2.Height / 2)));
                Refresh();
            }
            else
            {
                if (rect.Bottom < pictureBox1.Height)
                {
                    gravity.Y++;
                    rect.Location = gravity;
                    Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rect = new Rectangle(200, 200, 50, 50);
        }
    }
}
