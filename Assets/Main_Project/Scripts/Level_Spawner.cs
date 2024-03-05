using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Spawner : MonoBehaviour
{
    public GameObject[] LevelPrefabs;
    public int SpawnNum = 2;
    Vector3 NextSpanwpoint;

    void Start()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            SpawnLevel();
        }
    }

    public void SpawnLevel()
    {
        GameObject Temp = Instantiate(LevelPrefabs[Random.Range(0, LevelPrefabs.Length)], NextSpanwpoint, Quaternion.identity);
        NextSpanwpoint = Temp.transform.GetChild(0).transform.position;

    } 
}
