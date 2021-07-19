using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour
{
    public float baseSpeed, maxSpeed, speedDecreaseOnHit;
    private float speed, speedLimit;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        speedLimit = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.05f;
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (speed > speedLimit) { speed = speedLimit; }
    }

    public void OnAcceleratorButtonDown()
    {
        speedLimit = maxSpeed;
    }

    public void OnAcceleratorButtonRelease() { speedLimit = baseSpeed; }

    public void speedDecrease()
    {
        speed -= speedDecreaseOnHit;
    }
}
