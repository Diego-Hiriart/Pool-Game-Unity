using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private List<BallBase> gameBalls = new List<BallBase>();//To keep track of the balls in the game
    [SerializeField]
    private GameObject Canvas;
    private UIController UI;
    [SerializeField]
    private AudioSource backgroundMusic;

    private const string musicVolumeKey = "music_volume";

    // Start is called before the first frame update
    void Start()
    {
        this.UI = this.Canvas.GetComponent<UIController>();
        this.UI.SetSettingMenuActive(false);
        this.LoadMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!this.UI.GetSettingMenuActive())//If not on pause, pause the game
            {
                Time.timeScale = 0;
                this.UI.SetSettingMenuActive(true);
            }
            else
            {
                this.UI.SetSettingMenuActive(false);
                Time.timeScale = 1;
            }
            
        }
    }

    private void SetVolumeSliderValue(float value)
    {
        this.UI.SetSliderValue(value);
    }

    public void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey(musicVolumeKey))
        {
            float value = PlayerPrefs.GetFloat("music_volume");
            this.backgroundMusic.volume = value;
            this.SetVolumeSliderValue(value);
        }
        else
        {
            float value = this.backgroundMusic.volume;
            this.SetVolumeSliderValue(value);
        }
    }

    public void VolumeChange(float value)
    {
        this.backgroundMusic.volume = value;
    }

    public void SaveSettings(float value)
    {
        PlayerPrefs.SetFloat(musicVolumeKey, value);
        PlayerPrefs.Save();
    }

    public void AddBall(BallBase ball)
    {
        this.gameBalls.Add(ball);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("PoolGame");//Reload the scene
    }

    private SaveGameData CreateSaveGameData()
    {
        List<BallInfo> ballsInfo = new List<BallInfo>();
        foreach(BallBase ball in this.gameBalls)
        {
            ballsInfo.Add(new BallInfo(ball.GetPosX(), ball.GetPosY(), ball.GetPosZ(), ball.getBallNumber()));
        }
        return new SaveGameData(this.score, ballsInfo);
    }

    public void SaveGame()
    {
        SaveGameData save = this.CreateSaveGameData();

        //Save as binary so player cant cheat
        var bf = new BinaryFormatter();
        var filePath = Application.persistentDataPath + "/gamesave.data";

        var fs = File.Create(filePath);
        bf.Serialize(fs, save);
    }

    public void LoadGame()
    {
        var filePath = Application.persistentDataPath + "/gamesave.data";

        if (File.Exists(filePath))
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(filePath, FileMode.Open);
            var saveData = (SaveGameData)bf.Deserialize(fs);

            this.score = saveData.GetPoints();
            this.gameBalls = this.LoadBalls(saveData);
            this.SetScore(this.score);
        }
    }

    private List<BallBase> LoadBalls(SaveGameData saveData)
    {
        List<BallBase> balls = new List<BallBase>();
        for (int i = 0; i<saveData.GetBallsStatus().Count; i++)
        {
            BallInfo ball = saveData.GetBallsStatus()[i];
            this.gameBalls[i].transform.position = new Vector3(ball.GetPosX(), ball.GetPosY(), ball.GetPosZ());
            this.gameBalls[i].SetBallNumber(ball.getBallNumber());
        }
        return balls;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetScore(int score)
    {
        this.score = score;
        this.UI.UpdatePointsDisplay(this.score);
    }

    public int GetPoints()
    {
        return this.score;
    }

    public void AddPoints()
    {
        this.score++;
        this.UI.UpdatePointsDisplay(this.score);
    }
  
}
