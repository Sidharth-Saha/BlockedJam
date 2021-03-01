using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
