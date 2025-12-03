using System;

public interface IScoreDataAccess

{
    public void SaveScore(int score);
    public int LoadScore();

}

//interfata te obliga sa implimentez metodele