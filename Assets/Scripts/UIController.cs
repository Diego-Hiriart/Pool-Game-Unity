using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;
    private GameController gameControl;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private TextMeshProUGUI points;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Button saveSettings;
    [SerializeField]
    private Button newGame;
    [SerializeField]
    private Button saveGame;
    [SerializeField]
    private Button loadGame;
    [SerializeField]
    private Button quitGame;

    // Start is called before the first frame update
    void Start()
    {
        this.SetSettingMenuActive(false);
        this.gameControl = this.controller.GetComponent<GameController>();
        this.volumeSlider.onValueChanged.AddListener(delegate { SliderValueChange(); });
        this.saveSettings.onClick.AddListener(delegate { SaveSetingsClicked(); });
        this.newGame.onClick.AddListener(delegate { NewGameClicked(); });
        this.saveGame.onClick.AddListener(delegate { SaveGameClicked(); });
        this.loadGame.onClick.AddListener(delegate { LoadGameClicked(); });
        this.quitGame.onClick.AddListener(delegate { QuitGameClicked(); });
    }

    public void SetSliderValue(float value)
    {
        this.volumeSlider.value = value;
    }

    public void SetSettingMenuActive(bool status)
    {
        this.settingsMenu.SetActive(status);
    }

    public bool GetSettingMenuActive()
    {
        return this.settingsMenu.activeSelf;
    }

    public void UpdatePointsDisplay(int points)
    {
        this.points.text = "Points: " + points.ToString();
    }

    private void SliderValueChange()
    {
        this.gameControl.VolumeChange(this.volumeSlider.value);
    }

    private void SaveSetingsClicked()
    {
        this.gameControl.SaveSettings(this.volumeSlider.value);
    }

    private void NewGameClicked()
    {
        this.gameControl.NewGame();
    }

    private void SaveGameClicked()
    {
        this.gameControl.SaveGame();
    }

    private void LoadGameClicked()
    {
        this.gameControl.LoadGame();
    }

    private void QuitGameClicked()
    {
        this.gameControl.QuitGame();
    }
}
