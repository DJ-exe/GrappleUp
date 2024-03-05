using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSceneUIManager : MonoBehaviour
{
    public GameObject gameScenePanel;
    public GameObject pauseMenuPanel;
    public Text Score;
    public Text HighScore;
    public Text MoneyWithPlayer;
    public ScoreSystem scoreSystem;
    int score;
    public swing swingScript;

    private void Start()
    {
        swingScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<swing>();
    }


    private void Update()
    {
        score = (int)scoreSystem.score;
        Score.text = score.ToString();
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        MoneyWithPlayer.text = "$ " + PlayerPrefs.GetInt("CurrentGameMoneyWithPlayer").ToString();
    }

    public void PauseGame()
    {
        swingScript.touch = false;
        Time.timeScale = 0;
        gameScenePanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        swingScript.touch = true;
        Time.timeScale = 1.5f;
        gameScenePanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
