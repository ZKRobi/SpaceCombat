using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour
{
    public float maxDistance = 3000;

    private Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - startingPos).magnitude > maxDistance)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
