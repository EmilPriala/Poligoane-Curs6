using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Poligoane_Curs6
{
    public class MyGraphics
    {
        Bitmap bmp;
        public Graphics g;
        PictureBox display;
        Color bkColor = Color.LightBlue;
        public int resX, resY;


        public MyGraphics(PictureBox display)
        {
            this.display = display;
            resX = display.Width;
            resY = display.Height;
            bmp = new Bitmap(display.Width, display.Height);
            g = Graphics.FromImage(bmp);
        }
        public Polygon PolygonTranslate(Polygon polygon, PointF translation)
        {
            Matrix C = new Matrix(polygon.lenght, translation);
            Matrix P = polygon.PolygonToMatrix();
            Matrix T = P + C;
            return T.MatrixToPolygon();
        }
        public Polygon PolygonScale(Polygon polygon, float fx, float fy)
        {
            Matrix M = new Matrix(2, 2);
            M.a[0, 0] = fx;
            M.a[0, 1] = 0;
            M.a[1, 0] = 0;
            M.a[1, 1] = fy;
            Matrix P = polygon.PolygonToMatrix();
            Matrix S = M * P;
            return S.MatrixToPolygon();
        }
        public Polygon PolygonRotate(Polygon polygon, float angle, PointF center)
        {
            Matrix M = new Matrix(2, 2);
            M.a[0, 0] = (float)Math.Cos(angle);
            M.a[0, 1] = -(float)Math.Sin(angle);
            M.a[1, 0] = (float)Math.Sin(angle);
            M.a[1, 1] = (float)Math.Cos(angle);
            Matrix P = polygon.PolygonToMatrix();
            Matrix C = new Matrix(polygon.lenght, center);
            Matrix R = M * (P - C) + C;
            return R.MatrixToPolygon();
        }
        public void Refresh()
        {
            display.Image = bmp;
        }
        public void Clear()
        {
            g.Clear(bkColor);
        }
    }
}