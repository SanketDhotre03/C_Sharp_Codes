using System;
using System.Collections.Generic;

class Program41
{
    static void Main()
    {
        HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4 };
        HashSet<int> setB = new HashSet<int> { 3, 4, 5, 6 };

        setA.IntersectWith(setB);
        Console.WriteLine("Intersection: " + string.Join(", ", setA));
    }
}
