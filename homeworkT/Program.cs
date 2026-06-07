
namespace homeworkT
{
    public class Data
    {
        public int Category { get; set; }
        public int[] scores { get; set; }

        public Data(int category, int[] scores)
        {
            Category = category;
            this.scores = scores;
        }
        public override string ToString()
        {
            return string.Format("Category: {0}, Scores: {1}", Category, string.Join(", ", scores));
        }
    }
    public static class InOut
    {
        public static List<Data> ReadData(string path, out int totalParticipants)
        {

            List<Data> participants = new List<Data>();
            totalParticipants = 0;
            string[] lines = File.ReadAllLines(path);
            totalParticipants = int.Parse(lines[0].Trim());
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                int category = int.Parse(parts[0]);
                int[] scores = new int[parts.Length - 1];
                for (int j = 1; j < parts.Length; j++)
                {
                    scores[j - 1] = int.Parse(parts[j]);
                }
                participants.Add(new Data(category, scores));
            }
            return participants;
        }
        public static void WriteResults(string path, int[] finalScores, bool isValid)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Results: ");
                if (!isValid)
                {
                    writer.WriteLine("Wrong data");
                    for (int i = 1; i <= 10; i++)
                    {
                        writer.WriteLine($"{i} 0");
                    }

                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        writer.WriteLine($"{i} {finalScores[i]}");
                    }
                }

            }
        }
        public static void WriteToOneFile(string path, string currentSourceFile, int[] finalScore, bool isValid, string maxCat, string minCat, int min, int max)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"Source File: {currentSourceFile}");
                sw.WriteLine();

                if (!isValid)
                {
                    sw.WriteLine("Wrong Data");
                    for (int i = 1; i <= 10; i++)
                    {
                        sw.WriteLine($"{i} 0");
                    }
                }
                else
                {
                    sw.WriteLine("Results:");
                    for (int i = 1; i <= 10; i++)
                    {
                        sw.WriteLine($"{i} {finalScore[i]}");
                    }
                    sw.WriteLine();

                    sw.WriteLine($"Max Points: {max} in Category {maxCat}");
                    sw.WriteLine($"Min Points: {min} in Category {minCat}");
                }
                sw.WriteLine(new string('-', 30));
            }
        }
    }

    public static class TaskUtils
    {
        public static int[] CalculateResults(List<Data> participants, int totalParticipants, out bool IsValid)
        {
            int[] finalScores = new int[11];
            IsValid = true;
            if (totalParticipants < 5)
            {
                IsValid = false;
                return finalScores;
            }
            foreach (var p in participants)
            {
                if (p.Category < 1 || p.Category > 10)
                {
                    IsValid = false;
                    return finalScores;
                }
                int scoreSum = 0;
                foreach (int score in p.scores)
                {
                    scoreSum += score;
                }
                finalScores[p.Category] += scoreSum;
            }
            return finalScores;
        }

        public static void MinMax(int[] totalScores, out int min, out int max, out string maxCat, out string minCat)
        {
            max = 0;
            min = int.MaxValue;
            maxCat = "";
            minCat = "";
            for(int i = 1;i < totalScores.Length; i++)
            {
                if (totalScores[i] == 0) continue;
                if (totalScores[i] > max)
                {
                    max = totalScores[i];
                }
                if (totalScores[i] < min)
                {
                    min = totalScores[i];
                }
            }

            List<int> maxCategories = new List<int>();
            List<int> minCategories = new List<int>();

            for(int i = 1; i< totalScores.Length; i++)
            {
                if (totalScores[i] == max && max > 0)
                { 
                    maxCategories.Add(i); 
                }
                if (totalScores[i] == min && min < int.MaxValue)
                {
                    minCategories.Add(i);
                }
            }
            maxCat = string.Join(", ", maxCategories);
            minCat = string.Join(", ", minCategories);

        }
    }

    public partial class Program
    {
        static void Main(string[] args)
        {
            string[] dataFiles = { "pvz.txt", "variantas_1.txt", "variantas_2.txt", "variantas_3.txt", "variantas_4.txt" };

            string outputFile = "results.txt";

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            File.WriteAllText(outputFile, string.Empty);
            foreach(string fileName in dataFiles)
            {
                if(!File.Exists(fileName))
                {
                    Console.WriteLine($"File {fileName} does not exist. Skipping.");
                    continue;
                }

                int totalParticipants;
                List<Data> participants = InOut.ReadData(fileName, out totalParticipants);
                int[] finalScores = TaskUtils.CalculateResults(participants, totalParticipants, out bool isValid);


                int minPoints = 0, maxPoints = 0;
                string maxCategories = "";
                string minCategories = "";
                if (isValid)
                {
                    TaskUtils.MinMax(finalScores, out minPoints, out maxPoints, out maxCategories, out minCategories);

                }

                InOut.WriteToOneFile(outputFile, fileName, finalScores, isValid, maxCategories, minCategories, minPoints, maxPoints);

            }
            Console.WriteLine($"All files were successfully printed to {outputFile} ");
        }
    }
}