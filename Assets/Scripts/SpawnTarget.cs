using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    //Accepts a Target prefab (targetPrefab)
    //Spawns a user selected amount (numTargets) of Targets (default 1)
    [SerializeField]
    private GameObject targetPrefab;
    private GameObject[] _target;
    private Vector3 spawnPos;
    private int i;
    public int numTargets = 1;
    

    void Start()
    {
        //define _target as a GameObject
        _target = new GameObject[numTargets];
    }

    void Update()
    {
        if (numTargets > 0)
        {
            for (i = 0; i < numTargets; i++)
            //for loop to spawn the correct amount of targets
            {
                spawnPos = new Vector3(Random.Range(-10f, 10f), 1.5f, Random.Range(-25f, -20f));
                //Spawns the Targets inside the selected area (TargetBarrier object)
                if (Physics.CheckSphere(spawnPos, 1.5f) == false)
                //Checks to make sure the Targets don't spawn on top of each other
                {
                    if (_target[i] == null)
                    {
                        _target[i] = Instantiate(targetPrefab) as GameObject;
                        _target[i].transform.position = spawnPos;
                        _target[i].transform.Rotate(-90, 0, 0);
                        //Spawns the Target horizontally (to be rotated)
                    }
                }
            }
        }
    }

}
