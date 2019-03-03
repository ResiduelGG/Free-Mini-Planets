using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject levelChanger;
    public GameObject GM;
    public int endScore;
    public Text endScoreText;

    // Update is called once per frame
    void Update()
    {
        endScore = GM.GetComponent<GM>().getScore();
        endScoreText.text = endScore.ToString();
    }

    public void resetGame() {
        levelChanger.GetComponent<LevelChanger>().changeSceneTo(0);
    }

    public void resetScore() {
        endScore = 0;
        levelChanger.GetComponent<LevelChanger>().changeSceneTo(0);
    }
}
