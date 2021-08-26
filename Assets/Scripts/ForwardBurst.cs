using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBurst : MonoBehaviour
{
    private PlatformerPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlatformerPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.forwardBurstActive = true;
        Destroy(this.gameObject);
    }
}
