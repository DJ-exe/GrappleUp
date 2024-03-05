using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public CharacterSelector CharacterSelector;
    public AudioSource[] audioSource;
    //bool isMute = true;
    GameObject _camera;
    public Slider volumeSlider;
    public GameObject muteButton;
    public GameObject unmuteButton;
    [SerializeField] Camera cam;
    int temp = 0;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");

        //isMute = intToBool(PlayerPrefs.GetInt("IsMute"));
        //MuteAudio();
        //UnmuteAudio();
        //Debug.Log(isMute);
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = PlayerPrefs.GetFloat("Volume");
        }

        //Debug.Log(PlayerPrefs.GetInt("IsMute"));
        //isMute = intToBool(PlayerPrefs.GetInt("IsMute"));
    }

    public void StartGame()
    {
        temp = PlayerPrefs.GetInt("temp");
        if(temp == 0)
        {
            SceneManager.LoadScene("TutorialScene");
            temp++;
            PlayerPrefs.SetInt("temp", temp);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1.5f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    //public void MuteAudio()
    //{
    //    if(isMute)
    //    {
    //        audioSource.mute = true;
    //        isMute = false;
    //        PlayerPrefs.SetInt("IsMute", boolToInt(isMute));
    //        Debug.Log(isMute);
    //        muteButton.SetActive(false);
    //        unmuteButton.SetActive(true);
    //    }
    //}

    //public void UnmuteAudio()
    //{
    //    if (!isMute)
    //    {
    //        audioSource.mute = false;
    //        isMute = true;
    //        PlayerPrefs.SetInt("IsMute", boolToInt(isMute));
    //        muteButton.SetActive(true);
    //        unmuteButton.SetActive(false);
                            
    //    }
    //}

    public void saveData()
    {
        SaveSystem.SaveShopData(CharacterSelector);
    }

    public void LoadData()
    {
        ShopData data = SaveSystem.loadPlayer(CharacterSelector);
        if (data != null)
        {
            for (int i = 0; i < CharacterSelector.ShopItemsList.Count; i++)
            {
                CharacterSelector.ShopItemsList[i].price = data.price[i];
                CharacterSelector.ShopItemsList[i].isEquiped = data.isEquiped[i];
                CharacterSelector.ShopItemsList[i].isPurchased = data.isPurchased[i];
            }
            CharacterSelector.moneyWithPlayer = data.moneyWithPlayer;
        }

    }

    public void CameraFalse()
    {
        cam.enabled = false;
    }

    public void CameraTrue()
    {
        cam.enabled = true;
    }

    //int boolToInt(bool val)
    //{
    //    if (val)
    //    {
    //        return 1;
    //    }
    //    else
    //    {
    //        return 0;
    //    } 
    //}

    //bool intToBool(int val)
    //{
    //    if (val != 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
