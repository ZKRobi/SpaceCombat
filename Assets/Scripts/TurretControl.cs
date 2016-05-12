using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour
{

    public Transform target;

    public GameObject shellPrefab;

    public float turretCenter;
    //Negatív szám!
    public float negativeMaxTurretRotation;
    public float positiveMaxTurretRotation;

    private Transform gunRoot;

    private Vector3 turretOriginalRotation;
    private Vector3 gunsOriginalRotation;
    private Transform gun1;
    private Transform gun2;

    private bool isFiring;
    private float lastFired;
    private int lastGun;

    [HideInInspector]
    public bool IsAimed
    {
        get; private set;
    }

    // Use this for initialization
    void Start()
    {
        gunRoot = transform.GetChild(0);
        turretOriginalRotation = transform.localRotation.eulerAngles;
        gunsOriginalRotation = gunRoot.localRotation.eulerAngles;

        gun1 = gunRoot.GetChild(0);
        gun2 = gunRoot.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        var rotationGoal = Quaternion.LookRotation(target.position - transform.position);

        transform.rotation = rotationGoal; // Quaternion.Slerp(transform.rotation, rotationGoal, Time.deltaTime);

        IsAimed = true;

        float yRotation = transform.localRotation.eulerAngles.y;
        float minimumRotation = turretCenter + negativeMaxTurretRotation;
        float maximumRotation = turretCenter + positiveMaxTurretRotation;


        //Valójában nem ez a két eset van, de most elég
        if (minimumRotation > 0)
        {
            if (yRotation < minimumRotation)
            {
                yRotation = turretCenter;
                IsAimed = false;
            }
            else if (yRotation > maximumRotation)
            {
                yRotation = turretCenter;
                IsAimed = false;
            }
        }
        else
        {
            if (yRotation > maximumRotation && yRotation < (360 + minimumRotation))
            {
                yRotation = turretCenter;
                IsAimed = false;
            }
        }

        transform.localRotation = Quaternion.Euler(turretOriginalRotation.x, yRotation, turretOriginalRotation.z);

        //-1x, mert fordítva van az ágyúk koordinátarendszere...
        rotationGoal = Quaternion.LookRotation(-1 * (target.position - gunRoot.position));
        gunRoot.rotation = rotationGoal; // Quaternion.Slerp(gunRoot.rotation, rotationGoal, Time.deltaTime);

        gunRoot.localRotation = Quaternion.Euler(gunRoot.localRotation.eulerAngles.x, gunsOriginalRotation.y, gunsOriginalRotation.z);

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        if (isFiring && IsAimed && Time.time - lastFired > 0.2)
        {
            if (lastGun == 1)
            {
                lastGun = 2;
                var shell = GameObject.Instantiate(shellPrefab);
                shell.transform.position = gun1.transform.position;
                shell.transform.rotation = gun1.transform.rotation;

                //-1000, mert fordítva állnak az ágyúk
                shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * -1000;
            }
            else
            {
                lastGun = 1;
                var shell = GameObject.Instantiate(shellPrefab);
                shell.transform.position = gun2.transform.position;
                shell.transform.rotation = gun2.transform.rotation;

                //-1000, mert fordítva állnak az ágyúk
                shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * -1000;
            }
            lastFired = Time.time;
        }
    }
}
