using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlatformer : MonoBehaviour
{
    private GameObject player;
    private bool followingPlayer = true;
    public float playerDistanceFromScreenEdge;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer) { transform.position = new Vector3(player.transform.position.x + playerDistanceFromScreenEdge, 0, -100); }
    }
}
