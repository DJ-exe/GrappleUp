using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Jforce = 5f;
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpPad")
        {
            rb.AddForce(0, Jforce , 0, ForceMode.Impulse);
        }
    }

}
