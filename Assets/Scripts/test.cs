using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float steering;

    private Rigidbody2D rb;
    public float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get input
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * /*v */ acceleration;
        rb.AddForce(speed);

        // Create car rotation
        //float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        rb.rotation += h * steering * (rb.velocity.magnitude / maxSpeed);
        //if (direction >= 0.0f)
        //{
            
        //}
        //else
        //{
        //    rb.rotation -= h * steering * (rb.velocity.magnitude / maxSpeed);
        //}

        // Change velocity based on rotation
        //float driftForce = Vector2.Dot(rb.velocity, transform.right * -1) * 2.0f;
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        // Force max speed limit
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        currentSpeed = rb.velocity.magnitude;
    }
}
