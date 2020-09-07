using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EratoSternMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            EratoSternMethod esm = new EratoSternMethod();
            esm.displayPrime();
            string stop = Console.ReadLine();
        }
    }

    class EratoSternMethod
    {
        int[] arr = new int[100];
        public EratoSternMethod()
        {
            for (int i = 1; i < 101; i++) arr[i - 1] = i;
            this.computePrime();
        }

        private void computePrime()
        {
            for(int i = 2; i < 100; i++)
            {
                for(int j = i; j < 100; j++)
                {
                    if ((arr[j]!=0)&&(arr[j] % i == 0)) arr[j] = 0;

                }
            }
        }

        public void displayPrime()
        {
            foreach (int a in arr)
                if (a != 0)
                    Console.Write(a + " ");
        }
    }
}
