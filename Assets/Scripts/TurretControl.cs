using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour
{

    public Transform target;
    public float turretOffset;
    public GameObject shellPrefab;

    private Transform gunRoot;

    private Vector3 turretOriginalRotation;
    private Vector3 gunsOriginalRotation;
    private Transform gun1;
    private Transform gun2;

    private bool isFiring;
    private float lastFired;
    private int lastGun;

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

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, Time.deltaTime);

        transform.localRotation = Quaternion.Euler(turretOriginalRotation.x, transform.localRotation.eulerAngles.y + turretOffset, turretOriginalRotation.z);

        //-1x, mert fordítva van az ágyúk koordinátarendszere...
        rotationGoal = Quaternion.LookRotation(-1 * (target.position - gunRoot.position));
        gunRoot.rotation = Quaternion.Slerp(gunRoot.rotation, rotationGoal, Time.deltaTime);

        gunRoot.localRotation = Quaternion.Euler(gunRoot.localRotation.eulerAngles.x, gunsOriginalRotation.y, gunsOriginalRotation.z);

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        if (isFiring && Time.time - lastFired > 0.2)
        {
            if (lastGun == 1)
            {
                lastGun = 2;
                var shell = GameObject.Instantiate(shellPrefab);
                shell.transform.position = gun1.transform.position;
                shell.transform.rotation = gun1.transform.rotation;
                shell.transform.rotation = Quaternion.Euler(shell.transform.rotation.eulerAngles.x + shellPrefab.transform.rotation.eulerAngles.x, shell.transform.rotation.eulerAngles.y + shellPrefab.transform.rotation.eulerAngles.y, shell.transform.rotation.eulerAngles.z + shellPrefab.transform.rotation.eulerAngles.z);
                shell.GetComponent<Rigidbody>().velocity = shell.transform.up * 1000;
            }
            else
            {
                lastGun = 1;
                var shell = GameObject.Instantiate(shellPrefab);
                shell.transform.position = gun2.transform.position;
                shell.transform.rotation = gun2.transform.rotation;
                shell.transform.rotation = Quaternion.Euler(shell.transform.rotation.eulerAngles.x + shellPrefab.transform.rotation.eulerAngles.x, shell.transform.rotation.eulerAngles.y + shellPrefab.transform.rotation.eulerAngles.y, shell.transform.rotation.eulerAngles.z + shellPrefab.transform.rotation.eulerAngles.z);
                shell.GetComponent<Rigidbody>().velocity = shell.transform.up * 1000;
            }
            lastFired = Time.time;
        }
    }
}
