using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject ball;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        int levelNumber = int.Parse(btn.GetComponentInChildren<Text>().text.ToString());
        ball.SetActive(true);
        ball.GetComponent<BallB>().level = levelNumber;
    }
}
