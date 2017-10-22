using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 1.0f;
    //public float x;
    //public float z;

    void Start()
    {
        //x = Random.Range(2, 5);
        //z = Random.Range(2, 5);
        //new WaitForSeconds(1.5f);
    }

    void Update()
    {

        transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);

    }

   void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);

        speed = (speed * -1);
        //x = Random.Range(2, 5);
        //z = Random.Range(2, 5);

    }
}
