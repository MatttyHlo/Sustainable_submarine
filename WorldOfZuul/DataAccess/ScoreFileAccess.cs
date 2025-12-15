namespace WorldOfZuul.DataAccess
{
    public class ScoreFileAccess : IScoreFileAccess
    {
        private readonly string filePath;

        public ScoreFileAccess(string fileName = "scores.csv")
        {
            string baseDir = AppContext.BaseDirectory;

            string projectRoot =
                Directory.GetParent(baseDir)!.Parent!.Parent!.Parent!.FullName;

            filePath = Path.Combine(projectRoot, "DataAccess", "Saves", fileName);
        }


        public void SaveScore(int score)
        {
            try
            {
                var dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // CSV format: header + value
                string csvContent = "score\n" + score;

                File.WriteAllText(filePath, csvContent);
                Console.WriteLine($"Score saved to CSV: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save score: {ex.Message}");
            }
        }

        public int LoadScore()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);

                    if (lines.Length >= 2)
                    {
                        return int.Parse(lines[1].Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load score: {ex.Message}");
            }

            return 0;
        }
    }
}
