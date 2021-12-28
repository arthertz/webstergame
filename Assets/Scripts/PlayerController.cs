using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject pointer;
    GameObject pointerInstance;
    public GameObject truck;
    GameObject truckInstance;
    public Material[] pointerMats = new Material[2];
    private static int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 inputManPos = GameObject.FindGameObjectWithTag("playerInputManager").transform.position;
        transform.position = inputManPos;
        truckInstance = Instantiate(truck, new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y, transform.position.z + Random.Range(-5f, 5f)) , Quaternion.identity);
        pointerInstance = GameObject.Instantiate(pointer, truckInstance.transform.position, Quaternion.identity);
        GetComponentInChildren<PlayerInput>().SetPointer(pointerInstance);

        playerIndex++;
        if (playerIndex > 1)
            pointerInstance.GetComponent<MeshRenderer>().material = pointerMats[0];
        else
            pointerInstance.GetComponent<MeshRenderer>().material = pointerMats[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (!pointerInstance) return;
        if (!truckInstance) return;

        truckInstance.GetComponent<NavMeshAgent>().SetDestination(pointerInstance.transform.position);
    }
}
