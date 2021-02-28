using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrigger : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grab")
        {
            wall.GetComponent<Animator>().Play("wallDescend");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
