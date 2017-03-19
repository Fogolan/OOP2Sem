using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab2_03
{
    class Rectagle : Figure
    {
        private float a;
        private float b;

        public Rectagle() { }
        public Rectagle(float a, float b)
        {
            A = a;
            B = b;
        }
        public float A { get { return a; } set { a = value; } }
        public float B { get { return b; } set { b = value; } }

        public override void CalculatePerimeter() => perimeter = 2 * A + 2 * B;
        public override void WriteToFile()
        {
            StreamWriter sw = null;
            try
            {
                Console.WriteLine("Сохраниение в файл...");
                sw = new StreamWriter("OOPLab_03.txt");
                sw.WriteLine("A = {0}; B = {1};", A, B);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
        public override string ToString() => "A = " + A + " B = " + B;
        public override int GetHashCode() => Convert.ToInt32(Math.PI * A * B);
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var rec = obj as Rectagle;
            if (obj == null) return false;
            return A == rec.A && B == rec.B;
        }
        public static Rectagle operator +(Rectagle recA, Rectagle recB)
        {
            Rectagle res = new Rectagle();
            res.A = recA.A + recB.A;
            res.B = recA.B + recA.B;
            return res;
        }
        public static Rectagle operator *(Rectagle recA, int num)
        {
            Rectagle res = new Rectagle();
            res.A = recA.A * num;
            res.B = recA.B * num;
            return res;
        }
        public static bool operator <(Rectagle recA, Rectagle recB) => recA.perimeter < recB.perimeter;
        public static bool operator >(Rectagle recA, Rectagle recB) => recA.perimeter > recB.perimeter;
    }
}
