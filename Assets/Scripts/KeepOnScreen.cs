using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    private SpriteRenderer rend;
    private Vector2 screenBounds;
    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;
        objectHeight = rend.bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 objPos = transform.position;
        objPos.x = Mathf.Clamp(objPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        objPos.y = Mathf.Clamp(objPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = objPos;
    }
}
