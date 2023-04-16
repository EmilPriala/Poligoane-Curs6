using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoane_Curs6
{
    public partial class Form1 : Form
    {
        MyGraphics g;
        Polygon[] test;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int size = 1;
            g = new MyGraphics(pictureBox1);
            test = new Polygon[size];
            test[0] = new Polygon(@"..\..\input.txt");
            g.Clear();
            test[0].Draw(g.g);
            for (int i = 1; i < size; i++)
            {
                test[i] = new Polygon(3, g.resX, g.resY);
                test[i].Draw(g.g);
            }

            Matrix test1 = new Matrix(3, 3, 0, 2);
            Matrix test2 = new Matrix(3, 3, 0, 2);
            Matrix test3 = test1 * test2;
            ViewMatrix(test1);
            ViewMatrix(test2);
            ViewMatrix(test3);

            g.Refresh();

        }
        public void ViewMatrix(Matrix matrix)
        {
            foreach (string s in matrix.View())
                listBox1.Items.Add(s);
            listBox1.Items.Add("");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test[0].Perimeter().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointF G = test[0].G();
            g.g.DrawEllipse(Pens.Red, G.X - 2, G.Y - 2, 5, 5);
            g.Refresh();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Polygon X = g.PolygonTranslate(test[0], new Point(200, 100));
            X.Draw(g.g);
            g.Refresh();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Polygon X = g.PolygonScale(test[0], 2, 1);
            X.Draw(g.g);
            g.Refresh();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            for (float r = 0; r < (float)Math.PI * 2; r += 0.1f)
            {
                Polygon X = g.PolygonRotate(test[0], r, test[0].G());
                X.Draw(g.g);
                Polygon Y = g.PolygonRotate(test[0], r, new PointF(300, 300));
                Y.Draw(g.g);
            }
            g.Refresh();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
        
