using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour
{
    public float speed, speedLimit;
    private float initSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    public void OnAcceleratorButtonDown()
    {
        speed += 0.05f;
        if (speed > speedLimit) { speed = speedLimit; }
    }

    public void OnAcceleratorButtonRelease() { speed = initSpeed; }
}
