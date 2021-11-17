using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveGameData
{
    private int points;
    private List<BallInfo> balls = new List<BallInfo>();

    public SaveGameData(int score, List<BallInfo> ballsStatus)
    {
        this.points = score;
        this.balls = ballsStatus;
    }
    
    public void SetPoints(int points)
    {
        this.points = points;
    }

    public void SetBallsStatus(List<BallInfo> balls)
    {
        this.balls = balls;
    }

    public int GetPoints()
    {
        return this.points;
    }

    public List<BallInfo> GetBallsStatus()
    {
        return this.balls;
    }

    public void AddBallsStatus(BallInfo ball)
    {
        this.balls.Add(ball);
    }

}
