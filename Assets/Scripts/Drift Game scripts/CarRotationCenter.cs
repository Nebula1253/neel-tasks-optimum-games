using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotationCenter : MonoBehaviour
{
    private SpriteRenderer carRend;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        carRend = GetComponentInParent<SpriteRenderer>();
        objectHeight = carRend.bounds.size.y;
        setPosition();
    }

    public void setPosition() { transform.localPosition = new Vector2(0, -objectHeight / 2); }
}
