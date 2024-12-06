using System.Windows.Markup;

namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Get_Part1_Answer();
            Get_Part2_Answer();
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
                    List<int> valuesList = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    bool isSafe = CheckIfSafe(valuesList);
                    if (isSafe)
                    {
                        safeReportCount++;
                    }

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("Part 1 - Safe Report Count: " + safeReportCount);
        }


        private static void Get_Part2_Answer()
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
                    List<int> valuesList = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    if(CheckIfSafe(valuesList))
                    {
                        safeReportCount++;
                    }
                    else
                    {
                        for (int i = 0; i < valuesList.Count; i++)
                        {
                            List<int> valuesListCopy = valuesList.ToList();
                            valuesListCopy.RemoveAt(i);
                            if(CheckIfSafe(valuesListCopy))
                            {
                                safeReportCount++;
                                break;
                            }
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
            Console.WriteLine("Part 2 - Safe Report Count: " + safeReportCount);
        }
        private static bool CheckIfSafe(List<int> valuesList)
        {
            bool? ascending = null;
            if (valuesList[0] < valuesList[1])
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }

            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                int currentValue = valuesList[i];
                int nextValue = valuesList[i + 1];
                
                if (ascending == true)
                {
                    if (currentValue > nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                    {
                        return false;
                    }
                }
                else
                {
                    if (currentValue < nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}