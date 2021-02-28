using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIComponent : MonoBehaviour
{
    // Reference to the attached nav mesh agent
     private NavMeshAgent m_NavMeshAgent;

    [SerializeField]
    private Transform[] m_PathPoints;
    private int m_DestinationPoint;
    private bool m_ReachedDestination;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to attached nav mesh component
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        // Stop nav mesh agent from slowing down for points in the path
        m_NavMeshAgent.autoBraking = false;
        m_DestinationPoint = -1;
        MoveToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PathPoints.Length > 0)
        {
            if (!m_ReachedDestination)
            {
                if (Vector3.Distance(transform.position, m_PathPoints[m_DestinationPoint].position) <= 1.0)
                {
                    MoveToNextPoint();
                }
            }
        }
    }

    void MoveToNextPoint()
    {
        if (m_PathPoints.Length > 0)
        {
            m_DestinationPoint++;
            if (m_DestinationPoint == m_PathPoints.Length - 1)
            {
                m_NavMeshAgent.autoBraking = true;
                m_ReachedDestination = true;
            }
            m_NavMeshAgent.destination = m_PathPoints[m_DestinationPoint].position;
        }
    }
}
