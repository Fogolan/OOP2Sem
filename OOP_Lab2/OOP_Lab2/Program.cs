using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example.Program.ain(args);
            var anonPentagon = new
            {
                objCount = 0,
                side = 10,
                height = 11,
                area = 250,
                perimetr = 102
            };

            Console.WriteLine(anonPentagon.ToString());

            Console.WriteLine(Pentagon.GetObjCount());

            Pentagon Pentagon1 = new Pentagon();
            Pentagon Pentagon2 = new Pentagon(10);
            Pentagon Pentagon3 = new Pentagon(Pentagon1);
            int resPerimetr;
            Pentagon2.CalculatePerimeter(out resPerimetr);
            Console.WriteLine("Периметр равен = " + resPerimetr);
            Pentagon2.Height = 16;
            double resArea = 0;
            Pentagon2.CalculateSquare(ref resArea);
            Console.WriteLine("Площадь равна = " + resArea);
            Console.WriteLine(Pentagon2.ToString());
            if (Pentagon1.Equals(Pentagon2))
                Console.WriteLine("Объекты равны");
            else
                Console.WriteLine("Объекты не равны");

            if (Pentagon1.Equals(Pentagon1))
                Console.WriteLine("Объекты равны");
            else
                Console.WriteLine("Объекты не равны");

            Console.WriteLine("HashCode = " + Pentagon2.GetHashCode());
            Console.WriteLine("HashCode = " + Pentagon1.GetHashCode());

            Console.WriteLine("Объем равен = " + Pentagon2.GetSinCorner());

            int i = 123;
            object o = i;
            Console.WriteLine(o.ToString());
            o = 123;
            i = (int)o;
            Console.WriteLine(i);
        }
    }
}
