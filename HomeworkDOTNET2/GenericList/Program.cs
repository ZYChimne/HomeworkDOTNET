using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            GenericList<int> gl = new GenericList<int>();
            for (int i = 0; i < 5; i++)
                gl.Add(array[i]);
            int sum = 0, maxValue = gl.Head.Value, minValue = gl.Head.Value;
            //Action<int> computeSum = x => { sum += x; };
            //Action<int> computeMax = x => { maxValue = Math.Max(maxValue, x); };
            //Action<int> computeMin = x => { minValue = Math.Min(minValue, x); };
            gl.ForEach(x =>
            {
                Console.Write(x + " ");
                sum += x;
                maxValue = Math.Max(maxValue, x);
                minValue = Math.Min(minValue, x);
            });
            Console.WriteLine(" Sum: " + sum + " Max: " + maxValue + " Min: " + minValue);
            string stop = Console.ReadLine();
        }
    }
    
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public Node(T t)
        {
            Value = t;
            Next = null;
        }
    }

    class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = tail = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next= n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            for (Node<T> it = head; it != null; it = it.Next)
            {
                action(it.Value);
            }
                
        }
    }
}
