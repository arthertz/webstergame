using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject pointer;
    public GameObject truck;
    public Material[] pointerMats = new Material[2];
    private static int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("playerInputManager").transform.position;
        pointer = Instantiate(pointer, transform.position, Quaternion.identity);
        GetComponentInChildren<PlayerInput>().SetPointer(pointer);
        truck = Instantiate(truck, new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y, transform.position.z + Random.Range(-5f, 5f)) , Quaternion.identity);

        playerIndex++;
        if (playerIndex > 1)
            pointer.GetComponent<MeshRenderer>().material = pointerMats[0];
        else
            pointer.GetComponent<MeshRenderer>().material = pointerMats[1];

    }

    // Update is called once per frame
    void Update()
    {
        truck.GetComponent<NavMeshAgent>().SetDestination(pointer.transform.position);
    }
}
