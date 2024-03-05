using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public GameObject camera_;
    public GameObject car_;
    public Vector3 Camera_Offset;


    void Update()
    {
        if (car_ == null)
        {
            car_ = GameObject.FindGameObjectWithTag("MYCar");
            return;
        }
        else
        {
            camera_.transform.position = car_.transform.position + Camera_Offset;
        }
    }
}
