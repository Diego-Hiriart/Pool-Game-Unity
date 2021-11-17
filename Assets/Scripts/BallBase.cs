using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;
    private GameController gameControl;

    private float posX;
    private float posY;
    private float posZ;
    [SerializeField]
    private int ballNumber;

    private void Awake()
    {
        this.gameControl = this.controller.GetComponent<GameController>();
    }

    void Start()
    {
        this.posX = this.gameObject.transform.position.x;
        this.posY = this.gameObject.transform.position.y;
        this.posZ = this.gameObject.transform.position.z;
        this.gameControl.AddBall(this);//Add a ball to be tracked by the controller
    }

    private void LateUpdate()
    {
        this.posX = this.gameObject.transform.position.x;
        this.posY = this.gameObject.transform.position.y;
        this.posZ = this.gameObject.transform.position.z;
    }

    protected void AddPoints()
    {
        this.gameControl.AddPoints();
    }

    public void SetBallNumber(int number)
    {
        this.ballNumber = number;
    }

    public float GetPosX()
    {
        return this.posX;
    }

    public float GetPosY()
    {
        return this.posY;
    }

    public float GetPosZ()
    {
        return this.posZ;
    }

    public int getBallNumber()
    {
        return this.ballNumber;
    }
}
