using System;
namespace Example
{
    internal class Program
    {
        public static void ain(string[] args)
        {
            //case 1
            //Example.MethodStatic(1);
            //case 2
            //Example example = new Example();
            //example.ToString();
            //case 3
            //Example.StaticField = 10;
            //case 4
            //Object obj = new Example();
            //Console.WriteLine(obj.GetType());
            //Object i32 = new Int32();
            //Console.WriteLine(i32.GetType());
            //i32 = 4;
            //int i = 4;
            //Console.WriteLine((i == (int)i32).ToString());
            //case 5
            //var ex1 = new Example();
            //ex1.Property4 = 10;
            //var ex2 = new Example();
            //ex1.Property4 = 10;
            //Console.WriteLine(ex1.Equals(ex2));
            //Console.WriteLine(ex1.GetHashCode());
            //case 6
            //int x = 100;
            //Object oX = x;
            //int y = (int)oX;
        }
    }
    internal class Example
    {
        private static Random _rand;
        public readonly string ReadOnlyStr;
        public const string ConstStr = "CONST STRING";
        #region Properties
        public static int StaticProperty { get; set; }
        public Int32 Property1 { get; set; }
        public string Property2 { get; }
        public double Property3 { get; private set; }
        private int property4;
        public int Property4
        {
            get { return this.property4; }
            set { this.property4 = value; }
        }
        public int Property5 { private get; set; }
        #endregion
        #region Constructors
        static Example()
        {
            Console.WriteLine("Статический констуктор");
            StaticProperty = 10;
            _rand = new Random();
        }
        public Example()
        {
            Console.WriteLine("Констурктор без параметров");
            ReadOnlyStr = "BSTU";
            Property2 = "Hello World";
            Property4 = Int32.MaxValue;
        }
        public Example(string str) : this()
        {
            Console.WriteLine("Конструктор с параметром");
            Property2 = str;
        }
        public Example(Example example)
        {
            Console.WriteLine("Конструктор копирования");
            Property1 = example.Property1;
            Property2 = example.Property2;
        }
        #endregion
        #region Methods
        public static int MethodStatic(int x)
        {
            Console.WriteLine("Статический метод");
            return x * StaticProperty;
        }
        public int MethodRef(ref int val)
        {
            Console.WriteLine("Передача параметров по ссылке: ref");
            val *= StaticProperty + _rand.Next(-100, 100);
            return val - _rand.Next();
        }
        public void MethodOut(out string str)
        {
            Console.WriteLine("Передача параметров по ссылке: out");
            str = _rand.Next().ToString();
        }
        public override String ToString()
        {
            return String.Format("({0}, {1}, {2}, {3})", Property1, Property2, Property3,
           Property4, StaticProperty);
        }
        //case4-case5
        //public override bool Equals(object obj)
        //{
        // if (obj == null || obj.GetType() != this.GetType()) return false;
        // var ex = (Example)obj;
        // return (Property1 == ex.Property1) && (Property2 == ex.Property2);
        //}
        //case4-case5
        //public override int GetHashCode()
        //{
        // return Property4 ^ Property1 | StaticProperty;
        //}
        #endregion
    }
    internal static class ExampleExt
    {
        public static int MethodExt(this Example ex, int x)
        {
            return ex.Property1 + ex.Property4 + x;
        }
    }
}