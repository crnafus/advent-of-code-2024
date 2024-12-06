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
            Console.WriteLine("Part 1 - Safe Report Count: " +  safeReportCount);
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
                    string[] values = line.Split(' ');
                    List<string> valuesList = new List<string>(values);
                    bool continueChecks = true;

                    bool hasMultipleDirectionChanges = HasMultipleDirectionChanges(valuesList);


                    //If the ascend/descend changes more than once, that means at least two numbers would have to be removed for it to be safe.
                    if (hasMultipleDirectionChanges)
                    {
                        continueChecks = false;
                    }

                    if (continueChecks)
                    {
                        bool hasOneDirectionChange = CheckForOneDirectionChange(valuesList);
                        if (hasOneDirectionChange)
                        {
                            GetDirectionChangeIndex(valuesList);
                            int directionChangeIndex = GetDirectionChangeIndex(valuesList);
                            if (directionChangeIndex != -1)
                            {
                                Console.WriteLine("Values list before removal: " + string.Join(", ", valuesList));
                                valuesList.RemoveAt(directionChangeIndex);
                                Console.WriteLine("Values List after removal: " + string.Join(", ", valuesList));
                            }
                            bool isReportSafe = CheckIfSafe(valuesList);
                            if (isReportSafe)
                            {
                                safeReportCount++;
                            }
                        }
                        else
                        {
                            bool isReportSafe = CheckIfSafe(valuesList);
                            if (isReportSafe)
                            {
                                safeReportCount++;
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
        
        private static bool HasMultipleDirectionChanges(List<string> valuesList)
        {
            int numAscends = 0;
            int numDescends = 0;
            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                if (Int32.Parse(valuesList[i]) < Int32.Parse(valuesList[i + 1]))
                {
                    numAscends++;
                }
                else
                {
                    numDescends++;
                }
            }
            if(numAscends > 1 && numDescends > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool CheckForOneDirectionChange(List<string> valuesList)
        {
            int numAscends = 0;
            int numDescends = 0;
            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                if (Int32.Parse(valuesList[i]) < Int32.Parse(valuesList[i + 1]))
                {
                    numAscends++;
                }
                else
                {
                    numDescends++;
                }
            }
            if (numAscends == 1 || numDescends == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetDirectionChangeIndex(List<string> valuesList)
        {
            int index = -1;
            int numAscends = 0;
            int numDescends = 0;
            bool ascending = true;
            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                if (Int32.Parse(valuesList[i]) < Int32.Parse(valuesList[i + 1]))
                {
                    numAscends++;
                }
                else
                {
                    numDescends++;
                }
            }
            if (numAscends > numDescends)
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }
            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                if (ascending == true)
                {
                    if (Int32.Parse(valuesList[i]) > Int32.Parse(valuesList[i+1]))
                    {
                        index = i+1;
                        break;
                    }
                }
                else
                {
                    if (Int32.Parse(valuesList[i]) < Int32.Parse(valuesList[i + 1]))
                    {
                        index = i + 1;
                        break;
                    }
                }
            }
            return index;
        }

        private static bool CheckIfSafe(List<string> valuesList)
        {
            bool isSafe = false;
            bool? ascending = null;
            if (Int32.Parse(valuesList[1]) > Int32.Parse(valuesList[0]))
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }

            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                int currentValue = Int32.Parse(valuesList[i]);
                int nextValue = Int32.Parse(valuesList[i + 1]);
                if (ascending == true)
                {
                    if (currentValue > nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                    {
                        isSafe = false;
                        break;
                    }
                }
                else
                {
                    if (currentValue < nextValue || Math.Abs(currentValue - nextValue) > 3 || Math.Abs(currentValue - nextValue) < 1)
                    {
                        isSafe = false;
                        break;
                    }
                }
                //we got to the end without meeting a failing condition, so report is safe and we increment the counter.
                if (i == valuesList.Count - 2)
                {
                    isSafe = true;
                    break;
                }
            }
            return isSafe;
        }
    }
}
