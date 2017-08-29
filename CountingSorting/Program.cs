using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] array = new int[10] { 7, 90, 45, 190, 23, 567, 98, 53, 28, 678 };
        Console.WriteLine("Before sort");
        foreach(int i in array)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine(".........................................................");
        int[] sortedarray = CountingSorting(array);
        Console.WriteLine("After sort");
        foreach (int i in sortedarray)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine(".........................................................");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
    private static int[] CountingSorting(int[] array)
    {
        int[] SortedArray = new int[array.Length];
        int MinVal = array[0];
        int MaxVal = array[0];
        //find min and max values in array
        for (int i=1;i<array.Length;i++)
        {
            if (array[i] < MinVal) MinVal = array[i];
            else if (array[i] > MaxVal) MaxVal = array[i];

        }
        //init the array frequencies
        int[] counts = new int[MaxVal - MinVal + 1];
        //init the frequencies
        for(int i=0;i<array.Length;i++)
        {
            counts[array[i] - MinVal]++;
        }
        //recalculate
        counts[0]--;
        for(int i=1;i< counts.Length;i++)
        {
            counts[i] = counts[i] + counts[i - 1];
        }
        //sort the array
        for(int i=array.Length-1;i>=0;i--)
        {
            SortedArray[counts[array[i] - MinVal]--] = array[i];
        }
        return SortedArray;
    }
}