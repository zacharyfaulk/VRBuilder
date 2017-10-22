using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreWall : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(GetComponentInChildren<Collider>(), other.gameObject.GetComponentInChildren<Collider>());
        }
    }
}
