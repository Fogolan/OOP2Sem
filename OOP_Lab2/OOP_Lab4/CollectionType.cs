using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OOPLab2_04
{
    class CollectionType<T> : IEnumerable<T> where T : Pentagon
    {
        private LinkedList<T> collectionList;
        private LinkedListNode<T> listNode;
        private static readonly Random Rnd;
        public static int objCount;

        static CollectionType()
        {
            Rnd = new Random();
            objCount = 0;
        }
        public CollectionType()
        {
            collectionList = new LinkedList<T>();
            objCount++;
            CollectionNum = objCount;
        }
        public CollectionType(int count)
        {
            collectionList = new LinkedList<T>();
            objCount++;
            CollectionNum = objCount;
            for (int i = 0; i < count; i++)
                collectionList.AddLast((T) new Pentagon(Rnd.Next(1, 100)));
        }
        ~CollectionType()
        {
            objCount--;
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i > collectionList.Count)
                    throw new IndexOutOfRangeException();
                listNode = collectionList.First;
                for (int ii = 0; ii < i; ii++)
                {
                    listNode = listNode.Next;
                }
                return listNode.Value;
            }
            set
            {
                if (i < 0 || i > collectionList.Count)
                    throw new IndexOutOfRangeException();
                for (int ii = 0; ii < i; ii++)
                {
                    listNode = listNode.Next;
                }
                listNode.Value = value;
            }
        }
        public LinkedList<T> CollectionList { get { return collectionList; } set { collectionList = value; } }
        public int CollectionNum { get; }
        public int ObjCount => objCount;

        public void AddLast(T obj)
        {
            collectionList.AddLast(obj);
        }
        public T Remove(T obj)
        {
            var element = collectionList.FirstOrDefault(i => Equals(i, obj));
            if (element != null)
            {
                collectionList.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }
        public void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter($"out{CollectionNum}.txt"))
            {
                sw.WriteLine(ToString());
            }
        }
        public void Sort()
        {
            collectionList = new LinkedList<T>(collectionList.OrderBy(i => i.Side));
            Console.WriteLine("Коллекция после сортировки ");
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string res = $"\nКоллекция №{CollectionNum}\n";
            for (int i = 0; i < collectionList.Count; i++)
                res += $"{i}. {this[i]}\n";
            return res;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return collectionList.GetEnumerator();
        }
    }
}
