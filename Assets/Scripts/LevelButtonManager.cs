using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject ball;
    private ObstacleInstantiator instantiator;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        instantiator = (ObstacleInstantiator)FindObjectOfType(typeof(ObstacleInstantiator));

        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        int levelNumber = int.Parse(btn.GetComponentInChildren<Text>().text.ToString());
        if (levelNumber > 15) { instantiator.CreateAllObstacles(); }

        ball.SetActive(true);
        ball.GetComponent<BallB>().level = levelNumber;
        ball.GetComponent<BallB>().StartGame();
    }
}
