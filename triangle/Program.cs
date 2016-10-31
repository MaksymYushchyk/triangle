using System;
using System.IO;
using static System.Math;

namespace triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] testStr = File.ReadAllLines("triangle_test.txt");
            string [] simpleTriange = File.ReadAllLines("simple_triangle.txt");
            string [] bigTriangle = File.ReadAllLines("big_triangle.txt");
            Console.WriteLine($"Test Triangle: {MaxSum(testStr)}");
            Console.WriteLine($"Simple Triangle: {MaxSum(simpleTriange)}");
            Console.WriteLine($"Big Triangle: {MaxSum(bigTriangle)}");
            Console.ReadKey();
        }

        private static int MaxSum(string[] str)
        {
            //DateTime start = DateTime.Now;
            int[][] triangle = new int[str.Length][];
            string[] bufferSrting;
            int[] bufferInt;
            for (int i = 0; i < str.Length; i++)
            {
                bufferSrting = str[i].Split(' ');
                bufferInt = new int[bufferSrting.Length];
                for (int j = 0; j < bufferSrting.Length; j++)
                {
                    bufferInt[j] = int.Parse(bufferSrting[j]);
                }
                triangle[i] = bufferInt;
            }
            int max = 0;
            for (int i = triangle.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    max = Max(triangle[i + 1][j + 1], triangle[i + 1][j]);
                    if (j >= 1)
                    {
                        max = Max(max, triangle[i + 1][j - 1]);
                    }
                    triangle[i][j] += max;
                }
            }
            //TimeSpan duration = DateTime.Now - start;
            //Console.WriteLine($"duration {duration.Milliseconds}ms");
            return triangle[0][0];
        }
    }
}
