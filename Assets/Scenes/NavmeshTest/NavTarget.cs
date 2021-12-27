using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTarget : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    IEnumerator varySpeed (float baseSpeed, float range)
    {
        while (target)
        {
            agent.speed = Mathf.Lerp(baseSpeed - range,
                                     baseSpeed + range,
                                     Mathf.PerlinNoise(Time.time + target.position.x,
                                                        Time.time + target.position.y));
            yield return null;
        }
    }


    public NavTarget (Transform target, NavMeshAgent agent)
    {
        this.target = target;
        this.agent = agent;
    }
    
    public void InitNoise (float range)
    {
        StartCoroutine(varySpeed(agent.speed, range));
    }

    // Start is called before the first frame update
    void Update()
    {
        agent.destination = target.position;
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
    }
}
