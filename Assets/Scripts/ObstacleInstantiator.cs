using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObstacle(float minXvalue, float maxXvalue)
    {
        Instantiate(obstacle, new Vector2(Random.Range(minXvalue, maxXvalue),0), Quaternion.identity);
    }
}
