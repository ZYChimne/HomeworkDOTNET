using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] numStr = input.Split(' ');
            int[] arr = new int[numStr.Length];
            for (int i = 0; i < numStr.Length; i++) arr[i] = int.Parse(numStr[i]);
            arrayInfo ai = new arrayInfo(arr);
            ai.displayInfo();
            string stop = Console.ReadLine();
        }
    }

    class arrayInfo
    {
        int[] arr;
        int max, min, sum=0;
        double avg;
        public arrayInfo(int[] arr)
        {
            this.arr = arr;
            /*computeMax();
            computeMin();
            computeAvgAndSum();*/
            computeInfo();
        }
        
        private void computeMax()
        {
            max= arr[0];
            foreach (int a in arr) max = Math.Max(max, a);
        }

        private void computeMin()
        {
            min = arr[0];
            foreach (int a in arr) min = Math.Min(min, a);
        }

        private void computeAvgAndSum()
        {
            foreach (int a in arr) sum += a;
            avg = sum * 1.0 / arr.Length;
        }

        public void displayInfo()
        {
            Console.WriteLine("MAX: " + max);
            Console.WriteLine("MIN: " + min);
            Console.WriteLine("AVG: " + avg);
            Console.WriteLine("SUM: " + sum);
        }

        private void computeInfo()
        {
            max = arr[0];
            min = arr[0];
            foreach (int a in arr)
            {
                max = Math.Max(max, a);
                min = Math.Min(min, a);
                sum += a;
            }
            avg = sum * 1.0 / arr.Length;
        }
    }
}
