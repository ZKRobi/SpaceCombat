using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed = 200;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);
    }
}
