using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    //Attached to the Target object
    //Rotates the object -90 degrees in the x direction on collision with an "Arrow" tagged object
    private bool dead = false;
    //dead bool used to make sure the Die Coroutine isn't called more than once

    private IEnumerator Die()
    {
        //Rotates the object -90 degrees in the x direction
        int i = 0;
        while (i < 45)
        {
            this.transform.Rotate(-2, 0, 0);
            this.transform.Translate(0, -0.0111f, 0, Space.World);
            i++;
            yield return new WaitForFixedUpdate();
        }
        //Destroy the object to allow a new one to spawn
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        //On collision with an "Arrow" tagged object:
        //Set dead bool to true
        //Set the start bool in TargetRotate.cs to false (stops the object from moving in the x and z direction)
        //Starts the Die Coroutine
        if ((collision.gameObject.tag == "Arrow") && (dead == false))
        {
            dead = true;
            this.GetComponent<TargetRotate>().start = false;
            StartCoroutine(Die());
        }
    }
}
