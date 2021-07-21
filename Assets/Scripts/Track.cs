using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour
{
    public float baseSpeed, maxSpeed, speedDecreaseOnHit;
    private float speed, speedLimit;
    private bool decelerate = false;

    public float GetSpeed()
    {
        return speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        speedLimit = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // start decelerating after hitting the finish line
        if (decelerate)
        {
            speed -= 25f * Time.deltaTime;
            if (speed < 0) { speed = 0; }
        }
        else
        {
            speed += 10f * Time.deltaTime;
            if (speed > speedLimit) { speed = speedLimit; }
        }

        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    public void OnAcceleratorButtonDown()
    {
        speedLimit = maxSpeed;
        speedDecreaseOnHit = maxSpeed + 5;
    }

    public void OnAcceleratorButtonRelease() { 
        speedLimit = baseSpeed;
        speedDecreaseOnHit = baseSpeed + 5;
    }

    public void speedDecrease()
    {
        speed -= speedDecreaseOnHit;
    }

    public void stopScrolling()
    {
        decelerate = true;
        speed = baseSpeed;
    }
}
