namespace WorldOfZuul.DataAccess
{
    // Simple data access for saving player scores to a file
    public class ScoreDataAccess : IScoreDataAccess
    {
        private string filePath = "scores.txt";

        public void SaveScore(int score)
        {
            try
            {
                File.WriteAllText(filePath, $"Total Points: {score}");
            }
            catch
            {
                // Ignore save errors
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
            catch
            {
                // Ignore load errors
            }
            return 0;
        }
    }
}
