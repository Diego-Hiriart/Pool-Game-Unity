using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        this.setSettingMenuActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSettingMenuActive(bool status)
    {
        this.settingsMenu.SetActive(status);
    }

    public bool getSettingMenuActive()
    {
        return this.settingsMenu.activeSelf;
    }

    public void updatePointsDisplay(int points)
    {
        this.points.text = "Points: " + points.ToString();
    }
}
