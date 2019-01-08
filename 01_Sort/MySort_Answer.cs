using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int ARRAY_LEN = 50000;
        static void Main(string[] args)
        {
            MySort mySort = new MySort();
            int[] testArray = new int[ARRAY_LEN];
            Random rd = new Random();
            for (int i = 0; i < ARRAY_LEN; i++)
                testArray[i] = rd.Next(0, ARRAY_LEN);

            int[] tempArray = new int[ARRAY_LEN];

            //InsertSort
            testArray.CopyTo(tempArray, 0);
            DateTime beginTime = System.DateTime.Now;
            mySort.InsertSort (tempArray);
            DateTime endTime = System.DateTime.Now;
            TimeSpan ts = endTime.Subtract(beginTime);
            Console.WriteLine("InsertSort:");
            Console.WriteLine(ts.Milliseconds);
            Console.WriteLine(mySort.IsSorted(tempArray));

            //BubbleSort
            testArray.CopyTo(tempArray, 0);
            beginTime = System.DateTime.Now;
            mySort.BubbleSort(tempArray);
            endTime = System.DateTime.Now;
            ts = endTime.Subtract(beginTime);
            Console.WriteLine("BubbleSort:");
            Console.WriteLine(ts.Milliseconds);
            Console.WriteLine(mySort.IsSorted(tempArray));

            //SelectionSort
            testArray.CopyTo(tempArray, 0);
            beginTime = System.DateTime.Now;
            mySort.SelectionSort(tempArray);
            endTime = System.DateTime.Now;
            ts = endTime.Subtract(beginTime);
            Console.WriteLine("SelectionSort:");
            Console.WriteLine(ts.Milliseconds);
            Console.WriteLine(mySort.IsSorted(tempArray));

            //QuickSort
            testArray.CopyTo(tempArray, 0);
            beginTime = System.DateTime.Now;
            mySort.QuickSort(tempArray);
            endTime = System.DateTime.Now;
            ts = endTime.Subtract(beginTime);
            Console.WriteLine("QuickSort:");
            Console.WriteLine(ts.Milliseconds);
            Console.WriteLine(mySort.IsSorted(tempArray));

            //MergeSort
            testArray.CopyTo(tempArray, 0);
            beginTime = System.DateTime.Now;
            mySort.MergeSort(tempArray);
            endTime = System.DateTime.Now;
            ts = endTime.Subtract(beginTime);
            Console.WriteLine("MergeSort:");
            Console.WriteLine(ts.Milliseconds);
            Console.WriteLine(mySort.IsSorted(tempArray));




            //Console.WriteLine( mySort.IsSorted(testArray));
        }
    }
    class MySort
    {
        public bool IsSorted(int[] num)
        {
            var len = num.Length;
            if (len < 2) return true;
            for (int i = 0; i < len - 1; i++)
                if (num[i] > num[i + 1]) return false;
            return true;
        }
        public void Swap(int[] num, int a, int b)
        {
            int temp = num[a];
            num[a] = num[b];
            num[b] = temp;
        }
        public void InsertSort(int[] num)
        {
            var len = num.Length;
            for(int i = 1; i < len; i++)
            {
                var preIndex = i - 1;
                var temp = num[i];
                while(preIndex >= 0 && num[preIndex] > temp)
                {
                    num[preIndex + 1] = num[preIndex];
                    preIndex--;
                }
                num[preIndex + 1] = temp;
            }
        }
        public void BubbleSort(int[] num)
        {
            var len = num.Length;
            for(int i = 0; i < len-1; i++)
                for(int j = 0; j < len - i - 1; j++)
                {
                    if(num[j] > num[j + 1])
                    {
                        Swap(num, j, j + 1);
                    }
                }
        }
        public void SelectionSort(int[] num)
        {
            var len = num.Length;
            for(int i = 0; i < len-1; i++)
            {
                int index = i;
                for (int j = i + 1; j < len; j++)
                    if (num[j] < num[index])
                        index = j;
                if(index != i)
                {
                    Swap(num, index, i);
                }
            }
        }
        public void QuickSort(int[] num)
        {
            var len = num.Length;
            QuickSortHelper(num, 0, len-1);
        }

        private void QuickSortHelper(int[] num, int start, int end)
        {
            if (start >= end) return;
            int left = start;
            int right = end;
            int pivot = num[start];
            while(left < right)
            {                
                while(num[right] >= pivot && left < right)
                {
                    right--;                
                }
                while (num[left] <= pivot && left < right)
                {
                    left++;                   
                }
                if(left < right) Swap(num, left, right);
            }
            Swap(num, start, left);
            QuickSortHelper(num, start, left - 1);
            QuickSortHelper(num, left + 1, end);
        }

        public void MergeSort(int[] num)
        {
            var len = num.Length;
            MergeSortHelper(num, 0, len);
        }

        private void MergeSortHelper(int[] num, int start, int end)
        {
            if (start >= end - 1) return;
            int middle = (start + end) / 2;
            MergeSortHelper(num, start, middle);
            MergeSortHelper(num, middle, end);
            List<int> merge = new List<int>();
            int left_begin = start;
            int left_end = middle;
            int right_begin = middle;
            int right_end = end;
            while(left_begin < left_end && right_begin < right_end)
            {
                if (num[left_begin] < num[right_begin])
                    merge.Add(num[left_begin++]);
                else
                    merge.Add(num[right_begin++]);
            }
            while (left_begin < left_end)
                merge.Add(num[left_begin++]);
            while (right_begin < right_end)
                merge.Add(num[right_begin++]);
            for (int i = start; i < end; i++)
                num[i] = merge[i - start];
            //throw new NotImplementedException();
        }
    }
}
