using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;
    private GameController gameControl;
    
    private float posX { set; get; }
    private float posY { set; get; }
    private float posZ { set; get; }
    [SerializeField]
    private int ballNumber { set; get; }

    private void Awake()
    {
        this.gameControl = this.controller.GetComponent<GameController>();
    }

    void Start()
    {
        this.posX = this.gameObject.transform.position.x;
        this.posY = this.gameObject.transform.position.y;
        this.posZ = this.gameObject.transform.position.z;
        this.gameControl.addBall(this);//Add a ball to be tracked by the controller
    }

    protected void addPoints()
    {
        this.gameControl.addPoints();
    }
}
