using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed = 5;
    [SerializeField]
    private Animator anime;
    private Collider[] RagdollColliders;
    [SerializeField]
    private Collider Thiscol;

    private void Awake()
    {
        RagdollColliders = GetComponentsInChildren<Collider>(true);
        foreach(var col in RagdollColliders)
        {
            col.enabled = false;
        }
    }
    private void Start()
    {
        Thiscol.enabled = true;
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpPad")
        {
            anime.enabled=false;
            foreach (var col in RagdollColliders)
            {
                col.enabled = true;
            }
        }
    }

}
