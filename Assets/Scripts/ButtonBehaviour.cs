using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void RestartButtonPress()
    {
        SceneManager.LoadScene("Task1");
    }

    public void PauseButtonPress()
    {
        if (Time.timeScale == 1) { Time.timeScale = 0; }
        else { Time.timeScale = 1; }
    }

}
