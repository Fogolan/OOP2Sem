using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPLab2_04
{
    class Program
    {
        static void Main()
        {
            
            CollectionType<Pentagon> collection1 = new CollectionType<Pentagon>(10);
            CollectionType<Pentagon> collection2 = new CollectionType<Pentagon>(10);
            CollectionType<Pentagon> collection3 = new CollectionType<Pentagon>(12);
            CollectionType<Pentagon> collection4 = new CollectionType<Pentagon>(15);
            CollectionType<Pentagon> collection5 = new CollectionType<Pentagon>(5);
            List<CollectionType<Pentagon>> list = new List<CollectionType<Pentagon>>
            {
                collection1,
                collection2,
                collection3,
                collection4,
                collection5
            };
            Console.WriteLine(collection1.ToString());
            Console.WriteLine(collection2.ToString());
            collection2.WriteToFile();
            collection2.Sort();

            int collectionCount = 0;
            foreach (var collection in list)
            {
                if (collection.Count() == 10)
                    collectionCount++;
            }
            Console.WriteLine($"Коллекция размером 10 = {collectionCount}");

            int minCollection = Int32.MaxValue;
            CollectionType<Pentagon> minCollectionIndex = new CollectionType<Pentagon>();
            int maxCollection = Int32.MinValue;
            CollectionType<Pentagon> maxCollectionIndex = new CollectionType<Pentagon>();
            foreach (var collection in list)
            {
                if (collection.Min(i => i.Height) < minCollection)
                {
                    minCollection = collection.Min(i => i.Height);
                    minCollectionIndex = collection;
                }

                if (collection.Max(i => i.Height) > maxCollection)
                {
                    maxCollection = collection.Max(i => i.Height);
                    maxCollectionIndex = collection;
                }
                    

            }
            Console.WriteLine($"Минимальная коллекция {minCollectionIndex}\n" +
                              $"Максимальная коллекция {maxCollectionIndex}");


            var linq1 = collection1.Where(i => i.Side < 20).Select(i => i.ToString()).OrderBy(i => i.Length).ToList();
            foreach (var obj in linq1)
                Console.WriteLine(obj);

            var linq2 = list.First().OrderByDescending(i=>i.Side).Any(i => i.Side > 50);
            Console.WriteLine(linq2);

            var linq3 = collection2.Select(i => i.Height).Where(i => i > 1000).Sum();
            Console.WriteLine(linq3);

            var linq4 = collection4.Union(collection5.Where(i => i.Side > 70)).All(i => i != null);
            Console.WriteLine(linq4);

            var linq5 = list.Last().Select(i => i.Height).ToList().SkipWhile(i => i < 100).ToList();
            foreach (var obj in linq5)
                Console.WriteLine(obj.ToString());



            List<string> stringList = new List<string>
            {
                "съешь",
                "этих",
                "мягких",
                "французских",
                "булок",
                "и",
                "выпей",
                "чаю",
                "Ввод"
            };

            foreach (var obj in stringList)
            {
                Console.Write($"{obj}, ");
            }
            Console.WriteLine();

            
            using (StreamWriter sw = new StreamWriter("string.txt"))
            {
                foreach (var obj in stringList)
                {
                    sw.Write($"{obj}, ");
                }
            }

            var findString = stringList.Find(i => i == "Ввод");
            Console.WriteLine(findString);

            int stringCount = stringList.Count(i => i.Length == 4);
            Console.WriteLine(stringCount);

            var asc = stringList.OrderBy(i => i.Length);
            foreach (var str in asc)
                Console.Write($"{str}, ");

            Console.WriteLine();

            var desc = stringList.OrderByDescending(i => i.Length);
            foreach (var str in desc)
                Console.Write($"{str}, ");

            Console.WriteLine();
        }
    }
}
