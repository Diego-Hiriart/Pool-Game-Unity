using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CueStickController : MonoBehaviour
{
    private float force = 0.5f;//Force with with stick is moved to hit the ball
    private float step = 0.001f;
    [SerializeField]
    private GameObject whiteBall;
    [SerializeField]
    private GameObject Canvas;
    private UIController UI;
    private Vector3 posOffset;

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
            this.transform.RotateAround(this.whiteBall.transform.position, Vector3.up, -force);
        }

        if (Input.GetKey(KeyCode.D))//Rotate stick clockwise
        {
            this.transform.RotateAround(this.whiteBall.transform.position, Vector3.up, force);
        }

        if (Input.GetKey(KeyCode.Space))//Move stick
        {
            this.transform.Translate(DirectionCalculator() * force * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.R))
        {
            this.FollowWhiteBall();
        }
    }

    private void OffsetCalculation()
    {
        this.posOffset = this.transform.position - this.whiteBall.transform.position;
    }

    private Vector3 DirectionCalculator()
    {
        return new Vector3(this.whiteBall.transform.position.x - this.transform.position.x, 0,
                this.whiteBall.transform.position.z - this.transform.position.z);
    }

    private void FollowWhiteBall()
    {
        this.transform.rotation = new Quaternion(0.74314481f, 0, 0, 0.669130683f);
        this.transform.position = this.whiteBall.transform.position + posOffset;
    }

    private void UpdateForceIndicator()
    {
        this.UI.UpdateForceDisplay(this.force);
    }
}
