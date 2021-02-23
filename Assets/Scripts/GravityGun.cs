using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;
    public float maxGrabDistance = 10f;
    public Transform objectHolder;
    public float distance = 100f;

    Rigidbody grabbedRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward * distance * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        if(grabbedRB)
        {
            grabbedRB.MovePosition(objectHolder.transform.position);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if(grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}
