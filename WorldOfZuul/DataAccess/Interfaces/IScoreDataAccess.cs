using System;// this is an interface for score data access

public interface IScoreDataAccess

{
    public void SaveScore(int score);
    public int LoadScore();

}

//interfata te obliga sa implimentez metodele