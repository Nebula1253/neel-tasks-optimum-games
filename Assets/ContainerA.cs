using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerA : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x + speed, transform.position.y);

        if (transform.position.x >= 10.5 || transform.position.x <= -10.5) { speed *= -1; }
    }
}
