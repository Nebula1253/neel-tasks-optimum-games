using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftCar : MonoBehaviour
{
    private Rigidbody2D body;
    public float speedLimit, angularSpeed, speedMagnitude, acceleration;
    public Joystick joystick;
    public bool drifting = false;

    public bool onRoad = true;
    private GameObject rotationCenter;
    private float driftTraction;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rotationCenter = GameObject.Find("RotationCenter");
    }

    void FixedUpdate()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float joystickHDirection = 0;

        if (joystick.Horizontal > 0) { joystickHDirection = 1; }
        else if (joystick.Horizontal < 0) { joystickHDirection = -1; }

        if (!drifting) {
            body.rotation += -hDirection * angularSpeed * Time.deltaTime;
            body.rotation += -joystickHDirection * angularSpeed * Time.deltaTime;
            driftTraction = 1;
        }
        else
        {
            body.rotation += -hDirection * angularSpeed * (body.velocity.magnitude / speedLimit) * Time.deltaTime;
            body.rotation += -joystickHDirection * angularSpeed * (body.velocity.magnitude / speedLimit) * Time.deltaTime;
            driftTraction = 5;
        }

        float driftForce = Vector2.Dot(body.velocity, transform.right * -1) * driftTraction;
        Vector2 relativeForce = Vector2.right * driftForce;
        body.AddForce(body.GetRelativeVector(relativeForce));

        if (body.velocity.magnitude > speedLimit)
        {
            body.velocity = body.velocity.normalized * speedLimit;
        }

        body.AddForce(transform.up * acceleration);
    }

    public void driftButtonDown() {
        angularSpeed += 30;
        drifting = true;
    }

    public void driftButtonRelease() {
        angularSpeed -= 30;
        drifting = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (onRoad) { body.velocity = body.velocity.normalized * -5; }
        onRoad = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onRoad = true;
    }
}
