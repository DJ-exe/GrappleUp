using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLoader : MonoBehaviour
{
    public GameObject[] characterPrefab;
    public Transform spwanPoint;
    public int selectedcharacter;

    void Awake()
    {
        selectedcharacter = PlayerPrefs.GetInt("SelectedCharacter");

        for (int i = 0; i < characterPrefab.Length; i++)
        {
            if(selectedcharacter == i)
            {
                characterPrefab[selectedcharacter].SetActive(true);
            }
            else
            {
                characterPrefab[i].SetActive(false);
            }
        }
    }
}
