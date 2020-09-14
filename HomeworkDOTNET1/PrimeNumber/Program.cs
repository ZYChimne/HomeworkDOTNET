using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int a = int.Parse(input);
            PrimeNumber pn = new PrimeNumber(a);
            pn.displayPrime();
            string stop = Console.ReadLine();
        }
    }

    class PrimeNumber
    {
        int a = 0;
        int cnt = 1;
        int[] al= new int [100];
        public PrimeNumber(int a)
        {
            this.a = a;
            al[0] = 1;
            computePrime();
            al[cnt] = a;
        }

        private void computePrime()
        {
            int temp = a;
            for(int i = 2; i <= temp; i++)
            {
                if (temp % i == 0) al[cnt] = i;
                while (temp % i == 0) temp = temp / i;//Divide the number and store it into an array
                cnt++;
            }
        }

        public void displayPrime()
        {
            for (int i = 0; i < cnt +1 ; i++) Console.Write(al[i] + " ");
        }
    }
}
