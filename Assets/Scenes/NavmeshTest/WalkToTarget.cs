using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkCursor : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent agent;
        
    // Start is called before the first frame update
    void Start()
    {
        agent.destination = target.position;
    }
}
