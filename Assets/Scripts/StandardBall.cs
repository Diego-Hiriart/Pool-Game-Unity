using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBall : BallBase
{
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Hole"))//Add points
        {
            this.AddPoints();
        }

        if (trigger.CompareTag("OutOfBounds"))
        {
            Destroy(this);
        }
    }
}
