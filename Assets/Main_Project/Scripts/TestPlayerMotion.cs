using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMotion : MonoBehaviour
{
    public float speed = 5f;
    public float maxSpeed = 20;
    float minSpeed = 9;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        Time.timeScale = 1.5f;
        Vector3 ForwardMotion = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + ForwardMotion);
        if(speed < maxSpeed  && speed != 0)
        {
            speed += Time.deltaTime / 300;
        }

        if(speed < minSpeed && speed != 0)
        {
            speed = minSpeed;
        }

    }
}
