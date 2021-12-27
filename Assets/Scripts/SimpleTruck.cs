using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTruck : MonoBehaviour
{
    private int collisionCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "truck")
        {
            GetComponent<Rigidbody>().AddForceAtPosition((collision.transform.position - transform.position), collision.contacts[0].point);
            collisionCounter++;
            if (collisionCounter >= 2)
            {
                Camera.main.GetComponent<MainCamera>().TriggerScreenShake();
                collisionCounter -= 2;
            }
        }
    }
}
