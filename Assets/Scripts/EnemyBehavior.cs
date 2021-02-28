using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private int thinkCount = 0;
    public int thinkThreshold = 30;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(thinkCount % thinkThreshold == 0)
        {
            agent.destination = target.position;
            thinkCount = 1;
        }
        thinkCount++;
    }
}
