using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_03
{
    abstract class Figure : ICommand
    {
        protected int positionX;
        protected int positionY;
        protected float perimeter;

        public Figure()
        {
            positionX = 0;
            positionY = 0;
            perimeter = 0;
            Console.WriteLine("Вызов конструктора абстрактного класса Figure");
        }

        public int PositionX { get { return positionX; } set { positionX = value; } }
        public int PositionY { get { return positionY; } set { positionY = value; } }
        public float Perimetr { get { return perimeter; } set { perimeter = value; } }
        public abstract void CalculatePerimeter();
        public virtual void WriteToFile() => Console.WriteLine("Вывод в файл (Figure)");
        void ICommand.Click() => Console.WriteLine("Perimeter: {0}", perimeter);
        void ICommand.Move() => Console.WriteLine("PositionX: {0}, PositionY: {1} ", positionX, positionY);
    }
}
