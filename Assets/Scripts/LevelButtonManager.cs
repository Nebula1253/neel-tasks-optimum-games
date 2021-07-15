using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject ball, container, movingObstacle;
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
        decideSpeed(levelNumber);
        ball.GetComponent<BallB>().StartGame();
    }

    void decideSpeed(int levelNumber)
    {
        BallB ballScript = ball.GetComponent<BallB>();
        ContainerA containerScript = container.GetComponent<ContainerA>();
        MovingObstacle[] obstacleScripts = (MovingObstacle[]) FindObjectsOfType(typeof(MovingObstacle));

        int levelOffset = levelNumber % 5;
        
        if (levelOffset > 0)
        {
            ballScript.horizontalSpeed += (ballScript.speedIncrease * (levelOffset - 1));
            containerScript.speed += (containerScript.speedIncrease * (levelOffset - 1));
            foreach(MovingObstacle obstacleScript in obstacleScripts)
            {
                obstacleScript.speed += (obstacleScript.speedIncrease * (levelOffset - 1));
            }
        }
        else
        {
            ballScript.horizontalSpeed += (ballScript.speedIncrease * 5);
            containerScript.speed += (containerScript.speedIncrease * 5);
            foreach (MovingObstacle obstacleScript in obstacleScripts) { obstacleScript.speed += (obstacleScript.speedIncrease * 4); }
        }
    }
}
