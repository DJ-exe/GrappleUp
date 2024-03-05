using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text ScoreText;
    public Text highScoreText;
    public float score;
    public int highScore;
    public float multiplier_ = 4f;
    public bool isDead = false;

    public void Start()
    {
        //highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if(!isDead)
        {
            //ScoreText.text = PlayerTransform.position.z.ToString("0");
            score += Time.deltaTime * multiplier_;
            ScoreText.text = score.ToString("0");

            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
            }
        }
    }
}
