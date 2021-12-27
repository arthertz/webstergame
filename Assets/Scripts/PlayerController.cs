using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Vector3 pointerPos;
    RaycastHit hit;
    int layerMask;
    public GameObject pointer;
    public GameObject truck;

    // Start is called before the first frame update
    void Start()
    {
        if (LayerMask.NameToLayer("ground") > 0)
        {
            layerMask = 1 << LayerMask.NameToLayer("ground");
        }
        else
        {
            layerMask = 0;
            Debug.LogError("ground layer not set correctly!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layerMask))
        {
            pointerPos = hit.point;
        }

        pointer.transform.position = pointerPos;
        truck.GetComponent<NavMeshAgent>().SetDestination(pointerPos);
    }
}
