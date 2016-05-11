using UnityEngine;
using System.Collections;

public class FollowItem : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Megfordítjuk az offsetet jobbklikkre
        if (Input.GetMouseButtonDown(1))
        {
            offset = -1 * offset;
        }

        transform.position = target.position;
        transform.Translate(offset, target);
    }
}
