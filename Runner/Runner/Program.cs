
using System;
using DataStructures;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfIntegers = new LinkedList<int> {0, 1, 2, 3, 4, 5, 6, 7};
            listOfIntegers.Remove(2);

            foreach (var entry in listOfIntegers)
            {
                Console.WriteLine(entry);
            }

            var hashMap = new HashMap<String, Int32>();
            hashMap.Put("mike", 4);
            hashMap.Put("chris", 7);

            Console.WriteLine("KEY: 'mike'\t VALUE:{0}", hashMap.GetValue("mike"));

            foreach (var keyValuePair in hashMap)
            {
                Console.WriteLine(keyValuePair);
            }

            var tree = new Tree<int> {4, 6, 9, 2};

            foreach (var value in tree)
            {
                Console.Write("{0}\t", value);
            }

            Console.Read();
        }
    }
}
