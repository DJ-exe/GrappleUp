using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_DestroSpawner : MonoBehaviour
{
    Level_Spawner Level_Spawner;

    void Start()
    {
        Level_Spawner = GameObject.FindObjectOfType<Level_Spawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MYCar")
        {
            Level_Spawner.SpawnLevel();
            Destroy(gameObject, 5);

        }
        if (other.gameObject.tag == "FillerCar")
        {
            Destroy(other);
        }
    }
}
