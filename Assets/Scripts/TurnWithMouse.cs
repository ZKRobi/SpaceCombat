using UnityEngine;
using System.Collections;

public class TurnWithMouse : MonoBehaviour
{

    public float speed = 100;
    public bool X;
    public bool Y;

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Y ? -1 * mouseY : 0, X ? mouseX : 0, 0);
    }
}
