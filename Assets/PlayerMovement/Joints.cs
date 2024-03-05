using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{
    private SpringJoint joint1;
    private bool Counts = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JointLag" && Counts)
        {
            Counts = false;
            joint1 = gameObject.AddComponent<SpringJoint>();
            joint1.autoConfigureConnectedAnchor = false;
            joint1.connectedAnchor = new Vector3(-21.1456528f, 18.0641613f, 7.89005852f);

            joint1.spring = 2f;
            joint1.damper = 5f;
            joint1.massScale = 4.5f;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TriggerExit")
        {
            Destroy(joint1);
        }
    }
}
