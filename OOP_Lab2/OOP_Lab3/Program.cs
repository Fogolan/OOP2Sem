using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectagle recA = new Rectagle(10, 6);
            recA.CalculatePerimeter();
            Rectagle recB = new Rectagle();
            recB = recA * 9;
            recB.CalculatePerimeter();
            Console.WriteLine(recB.ToString());
            if (recA > recB)
                Console.WriteLine("recA > recB");
            else
                Console.WriteLine("recA < recB");
            recA.WriteToFile();
            Console.WriteLine(recA.GetHashCode());
            if (recA.Equals(recB))
                Console.WriteLine("recA == recB");
            else
                Console.WriteLine("recA != recB");

            Console.WriteLine("recB as Figure = {0}", recB as Figure);
            Console.WriteLine("recB as ICloneable = {0}", recB as ICloneable);
            Console.WriteLine("recB is Figure = {0}", recB is Figure);
            Console.WriteLine("recB as ICloneable = {0}", recB is ICloneable);
        }
    }
}
