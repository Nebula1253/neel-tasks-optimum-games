using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftCar : MonoBehaviour
{
    private Rigidbody2D body;
    public float upwardSpeedLimit, baseAngularSpeed, driftAngularSpeed;
    public float angularSpeed, upwardSpeed;
    public Joystick joystick;
    private GameObject rotationCenter;

    // Start is called before the first frame update
    void Start()
    {
        angularSpeed = baseAngularSpeed;
        body = GetComponent<Rigidbody2D>();
        rotationCenter = GameObject.Find("RotationCenter");
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float joystickHDirection = 0;

        if (joystick.Horizontal > 0) { joystickHDirection = 1; }
        else if (joystick.Horizontal < 0) { joystickHDirection = -1; }

        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, -hDirection * angularSpeed * Time.deltaTime);
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, -joystickHDirection * angularSpeed * Time.deltaTime);
        
        body.velocity = transform.up * upwardSpeed;
        upwardSpeed+= 10f * Time.deltaTime;
        if (upwardSpeed > upwardSpeedLimit)
        {
            upwardSpeed = upwardSpeedLimit;
        }
    }

    public void driftButtonDown() {
        angularSpeed = driftAngularSpeed;
        rotationCenter.transform.localPosition = new Vector2(0, 0);
    }

    public void driftButtonRelease() {
        angularSpeed = baseAngularSpeed;
        rotationCenter.GetComponent<CarRotationCenter>().setPosition();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        upwardSpeed = 0;
    }
}
