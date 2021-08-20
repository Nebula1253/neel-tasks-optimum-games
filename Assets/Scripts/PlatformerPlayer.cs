using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    private Rigidbody2D body;
    public Vector2 playerVelocity;
    public float horizontalSpeed, upwardForce;
    public bool midair = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Vector2.right * Time.deltaTime);
        playerVelocity = body.velocity;
    }

    public void jumpButtonPress()
    {
        body.AddForce(Vector2.up * upwardForce * body.gravityScale);
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        midair = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        midair = true;
    }
}
