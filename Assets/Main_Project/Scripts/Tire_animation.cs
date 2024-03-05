using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire_animation : MonoBehaviour
{
    public float Rotationspeedx = 180;
    public float Rotationspeedy = 0;
    public float Rotationspeedz = 0;

    void Update()
    {
        Vector3 TireRotation = new Vector3(Rotationspeedx, Rotationspeedy, Rotationspeedz);
        transform.Rotate(TireRotation * Time.deltaTime);
    }
}
