using System.Collections;
using System.Collections.Generic;

public class SaveGameData
{
    private int points;
    private List<BallBase> balls = new List<BallBase>();

    public SaveGameData(int score, List<BallBase> ballsStatus)
    {
        this.points = score;
        this.balls = ballsStatus;
    }
    
    public void setPoints(int points)
    {
        this.points = points;
    }

    public void setBallsStatus(List<BallBase> balls)
    {
        this.balls = balls;
    }

    public int getPoints()
    {
        return this.points;
    }

    public List<BallBase> getBallsStatus()
    {
        return this.balls;
    }

    public void addBallsStatus(BallBase ball)
    {
        this.balls.Add(ball);
    }

}
