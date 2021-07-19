using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarInstantiator : MonoBehaviour
{
    public GameObject enemyCar;
    public int numberOfCars;

    // Start is called before the first frame update
    void Start()
    {
        GameObject road = GameObject.Find("RoadTestTexture");
        for (int i = 1; i <= numberOfCars; i++)
        {
            GameObject x = Instantiate(enemyCar, new Vector3(Random.Range(-4.8f, 4.8f), Random.Range(0f, 50f), 0), Quaternion.identity);
            x.transform.parent = road.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
