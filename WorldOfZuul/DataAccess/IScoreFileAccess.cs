namespace WorldOfZuul.DataAccess
{
    public interface IScoreFileAccess
    {
        void SaveScore(int score);
        int LoadScore();
    }
}
