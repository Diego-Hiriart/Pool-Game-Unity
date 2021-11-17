using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBall : BallBase
{
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Hole"))//Add a point and destroy the ball if it falls in a hole
        {
            this.AddPoint();
            Destroy(this);
        }

        if (trigger.CompareTag("OutOfBounds"))//If the ball goes out of bounds, reset its position
        {
            this.transform.position = new Vector3(0, 0.2188f, 0);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;//Remove position changes (displacement)
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;//Remove angular movement (rotation)
        }
    }
}
