using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnJam : MonoBehaviour
{
    [SerializeField] Transform spawnCenter;
    [SerializeField] float radius = 5f;
    [SerializeField] int numcars = 5;
    [SerializeField] GameObject carPrefab;
    [SerializeField] float noiseRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnCenter == null || carPrefab == null || numcars < 2 || radius <= 0f)
        {
            Debug.LogError("Bad input, Check parameters");
            Debug.Break();
        }

        Vector3 o = spawnCenter.position;

        GameObject firstCar = null;
        GameObject lastCar = null;
        GameObject car = null;

        // with less than 2 cars, there will be a null reference
        Debug.Assert(numcars >= 2);

        for (int i = 0; i < numcars; i++)
        {
            lastCar = car;

            // lastcar -> car
            car = SpawnCar(o, radius, i);

            if (i == 0) firstCar = car;

            ConnectCar(lastCar, car);
        }

        // car -> firstcar
        ConnectCar(car, firstCar);
    }

    GameObject SpawnCar (Vector3 origin, float radius, int num)
    {
        float angle = num * 2 * Mathf.PI / numcars;
        Vector3 target = origin + new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
        GameObject res = GameObject.Instantiate(carPrefab, target, Quaternion.identity);
        return res;
    }

    void ConnectCar(GameObject car, GameObject nextCar)
    {
        if (!car) return;
        if (!nextCar) return;

        //set up nav mesh agent and target
        NavTarget t = car.AddComponent<NavTarget>();
        t.target = nextCar.transform;
        t.agent = car.GetComponent<NavMeshAgent>();
        t.InitNoise(noiseRange);
    }
}
