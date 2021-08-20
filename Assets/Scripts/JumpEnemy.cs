using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    private Rigidbody2D body;
    private bool activated = false;
    public float upwardForce;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            jump();
        }
    }

    private void jump()
    {
        body.AddForce(Vector2.up * upwardForce * body.gravityScale);
        activated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        activated = false;
    }
}
