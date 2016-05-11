using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour
{

    public Transform target;
    private Transform gunRoot;
    public float turretOffset;

    private Vector3 turretOriginalRotation;
    private Vector3 gunsOriginalRotation;

    // Use this for initialization
    void Start()
    {
        gunRoot = transform.GetChild(0);
        turretOriginalRotation = transform.localRotation.eulerAngles;
        gunsOriginalRotation = gunRoot.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        var rotationGoal = Quaternion.LookRotation(target.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, Time.deltaTime);

        transform.localRotation = Quaternion.Euler(turretOriginalRotation.x, transform.localRotation.eulerAngles.y + turretOffset, turretOriginalRotation.z);

        //-1x, mert fordítva van az ágyúk koordinátarendszere...
        rotationGoal = Quaternion.LookRotation(-1 * (target.position - gunRoot.position));
        gunRoot.rotation = Quaternion.Slerp(gunRoot.rotation, rotationGoal, Time.deltaTime);

        gunRoot.localRotation = Quaternion.Euler(gunRoot.localRotation.eulerAngles.x, gunsOriginalRotation.y, gunsOriginalRotation.z);
    }
}
