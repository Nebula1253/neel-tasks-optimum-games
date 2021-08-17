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
    private float driftTraction;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float vDirection = 1;
        float joystickHDirection = 0;
        float joystickVDirection = 1;

        if (Input.GetAxisRaw("Vertical") < 0) { vDirection = -0.5f; }
        if (joystick.Vertical <= -0.5f) { joystickVDirection = -0.5f; }

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

        body.AddForce(transform.up * acceleration * joystickVDirection * vDirection);

    }

    public void driftButtonDown() {
        angularSpeed += 30;
        drifting = true;
    }

    public void driftButtonRelease() {
        angularSpeed -= 30;
        drifting = false;
    }

}
