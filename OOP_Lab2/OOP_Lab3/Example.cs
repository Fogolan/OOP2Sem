using System;

namespace OOPLab2_03
{
    class Example
    {
        static void ain()
        {
            //case 11
            Child child = new Child();
            Console.WriteLine(child.ToString());
            //case 2
            var childObj = (object)child;
            Console.WriteLine(childObj);
            Console.Write("Введите имя файла: ");
            child.FileName = Console.ReadLine();
            child.WriteToFile();
        }
    }
    //case 1
    interface INterfaceA
    {
        void Test();
        int GetInt();
        string FileName { get; set; }
    }
    //case 2
    interface INterfaceB
    {
        double Test();
        double GetDouble();
    }
    //case 3
    internal abstract class Parent : INterfaceA, INterfaceB
    {
        #region Properties
        public string FileName { get; set; }
        protected Random Rand { get; private set; }
        #endregion
        #region Constructors
        protected Parent()
        {
            FileName = "unknown.txt";
            Rand = new Random();
        }
        #endregion
        #region Methods
        //case 4
        public virtual double GetDouble()
        {
            return Rand.NextDouble();
        }
        //case 4
        void INterfaceA.Test()
        {
            Console.WriteLine("Class Parent: Реализация метода Test интерфеса A");
        }
        //case 4
        double INterfaceB.Test()
        {
            Console.WriteLine("Class Parent: Реализация метода Test интерфеса B");
            //case 5
            throw new NotImplementedException();
        }
        //case 6
        public abstract int GetInt();
        //case 6
        public abstract void MethodAbstract();
        //case 7
        public virtual void MethodVirtual(string str)
        {
            Console.WriteLine("ParentClass: virtual Method");
        }
        //case 8
        public virtual void WriteToFile()
        {
            System.IO.StreamWriter file = null;
            try
            {
                Console.WriteLine("Write To File: ");
                file = new System.IO.StreamWriter(FileName);
                file.WriteLine("Hello World");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally: отрабатывает в любом случае");
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        #endregion
    }
    internal class Child : Parent
    {
        #region Properties
        public Int64 Number { get; set; }
        #endregion
        #region Constructors
        //case 9
        public Child() : base()
        {
            Number = GetInt();
        }
        #endregion
        #region Methods
        public override int GetInt()
        {
            return Rand.Next(-10, Int16.MaxValue);
        }
        public void MethodVirtual() { }
        //public new Func<string> ToString = () => { return
        //DateTime.Now.ToShortTimeString(); 
        //String Interpolation (C# 6)
        //public override string ToString() => $"{this.FileName} + {this.GetInt()}";
        public override string ToString()
        {
            return string.Format("Filename: {0}, Int: {1}", this.FileName, this.GetInt());
        }
        public override void MethodAbstract()
        {
            //case 5
            throw new NotImplementedException();
        }
        //case 8
        public override void WriteToFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName,
           true))
            {
                file.WriteLine("Child: Hello World");
            }
        }
        //case 13
        public static bool operator >(Child first, Child second)
        {
            return first.Number > second.Number;
        }
        //case 13
        public static bool operator <(Child first, Child second) => first.Number <
       second.Number;
        #endregion
    }
    //case 14
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        static Singleton() { }
        private Singleton() { }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
    //case 15
    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> Lazy = new Lazy<SingletonLazy>(() =>
       new SingletonLazy());
        public static SingletonLazy Instance => Lazy.Value;
        static SingletonLazy() { }
        private SingletonLazy() { }
    }
}