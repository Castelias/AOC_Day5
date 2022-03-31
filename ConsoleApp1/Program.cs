using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\piotr\source\repos\ConsoleApp1\ConsoleApp1\text.txt";
            List<string> inputList = File.ReadAllLines(path).ToList();
            Straights[] straightlines = new Straights[inputList.Count];
            List<int> numberList = new List<int>();
            int size = inputList.Count;
            int[,] arr = new int[990, 990];
            int result = 0;

               for (int i = 0; i < size; i++)
               {
                   List<int> clslist = new List<int>();
                   Regex regx= new Regex(@"[0-9]{2,3}");
                   MatchCollection matches = regx.Matches(inputList[i]);

                   foreach (Match match in matches)
                   {
                       clslist.Add(Convert.ToInt32(match.Value));
                    numberList.Add(Convert.ToInt32(match.Value));
                   }               
                   straightlines[i] = new Straights(clslist[0], clslist[1], clslist[2], clslist[3]);
               }


               int ChangeMatrix(int x1, int y1, int x2, int y2)
               {
                if (x1==x2 || y1==y2)
                {
                    if (x2 >= x1 && y1 == y2)
                    {
                        int num = Math.Abs(x2 - x1);
                        for (int i = x1; i <= x2; i++)
                        {
                            arr[y2, i]++;
                        }
                    }
                    else if (x1 >= x2 && y1 == y2)
                    {
                        int num = Math.Abs(x1 - x2);
                        for (int i = x2; i <= x1; i++)
                        {
                            arr[y2, i]++;
                        }
                    }
                    else if(y1 >= y2 && x1 == x2)
                    {
                        int num = Math.Abs(y1 - y2);
                        for (int i = y2; i <= y1; i++)
                        {                          
                                arr[i, x1]++;                          
                        }
                    }
                    else if (y2 >= y1 && x1 == x2)
                    {
                        int num = Math.Abs(y2 - y1);
                        for (int i = y1; i <= y2; i++)
                        {
                          arr[i, x2]++;
                        }
                    }
                }
                return 0;
               }

             for (int i = 0; i < inputList.Count; i++)
             {
                 ChangeMatrix(straightlines[i].x1, straightlines[i].y1, straightlines[i].x2, straightlines[i].y2);
             }

            for (int i = 0; i < 990; i++)
            {
                for (int j = 0; j < 990; j++)
                {
                    if( arr[i,j] > 1)
                    {
                        result++;
                    }
                }               
            }
            Console.WriteLine(result);
            Console.WriteLine(numberList.Count);
            Console.WriteLine(numberList.Max());





        }   
    }
}

