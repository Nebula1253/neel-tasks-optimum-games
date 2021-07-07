using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallB : MonoBehaviour
{
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            body.velocity = new Vector2(0, -10);
        }
    }
}
