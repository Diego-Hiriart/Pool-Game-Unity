using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : BallBase
{
    private AudioSource impact;

    void Start()
    {
        this.posX = this.gameObject.transform.position.x;
        this.posY = this.gameObject.transform.position.y;
        this.posZ = this.gameObject.transform.position.z;
        this.gameControl.AddBall(this);//Add a ball to be tracked by the controller
        impact = this.GetComponent<AudioSource>();//Get the audio added to the ball in Unity
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Hole") || trigger.CompareTag("OutOfBounds"))//Reset white ball if it falls in a hole or outside the talbe
        {
            this.transform.position = new Vector3(0, 0.218799993f, -0.457500011f);//Starting position
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("CueStick"))
        {
            impact.Play();//Play impact sound
        }
    }
}
