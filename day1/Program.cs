using System.IO;

namespace day1
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
            string filePath = "C:\\Users\\Dev\\Desktop\\aoc_day1_inputs.txt";
            string? line;
            int totalDistance = 0;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Split line into its 2 integer lists; the .Split function is creating 2 string.isNullOrEmpty values, so we use first and last. Hacky solution :(
                    string[] values = line.Split(' ');
                    leftList.Add(Int32.Parse(values[0]));
                    rightList.Add(Int32.Parse(values[3]));
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            if (leftList.Count != rightList.Count)
            {
                Console.WriteLine("left and right lists are not the same length");
                return;
            }

            leftList.Sort();
            rightList.Sort();

            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance = totalDistance + Math.Abs(leftList[i] - rightList[i]);
            }

            Console.WriteLine("Part 1 answer - Total Distance: " + totalDistance.ToString());
        }

        private static void Get_Part2_Answer() {
            //TODO: Figure out how to read filepath from appsettings.json
            string filePath = "C:\\Users\\Dev\\Desktop\\aoc_day1_inputs.txt";
            string? line;
            int totalSimilarity = 0;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Split line into its 2 integer lists; the .Split function is creating 2 string.isNullOrEmpty values, so we use first and last. Hacky solution :(
                    string[] values = line.Split(' ');
                    leftList.Add(Int32.Parse(values[0]));
                    rightList.Add(Int32.Parse(values[3]));
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            if (leftList.Count != rightList.Count)
            {
                Console.WriteLine("left and right lists are not the same length");
                return;
            }

            leftList.Sort();
            rightList.Sort();

            for (int i = 0; i < leftList.Count; i++)
            {
                int similarityMultiplier = 0;
                for (int j = 0; j < rightList.Count; j++)
                {
                    if (leftList[i] == rightList[j])
                    {
                        similarityMultiplier++;
                    }
                }
                totalSimilarity = totalSimilarity + (leftList[i] * similarityMultiplier);
            }

            Console.WriteLine("Part 2 answer - Total Similarity: " + totalSimilarity.ToString());
        }
    }
}
