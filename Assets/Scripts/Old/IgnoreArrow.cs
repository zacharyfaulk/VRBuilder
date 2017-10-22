using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreArrow : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Physics.IgnoreCollision(GetComponentInChildren<Collider>(), collision.gameObject.GetComponent<Collider>());
           
        }
    }
}
