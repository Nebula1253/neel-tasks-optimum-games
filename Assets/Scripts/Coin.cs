using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ControllerPlatformer controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<ControllerPlatformer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.coinCount++;
        this.gameObject.SetActive(false);
    }
}
