using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CueStickController : MonoBehaviour
{
    private float force = 0.5f;//Force with with stick is moved to hit the ball
    private float step = 0.001f;//Value of increments and decrements when changing the force
    private float rotationspeed = 0.3f;//Speed with which the stick roatates around the ball
    [SerializeField]
    private GameObject whiteBall;//Target, to where the the stick must be pushed
    [SerializeField]
    private GameObject Canvas;
    private UIController UI;//To change the force display
    private Vector3 posOffset;//Initial position diference between cue tip and white ball

    private void Start()
    {
        this.UI = this.Canvas.GetComponent<UIController>();
        this.UpdateForceIndicator();
        this.OffsetCalculation();        
    }

    // Update is called once per frame
    void Update()
    {     
        
        if (Input.GetKey(KeyCode.W))//Increase force
        {
            if (this.force<1 && !(this.force + step > 1))//Force cant go over 1
            {
                this.force += step;
                this.UpdateForceIndicator();
            }         
        }

        if (Input.GetKey(KeyCode.S))//Decrease force
        {
            if (this.force>0.01 && !(this.force-step<0.01))//Dont allow negative force
            {
                this.force -= step;
                this.UpdateForceIndicator();
            }
        }

        if (Input.GetKey(KeyCode.A))//Rotate stick counterclockwise
        {
            this.transform.RotateAround(this.whiteBall.transform.position, Vector3.up, -rotationspeed);
        }

        if (Input.GetKey(KeyCode.D))//Rotate stick clockwise
        {
            this.transform.RotateAround(this.whiteBall.transform.position, Vector3.up, rotationspeed);
        }

        if (Input.GetKey(KeyCode.Space))//Move stick
        {
            //Move the stick towards the ball to push it
            this.transform.Translate(DirectionCalculator() * force * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.R))//Reset the stick so that it is in an ideal position to hit the ball
        {
            this.FollowWhiteBall();
        }
    }

    //Calculate the position the stick should have relative to the white ball when wanting to shoot (move) the ball
    private void OffsetCalculation()
    {
        this.posOffset = this.transform.position - this.whiteBall.transform.position;
    }

    //Calculate what direction the stick must move towards to hit the ball
    private Vector3 DirectionCalculator()
    {
        return new Vector3(this.whiteBall.transform.position.x - this.transform.position.x, 0,
                this.whiteBall.transform.position.z - this.transform.position.z);
    }

    //Move the cue stick to a position where it can hit the ball and be rotated around it
    private void FollowWhiteBall()
    {
        this.transform.rotation = new Quaternion(0.74314481f, 0, 0, 0.669130683f);//Reset stick rotation
        this.transform.position = this.whiteBall.transform.position + posOffset;//Move the cue so it can hit the ball easily
    }

    //Tell the UI to update the force displayed on the screen
    private void UpdateForceIndicator()
    {
        this.UI.UpdateForceDisplay(this.force);
    }
}
