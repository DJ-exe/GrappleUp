using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Game : MonoBehaviour
{
    public GameObject doYouWantToWatchAdPanel;
    public GameObject scorePanel;
    public GameObject gameOverPanel;
    public ScoreSystem scoreSystem;
    public int ScoreToCurrencyMultipliar;
    int MoneyWithPlayer;
    int temp;
    float timer;
    float timer2 = 6;
    public bool test2 = false;
    bool test = false;
    public TestPlayerMotion carScript;
    public Run playerRunScript;
    //public ADsManager adsManager;
    public RewardPlayer rewardPlayer;
    public swing Swing1;
    public Tire_animation bgRotateScript;
    Collider Collider;
    public bool isDead = false;
    [SerializeField] Text timeText;


    private void Update()
    {
        MoneyWithPlayer = (int)scoreSystem.score / ScoreToCurrencyMultipliar;
        if (test /*adsManager.isAdFininshed*/)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 0.5f)
        {
            Collider.gameObject.SetActive(true);
            timer = 0;
            test = false;
            //adsManager.isAdFininshed = false;
            Collider = null;
        }

        if (test2)
        {
            timer2 -= Time.deltaTime;
            int temp = (int)timer2;
            timeText.text = temp.ToString();
        }
        else
        {
            timer2 = 6;
        }

        if (timer2 < 0 && test2)
        {
            doYouWantToWatchAdPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            test2 = false;
            timer2 = 6;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndGameTrigger" && !isDead)
        {
            Collider = other;

            Swing1.touch = false;


            other.gameObject.SetActive(false);
            test = true;
            scoreSystem.isDead = true;
            //Gameover Canvas set active
            gameOverPanel.SetActive(true);
            //if (adsManager.deathCounter >= 1)
            //{
            //    adsManager.deathCounter = 0;
            //    PlayerPrefs.SetInt("DeathCounter", adsManager.deathCounter);
            //    test2 = false;
            //}
            //else
            //{
            //    doYouWantToWatchAdPanel.SetActive(true);
            //    adsManager.deathCounter++;
            //    PlayerPrefs.SetInt("DeathCounter", adsManager.deathCounter);
            //    test2 = true;

            //}
            scorePanel.SetActive(false);
            carScript.speed = 0;
            playerRunScript.speed = 0;
            bgRotateScript.Rotationspeedy = 0;
            PlayerPrefs.SetInt("CurrentGameMoneyWithPlayer", MoneyWithPlayer);
            temp = PlayerPrefs.GetInt("MoneyWithPlayer");
            PlayerPrefs.SetInt("MoneyWithPlayer", MoneyWithPlayer + temp);

            isDead = true;

            Destroy(Swing1.joint);
            Swing1.lr.positionCount = 0;
            Swing1.clickcount = true;
        }
    }
}
