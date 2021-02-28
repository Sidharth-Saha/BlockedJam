using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIComponent : MonoBehaviour
{
    // Reference to the attached nav mesh agent
    NavMeshAgent m_NavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to attached nav mesh component
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
