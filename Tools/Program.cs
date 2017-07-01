using Commons;
using LeetCode.Book.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExternalMemorySort.GenerateSorted(7);
            //ExternalMemorySort.GenerateShuffleList(7);
            //ExternalMemorySort.MergeSort("ShuffleList.txt", "SortedList.txt", 3);

            //ExternalMemorySort.GenerateSorted(17);
            //ExternalMemorySort.GenerateShuffleList(7);
            //ExternalMemorySort.MergeSort("ShuffleList.txt", "Sorted_List.txt", 2);


            //ExternalMemorySort.GenerateShuffleList();
            //ExternalMemorySort.MergeSort();

            //ExternalMemorySort.SplitAndSortFiles();
            //ExternalMemorySort.ReadWrite();

            try
            {
                OutOfMemory.BurnMemory();
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
