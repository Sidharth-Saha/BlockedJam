using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallCatch : MonoBehaviour
{
    [SerializeField] Vector3 spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        other.gameObject.transform.position = spawnpoint;
        if (other.gameObject.tag == "Grab")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = other.gameObject.GetComponent<storeSpawn>().spawnPoint;
        }
    }
}
