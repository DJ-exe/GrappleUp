using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject DoYouWantToWatchAdsPanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Transform respwanPosi;
    [SerializeField] End_Game endGameScript;
    [SerializeField] swing swingScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHips");
        endGameScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<End_Game>();
        swingScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<swing>();
    }

    //public void RewardPlayer_()
    //{
    //    if (player != null)
    //    {
    //        player.transform.position = respwanPosi.position;
    //        DoYouWantToWatchAdsPanel.SetActive(false);
    //        GameOverPanel.SetActive(true);
    //        endGameScript.isDead = false;
    //        swingScript.touch = true;
    //        Time.timeScale = 1.5f;
    //    }
    //}

}
