namespace WorldOfZuul.DataAccess
{
    public class ScoreFileAccess : IScoreFileAccess
    {
        private readonly string filePath;

        // Default file placed at project root (same level as Program.cs)
        public ScoreFileAccess(string fileName = "scores.csv")
        {
            // Start from the current running directory
            string baseDir = AppContext.BaseDirectory;

            // Go 3 folders up from /bin/Debug/netX
            string projectRoot =
                Directory.GetParent(baseDir)!.Parent!.Parent!.Parent!.FullName;

            // Final file path
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
