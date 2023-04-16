using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligoane_Curs6
{
    public class Matrix
    {
        public float[,] a;
        public static Random rnd = new Random();
        private void Base(int n, int m)
        {
            a = new float[n, m];

        }

        public Matrix(int n, int m)
        {
            this.Base(n, m);
        }
        public Matrix(int n, PointF A)
        {
            this.a = new float[2, n];
            for (int i = 0; i < n; i++)
            {
                a[0, i] = A.X;
                a[1, i] = A.Y;
            }
        }
        public Matrix(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            List<string> lines = new List<string>();
            string buffer;
            while ((buffer = reader.ReadLine()) != null)
            {
                lines.Add(buffer);
            }
            reader.Close();
            int n = lines.Count;
            int m = lines[0].Split(' ').Length;
            this.Base(n, m);
            for (int i = 0; i < n; i++)
            {
                string[] local = lines[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = int.Parse(local[j]);
                }
            }
        }
        public Polygon MatrixToPolygon()
        {
            Polygon toReturn = new Polygon(a.GetLength(1));
            for (int i = 0; i < a.GetLength(1); i++)
            {
                toReturn.points[i].X = a[0, i];
                toReturn.points[i].Y = a[1, i];
            }
            return toReturn;
        }
        public Matrix(int n)
        {
            this.a = new float[2, n];
        }
        public Matrix(int n, int m, int min, int max)
        {
            a = new float[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(min, max);
                }
            }
        }
        public static Matrix Empty;
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.a.GetLength(0) != B.a.GetLength(0) || A.a.GetLength(1) != B.a.GetLength(1))
                return Empty;
            Matrix toReturn = new Matrix(A.a.GetLength(0), A.a.GetLength(1));
            for (int i = 0; i < A.a.GetLength(0); i++)
            {
                for (int j = 0; j < A.a.GetLength(1); j++)
                {
                    toReturn.a[i, j] = A.a[i, j] + B.a[i, j];
                }
            }
            return toReturn;
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.a.GetLength(0) != B.a.GetLength(0) || A.a.GetLength(1) != B.a.GetLength(1))
                return Empty;
            Matrix toReturn = new Matrix(A.a.GetLength(0), A.a.GetLength(1));
            for (int i = 0; i < A.a.GetLength(0); i++)
            {
                for (int j = 0; j < A.a.GetLength(1); j++)
                {
                    toReturn.a[i, j] = A.a[i, j] - B.a[i, j];
                }
            }
            return toReturn;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            int n = A.a.GetLength(0);
            int m = A.a.GetLength(1);

            if (B.a.GetLength(0) != m)
                return Empty;
            Matrix toReturn = new Matrix(n, B.a.GetLength(1));

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < B.a.GetLength(1); j++)
                {
                    toReturn.a[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        toReturn.a[i, j] += A.a[i, k] * B.a[k, j];
                    }
                }
            }
            return toReturn;
        }
        public List<string> View()
        {
            List<string> toReturn = new List<string>();
            string buffer;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                buffer = "";
                for (int j = 0; j < a.GetLength(1); j++)
                    buffer += a[i, j];
                toReturn.Add(buffer);
            }
            return toReturn;
        }
    }
}