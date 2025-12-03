namespace WorldOfZuul.DataAccess
{
    // Simple data access for saving player scores to a file
    public class ScoreDataAccess : IScoreDataAccess
    {
        private readonly string filePath;

        public ScoreDataAccess()
        {
            filePath = @"C:\\Users\\VivoS\\Desktop\\pidar\\Sustainable_submarine\\scores.txt";
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
                File.WriteAllText(filePath, $"Total Points: {score}");
                Console.WriteLine($"Score saved to: {filePath}");
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
                    string content = File.ReadAllText(filePath);

                    // Parse "Total Points: X"
                    string[] parts = content.Split(':');
                    if (parts.Length == 2)
                    {
                        return int.Parse(parts[1].Trim());
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
