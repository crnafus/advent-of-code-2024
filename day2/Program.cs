﻿using System.Windows.Markup;

namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Get_Part1_Answer();
        }

        private static void Get_Part1_Answer()
        {
            //TODO: Figure out how to read filepath from appsettings.json
            string filePath = "C:\\Users\\Dev\\Desktop\\aoc_day2_inputs.txt";
            string? line;
            int safeReportCount = 0;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    string[] values = line.Split(' ');
                    bool? ascending = null;
                    if (Int32.Parse(values[1]) > Int32.Parse(values[0]))
                    {
                        ascending = true;
                    }
                    else
                    {
                        ascending = false;
                    }

                    for (int i = 0; i < values.Length - 1; i++)
                    {
                        int currentValue = Int32.Parse(values[i]);
                        int nextValue = Int32.Parse(values[i + 1]);
                        if (ascending == true)
                        {
                            if (currentValue > nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (currentValue < nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                            {
                                break;
                            }
                        }
                        //we got to the end without meeting a failing condition, so report is safe and we increment the counter.
                        if(i == values.Length - 2)
                        {
                            safeReportCount++;
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.Write("Safe Report Count: " +  safeReportCount);
        }
    }
}