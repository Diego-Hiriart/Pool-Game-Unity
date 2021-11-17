using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private List<BallBase> gameBalls = new List<BallBase>();//To keep track of the balls in the game
    [SerializeField]
    private GameObject Canvas;
    private UIController UI;

    // Start is called before the first frame update
    void Start()
    {
        this.UI = this.Canvas.GetComponent<UIController>();
        this.UI.setSettingMenuActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!this.UI.getSettingMenuActive())//If not on pause, pause the game
            {
                Time.timeScale = 0;
                this.UI.setSettingMenuActive(true);
            }
            else
            {
                this.UI.setSettingMenuActive(false);
                Time.timeScale = 1;
            }
            
        }
    }

    public void addBall(BallBase ball)
    {
        this.gameBalls.Add(ball);
    }

    private SaveGameData CreateSaveGameData()
    {      
        return new SaveGameData(this.score, this.gameBalls);
    }

    public void saveGame()
    {
        SaveGameData save = this.CreateSaveGameData();

        //Save as binary so player cant cheat
        var bf = new BinaryFormatter();
        var filePath = Application.persistentDataPath + "/gamesave.data";

        var fs = File.Create(filePath);
        bf.Serialize(fs, save);
    }

    public void loadGame()
    {
        var filePath = Application.persistentDataPath + "/gamesave.data";

        if (File.Exists(filePath))
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(filePath, FileMode.Open);
            var saveData = (SaveGameData)bf.Deserialize(fs);

            this.score = saveData.getPoints();
            this.gameBalls = saveData.getBallsStatus();
        }
    }

    public void setScore(int score)
    {
        this.score = score;
        this.UI.updatePointsDisplay(this.score);
    }

    public int getPoints()
    {
        return this.score;
    }

    public void addPoints()
    {
        this.score++;
        this.UI.updatePointsDisplay(this.score);
    }
  
}
