using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    //Destroys "Arrow" tagged objects on collison with "Target" tagged objects
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(this.gameObject);
        }
    }
}
