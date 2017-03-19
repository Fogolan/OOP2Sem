using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_02
{
    internal class Pentagon
    {
        private static int objCount;
        private int side;
        public int Height { get; set; }
        private double square;
        private int perimeter;
        public Pentagon()
        {
            Console.WriteLine("Вызван конструктор без параметров");
        }

        public Pentagon(int side)
        {
            Console.WriteLine("Вызван конструктор c параметрами");
            this.side = side;
        }

        public Pentagon(Pentagon obj)
        {
            Console.WriteLine("Вызван конструктор копирования");
            side = obj.side;
        }

        ~Pentagon()
        {
            Console.WriteLine("Вызван деструктор");
        }

        static Pentagon()
        {
            Console.WriteLine("Вызван статический конструктор");
            objCount = 0;
        }

        public static int GetObjCount() => objCount;

        public int Side
        {
            get { return side; }
            set { side = value; }
        }

        public int Perimeter
        {
            set { perimeter = value; }
        }

        public double Square
        {
            get { return square; }
        }

        public double CalculateSquare(ref double res)
        {
            square = res = (5 / 4) * Math.Pow(side, 2) / Math.Tan(Math.PI / 5);
            return res;
        }

        public int CalculatePerimeter(out int res)
        {
            perimeter = res = side * 5;
            return res;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Pentagon p = obj as Pentagon;
            if (p == null) return false;
            return (square == p.square) && (perimeter == p.perimeter);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Math.Sqrt(Math.PI * perimeter * square));
        }

        public override string ToString()
        {
            return "Площадь: " + square + ", периметр: " + perimeter;
        }
    }
}
