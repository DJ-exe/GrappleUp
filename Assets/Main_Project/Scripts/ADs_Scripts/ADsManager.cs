//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Advertisements;

//public class ADsManager : MonoBehaviour
//{
//    [SerializeField] RewardPlayer rewardPlayer;
//    [SerializeField] TestPlayerMotion carScript;
//    [SerializeField] ScoreSystem scoreSystem;
//    [SerializeField] End_Game endGameScript;
//    [SerializeField] Tire_animation bgRotateScript;

//    float bgRotateSpeed;
//    float temp;
//    string Adid = "Rewarded_Android";
//    [HideInInspector] public int deathCounter = 0;
//    [HideInInspector] public bool isAdFininshed = false;


//    void Start()
//    {
//        Advertisement.Initialize("4313863");
//        Advertisement.AddListener(this);
//        endGameScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<End_Game>();
//    }
//    private void Update()
//    {
//        if (carScript.speed > 0)
//        {
//            temp = carScript.speed;
//            bgRotateSpeed = bgRotateScript.Rotationspeedy;
//        }
//    }

//    public void PlayRewardedAd()
//    {
//        if (Advertisement.IsReady(Adid))
//        {
//            Advertisement.Show(Adid);
//        }
//        endGameScript.test2 = false;
//    }

//    public void OnUnityAdsReady(string placementId)
//    {
//        Debug.Log("ready");
//    }

//    public void OnUnityAdsDidError(string message)
//    {
//        Debug.Log("error");
//    }

//    public void OnUnityAdsDidStart(string placementId)
//    {
//        Debug.Log("started");
//    }

//    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
//    {
//        if (placementId == Adid && showResult == ShowResult.Finished && deathCounter > 0)
//        {
//            Debug.Log("Reward Player");
//            rewardPlayer.RewardPlayer_();
//            carScript.speed = temp - 1;
//            bgRotateScript.Rotationspeedy = bgRotateSpeed;
//            scoreSystem.isDead = false;
//            isAdFininshed = true;
//        }
//    }
//}
