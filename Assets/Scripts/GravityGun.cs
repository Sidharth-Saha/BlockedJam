using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;
    public float maxGrabDistance = 10f;
    public Transform objectHolder;
    public float speed = 100f, lerpSpeed = 10f;
    public float distance;
    public GameObject movableObject;

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
            grabbedRB.velocity = (objectHolder.transform.position - movableObject.transform.position) * lerpSpeed;
            //grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(grabbedRB)
            {
                //grabbedRB.isKinematic = false;
                grabbedRB.useGravity = true;
                grabbedRB.freezeRotation = false;
                grabbedRB = null;
                movableObject = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    movableObject = hit.collider.gameObject;
                    if(movableObject.tag == "Grab")
                    {
                        grabbedRB = movableObject.GetComponent<Rigidbody>();
                    }
                    if(grabbedRB)
                    {
                        //grabbedRB.isKinematic = true;
                        //grabbedRB.detectCollisions = true;
                        grabbedRB.useGravity = false;
                        grabbedRB.freezeRotation = true;
                    }
                }
            }
        }
    }
}
