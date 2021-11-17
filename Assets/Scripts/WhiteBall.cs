using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : BallBase
{
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Hole"))//Reset white ball if it falls in a hole
        {
            this.transform.position = new Vector3(0, 0.218799993f, -0.457500011f);//Starting position
        }
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,0.25f));
    }
}
