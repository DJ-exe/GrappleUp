using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public void ContinueButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.5f;
    }
}
