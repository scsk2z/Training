using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int ARRAY_LEN = 100000;
        static void Main(string[] args)
        {
            MySort mySort = new MySort();
            int[] testArray = new int[ARRAY_LEN];
            Random rd = new Random();
            for (int i = 0; i < ARRAY_LEN; i++)
                testArray[i] = rd.Next(0, ARRAY_LEN);

            //mySort.MergeSort (testArray);

            Console.WriteLine( mySort.IsSorted(testArray));
        }
    }
    class MySort
    {
        public bool IsSorted(int[] num)
        {
           //TODO
            return true;
        }
        public void Swap(int[] num, int a, int b)
        {
            //TODO
        }
        public void InsertSort(int[] num)
        {
            var len = num.Length;
            //TODO
        }
        public void BubbleSort(int[] num)
        {
            var len = num.Length;
            //TODO
        }
        public void SelectionSort(int[] num)
        {
            var len = num.Length;
            f//TODO
        }
        public void QuickSort(int[] num)
        {
            var len = num.Length;
            QuickSortHelper(num, 0, len-1);
        }

        private void QuickSortHelper(int[] num, int start, int end)
        {
            //TODO
        }

        public void MergeSort(int[] num)
        {
            var len = num.Length;
            MergeSortHelper(num, 0, len);
        }

        private void MergeSortHelper(int[] num, int start, int end)
        {
            //TODO
        }
    }
}
