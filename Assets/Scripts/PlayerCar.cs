using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCar : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    private bool onRoad = true;

    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isRaceOver())
        {
            // float values only used for movement with keyboard on laptop
            float hDirection = Input.GetAxisRaw("Horizontal");
            float vDirection = Input.GetAxisRaw("Vertical");

            if (onRoad)
            {
                transform.Translate(Vector2.right * hDirection * Time.deltaTime * speed);
                transform.Translate(Vector2.right * joystick.Horizontal * Time.deltaTime * speed);
            }
            transform.Translate(Vector2.up * vDirection * Time.deltaTime * speed);
            transform.Translate(Vector2.up * joystick.Vertical * Time.deltaTime * speed);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onRoad = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "leftBumper")
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else { transform.Translate(Vector2.left * Time.deltaTime * speed); }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onRoad = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Finish Line")
        {
            controller.playerFinish();
        }
    }
}