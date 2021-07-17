using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public float speed;
    public Joystick joystick;

    private float onRoad = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float vDirection = Input.GetAxisRaw("Vertical");

        // arrow keys movement for editor testing
        transform.Translate(Vector2.right * hDirection * Time.deltaTime * speed * onRoad);
        transform.Translate(Vector2.up * vDirection * Time.deltaTime * speed);

        // joystick movement for Android
        transform.Translate(Vector2.right * joystick.Horizontal * Time.deltaTime * speed * onRoad);
        transform.Translate(Vector2.up * joystick.Vertical * Time.deltaTime * speed);

    }
    }
