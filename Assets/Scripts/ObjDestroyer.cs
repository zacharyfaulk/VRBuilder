using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyer : MonoBehaviour
{
    //Attached to "KinematicObject" tagged objects
    //Destroys the KinematicObject on collision with the "Destroy" tagged object (Fireplace)
    //TLDR: Destroys the interactable objects when thrown into the fireplace 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
