using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    private Rigidbody2D body;
    public Vector2 playerVelocity;
    public float horizontalSpeed, upwardForce, enemyBounceForce, highJumpForce, forwardBurstForce;
    public bool midair = false;
    public bool forwardBurstActive = false;
    private ControllerPlatformer controller;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        controller = GameObject.Find("GameController").GetComponent<ControllerPlatformer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Vector2.right * Time.deltaTime);
        playerVelocity = body.velocity;

        // for design purposes
        if (Input.GetKeyDown("space")) { Time.timeScale = 0f; }
    }

    public void jump()
    {
        body.AddForce(Vector2.up * upwardForce * body.gravityScale);
    }

    public void highJump()
    {
        body.AddForce(Vector2.up * highJumpForce * body.gravityScale);
    }

    public void forwardBurst()
    {
        if (forwardBurstActive) { body.AddForce(Vector2.right * forwardBurstForce); }
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            if (playerVelocity.y < 0)
            {
                body.velocity = new Vector2(0, 0);
                body.AddForce(Vector2.up * enemyBounceForce * body.gravityScale);
            }
            else { controller.playerHP--; }
        }
        if (controller.playerHP == 0) { 
            controller.playerDeath(); 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        midair = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        midair = true;
    }
}
