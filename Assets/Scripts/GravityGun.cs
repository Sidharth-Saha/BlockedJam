using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;
    public float maxGrabDistance = 10f;
    public Transform objectHolder;
    public float speed = 100f;
    public float distance;// = new Vector3();

    Rigidbody grabbedRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(cam.transform.position, objectHolder.transform.position);

        if(distance >= 2)
        {
            objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward * speed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
        }
        else
        {
            objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward;
        }

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
                    if(hit.collider.gameObject.tag == "Grab")
                    {
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    }
                    if(grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}
