using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int level;
    public int nrEnemiesIncreaseWithLevel;
    private bool raceOver = false, won = false;
    private Track track;
    private Timer timer;
    private EnemyCarInstantiator instantiator;
    public Text gameOverText;
    public Text levelDisplay;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        levelDisplay.text = "LEVEL " + level;
        track = GameObject.Find("Track").GetComponent<Track>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        instantiator = GameObject.Find("EnemyInstantiator").GetComponent<EnemyCarInstantiator>();
    }

    public bool isRaceOver() { return raceOver; }

    public void playerFinish()
    {
        gameOverText.text = "YOU WON!";
        won = true;
        timeOver();
        StartCoroutine(nextLevel());
    }

    public void timeOver()
    {
        gameOverText.gameObject.SetActive(true);
        timer.gameOver = true;
        track.stopScrolling();
        raceOver = true;
        if (!won) { restartButton.gameObject.SetActive(true); }
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(3f);
        level++;
        levelDisplay.text = "LEVEL " + level;
        loadLevel();
    }

    public void loadLevel()
    {
        // correct the boolean conditions
        raceOver = false;
        won = false;

        // put car back at track start
        track.trackScale();

        // destroy all enemies and redo for new level
        instantiator.instantiateEnemy();

        // reset timer
        timer.gameOver = false;
        timer.setTimer();

        // reset and disable text overlay
        gameOverText.text = "TIME OVER";
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // reset minimap
        GameObject.Find("Player Indicator").GetComponent<MiniMapPlayerIndicator>().resetPos();
    }
}
