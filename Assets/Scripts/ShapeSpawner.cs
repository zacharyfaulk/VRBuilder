using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    //Attached to the tables that the KinematicObjects spawn on
    //Accepts and spawns a Prefab (shapePrefab) at the user specified spawn position (spawnPos)
    [SerializeField]
    private GameObject shapePrefab;
    private GameObject _shape;
    private float time;
    public Vector3 spawnPos = new Vector3(0f, 0f, 0f);

    void Start()
    {
        //Set time to 0 and define _shape as a GameObject
        time = 0f;
        _shape = new GameObject();
    }

    void Update()
    {
        //Every 2 seconds a CheckSphere will occur at the spawnPos
        //If there is no object at the spawnPos, spawn another shapePrefab at the spawnPos
        time += Time.deltaTime;
        if (time >= 2f)
        {
            if (Physics.CheckSphere(spawnPos, .02f) == false)
            {
                _shape = Instantiate(shapePrefab) as GameObject;
                _shape.transform.position = spawnPos;
            }
            time = 0f;
        }
        
    }
}
