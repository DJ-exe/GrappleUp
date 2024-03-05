using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public LineRenderer lr;
    public SpringJoint joint;
    private Vector3 destiny;
    private bool hitinfo;
    [SerializeField]
    private Transform tip;
    private float offset = 1f;
    public bool clickcount = true;
    private bool Yn = false;
    public bool touch = true;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickcount)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycasthit))
                {
                    destiny = raycasthit.point;
                    if (raycasthit.collider.tag == "building")
                    {
                        hitinfo = true;
                    }

                }
                if (hitinfo && touch)
                {
                    Yn = true;
                    SpringSpawn();
                    hitinfo = false;
                    clickcount = false;
                }
            }
            else
            {
                Destroy(joint);
                lr.positionCount = 0;
                clickcount = true;
            }
        }
    }
    private void LateUpdate()
    {
        drawline();
    }

    void drawline()
    {
        if (!joint) return;

        if (Yn)
        {
            lr.SetPosition(0, tip.position);
            lr.SetPosition(1, destiny);
        }
    }
    void SpringSpawn()
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = new Vector3(0, -0.328388542f, 0);
        joint.connectedAnchor = new Vector3(destiny.x, destiny.y, destiny.z + offset);

        float distancefrompoint = Vector3.Distance(tip.position, new Vector3(destiny.x, destiny.y, destiny.z + offset));
        joint.maxDistance = distancefrompoint * 0.76f;
        joint.minDistance = distancefrompoint * 0.25f;

        joint.spring = 5f;
        joint.damper = 2f;
        joint.massScale = 3.5f;
        lr.positionCount = 2;
    }

}