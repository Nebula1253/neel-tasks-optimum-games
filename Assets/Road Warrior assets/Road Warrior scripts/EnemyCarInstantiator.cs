using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarInstantiator : MonoBehaviour
{
    public GameObject enemyCar;
    public int numberOfCars;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        instantiateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateEnemy()
    {
        numberOfCars += (controller.level - 1) * controller.nrEnemiesIncreaseWithLevel;

        // destroys any obstacles
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject obj in allEnemies) { Destroy(obj); }

        GameObject road = GameObject.Find("Track");
        Track trackScript = road.GetComponent<Track>();

        float horizontalLimit = 4.8f * trackScript.getWidthScale();
        float verticalLimit = (800 * trackScript.getHeightScale()) / 4;

        for (int i = 1; i <= numberOfCars; i++)
        {
            GameObject x = Instantiate(enemyCar, new Vector3(Random.Range(-horizontalLimit, horizontalLimit), Random.Range(0f, verticalLimit), 0), Quaternion.identity);
            x.transform.parent = road.transform;
        }
    }
}
