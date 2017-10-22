using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class KinematicToggle : VRTK_InteractableObject
{
    //Built on the VRTK_InteractableObject Script
    //Attached to the "KinematicObject" tagged objects (objects used to build with)
    //Changes the Kinematic and Collision settings of the object as well as the color
    [SerializeField]
    public Material kinematicMaterial;  //Color when Kinematic is on (default: green)
    public Material elseMaterial;       //Color when Kinematic is off (default: blue)
    public bool kinematic = false;      //Used to change object color as well as change Kinematic setting on "Ungrabbed"
    private GameObject obj;
    private Renderer rend;

    void Start()
    {
        //Housekeeping
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        obj = new GameObject();
        obj = null;
    }

    public override void StartUsing(GameObject usingObject)
    {
        //Invert the kinematic Bool when the object is "Used"
        obj = null;
        base.StartUsing(usingObject);
        obj = usingObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        if (obj)
        {
            kinematic = !kinematic;
            //Set the color according to the object's Kinematic setting
            if (kinematic == true)
            {
                rend.sharedMaterial = kinematicMaterial;
            }
            else
            {
                rend.sharedMaterial = elseMaterial;
            }
        }
    }

     public void OnCollisionEnter(Collision collision)
     {
        //If 2 objects collide and at least one has Kinematic turned on, Ignore the collision between the objects (using regular collider)
        if (collision.gameObject.tag == "KinematicObject" && (collision.gameObject.GetComponent<KinematicToggle>().kinematic == true || kinematic == true))
         {
             Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>()); 
         }
     }

    public void OnTriggerEnter(Collider other)
    {
        //If 2 objects collide and they both have Kinematic turned off, DO NOT ignore the collision (using trigger collider)
        //Needed in the event when 2 objects who once had their collision ignored, both had their Kinematic setting set to false and needed the collsion to not be ignored anymore
        if(other.gameObject.tag == "KinematicObject" && (kinematic == false && other.gameObject.GetComponent<KinematicToggle>().kinematic == false))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), false);
        }
    }

    public override void Ungrabbed(GameObject previousGrabbingObject)
    {
        //VRTK_InteractableObject script requires the object being used Kinematic setting to be set to false while being interacted with (allows the object to be moved around)
        //Although the color and collision settings of the object are changed on Use
        //The actual Kinematic setting isn't changed until the object is released from the controller (using the kinematic bool)
        base.Ungrabbed(previousGrabbingObject);
        if (obj != null)
        {
            if (obj.GetComponentInChildren<Rigidbody>().isKinematic != kinematic)
            {
                obj.GetComponent<Rigidbody>().isKinematic = kinematic;

            }
            else
            {
                obj = null;
            }
        }
        if (kinematic == false)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = true;
        }
    }

    protected override void Update()
    {
        base.Update();
    }    
}


