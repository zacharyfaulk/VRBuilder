using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    //Rotates the object 90 degrees in the x direction
    //Once fully rotated will start moving the object in the x and z direction
    public float speed = 0f;
    public bool start = false;

    void Start ()
    {
        //Starts the Coroutine to rotate the object
        StartCoroutine(rotTarget());
	}
	
	void Update ()
    {
        //The speed float determins how fast the object moves in the x and z direction (0 = no movement)
        if(start == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
        }
        
    }

    private IEnumerator rotTarget()
    {
        //Rotates the object 90 degrees in the x direction
        int i = 0;
        while (i < 45)
        {
            this.transform.Rotate(2, 0, 0);
            this.transform.Translate(0, -0.0111f, 0, Space.World);
            i++;
            yield return new WaitForFixedUpdate();
        }
        start = true;
        //once start is set to true, the object can start moving in the x and z direction
    }

    void OnCollisionEnter(Collision collisionInfo)
   {
       //The object's speed is inverted on collision (goes backwards)
       speed = (speed * -1);
   }
}
