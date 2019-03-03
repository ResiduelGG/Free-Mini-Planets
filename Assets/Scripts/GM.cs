using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GM : MonoBehaviour
{

    public GameObject levelChanger;
    public GameObject planetFormation;
    public static bool GameIsPaused = true;
    public GameObject controlsOverlayUI;
    public GameObject scoreOverlayUI;
    public GameObject gameOverOverlayUI;
    public static int score = 0;
    public Text scoreText;
    private AudioSource music;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverOverlayUI.SetActive(false);
        scoreOverlayUI.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (!gameOver && GameIsPaused && Input.GetKeyUp(KeyCode.Mouse0)) {
            Resume();
        }
    }

    void Resume() {
        controlsOverlayUI.SetActive(false);
        scoreOverlayUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GetComponent<SpawnAsteroids>().startSpawningAsteroids();
        planetFormation.GetComponent<FreePlanetsMovement>().startMoving();
    }

    void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver() {
        gameOver = true;
        scoreOverlayUI.SetActive(false);
        gameOverOverlayUI.SetActive(true);

        Pause();
    }

    public int getScore() {
        return score;
    }

    public void IncreaseScore() {
        score = score + 1;
    }
}
