using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftCar : MonoBehaviour
{
    private Rigidbody2D body;
    public float upwardSpeed, baseAngularSpeed, driftAngularSpeed;
    private float angularSpeed;
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
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, -hDirection * angularSpeed * Time.deltaTime);
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, -joystick.Horizontal * angularSpeed * Time.deltaTime);
        body.velocity = transform.up * upwardSpeed;
    }

    public void driftButtonDown() {
        angularSpeed = driftAngularSpeed;
        rotationCenter.transform.localPosition = new Vector2(0, 0);
    }

    public void driftButtonRelease() {
        angularSpeed = baseAngularSpeed;
        rotationCenter.GetComponent<CarRotationCenter>().setPosition();
    }
}
