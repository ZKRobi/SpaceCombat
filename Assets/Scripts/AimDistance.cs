using UnityEngine;
using System.Collections;

public class AimDistance : MonoBehaviour
{
    public float maxDistance = 10000;
    private Transform aimTarget;

    // Use this for initialization
    void Start()
    {
        aimTarget = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            aimTarget.localPosition = new Vector3(0, 0, hit.distance);
        }
        else
        {
            aimTarget.localPosition = new Vector3(0, 0, maxDistance);
        }
    }
}
