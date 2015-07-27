
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

            Console.Read();
        }
    }
}
