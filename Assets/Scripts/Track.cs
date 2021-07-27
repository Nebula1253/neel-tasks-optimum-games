using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour
{
    public float baseSpeed, maxSpeed, speedDecreaseOnHit;
    public float widthScaleDecrease, heightScaleIncrease;
    private float widthScale, heightScale, initWidthScale, initHeightScale;
    private float speed, speedLimit;
    private bool decelerate = false;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        initWidthScale = transform.localScale.x;
        initHeightScale = transform.localScale.y;

        speed = 0;
        speedLimit = baseSpeed;

        controller = GameObject.Find("GameController").GetComponent<GameController>();
        trackScale();
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

    public float GetSpeed()
    {
        return speed;
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
        if (speed > 0) { speed -= speedDecreaseOnHit; }
        else { speed -= 5; }
    }

    public void stopScrolling()
    {
        decelerate = true;
        speed = baseSpeed;
    }

    public void trackScale()
    {
        GameObject finishLine = GameObject.Find("Finish Line");

        float finishScaleX = finishLine.transform.localScale.x;
        float finishScaleY = finishLine.transform.localScale.y;

        widthScale = initWidthScale - (widthScaleDecrease * (controller.level - 1));
        heightScale = initHeightScale + (heightScaleIncrease * (controller.level - 1));
        transform.localScale = new Vector3(widthScale, heightScale, 0);

        // keeps the finish line graphic's proportions constant
        
        finishLine.transform.localScale = new Vector3(finishScaleX / widthScale, finishScaleY / heightScale, 0);

        float newPosY = (GetComponent<SpriteRenderer>().bounds.size.y / 2) - 5;
        float posX = transform.position.x;
        transform.position = new Vector2(posX, newPosY);

        decelerate = false;
    }

    public float getWidthScale() { return widthScale; }

    public float getHeightScale() { return heightScale; }
}
