using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlatformer : MonoBehaviour
{
    public int coinCount;
    public int playerHP;
    public Text centralDisplay;
    private GameObject playerHUD, player;
    // Start is called before the first frame update
    void Start()
    {
        playerHUD = GameObject.Find("PlayerHUD");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerDeath()
    {
        centralDisplay.text = "GAME OVER";
        centralDisplay.gameObject.SetActive(true);
        playerHUD.SetActive(false);
        player.SetActive(false);
    }
}
