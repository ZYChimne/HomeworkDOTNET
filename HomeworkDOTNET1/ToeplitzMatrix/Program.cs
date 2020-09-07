using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ToeplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 0, length=0;
            int[][] arr = new int[100][];
            Console.WriteLine("Type a matrix, and use EOI to mark the end.");
            for(int i = 0; i < 100; i++)
            {
                string str = Console.ReadLine();
                if (str == "EOI") break;
                else
                {
                    string[] strArr = str.Split(' ');
                    int[] tempArr = new int[strArr.Length];
                    for (int j = 0; j < strArr.Length; j++)
                        tempArr[j] = int.Parse(strArr[j]);
                    arr[height] = tempArr;
                    height++;
                    length = strArr.Length;
                }
            }
            ToeplitzMatrix tm = new ToeplitzMatrix(arr, height, length);
            Console.WriteLine(tm.getState());
            string stop = Console.ReadLine();
        }
    }

    class ToeplitzMatrix
    {
        private int[][] arr;
        private int height = 0, length = 0;
        private bool isToeplitzMatrix=false;
        public ToeplitzMatrix(int[][] arr, int height, int length)
        {
            this.arr = arr;
            this.height = height;
            this.length = length;
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Height: " + height);
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.Write("\n");
            }
            computeIsToeplitzMatrix();
        }
        private void computeIsToeplitzMatrix()
        {
            for(int i = 1; i < height; i++)
            {
                for(int j = 1; j < length; j++)
                {
                    if (arr[i][j] != arr[i - 1][j - 1]) return;
                }
            }
            isToeplitzMatrix = true;
        }
        public bool getState()
        {
            return isToeplitzMatrix;
        }
    }
}
