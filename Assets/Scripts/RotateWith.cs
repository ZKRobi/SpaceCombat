using UnityEngine;
using System.Collections;

public class RotateWith : MonoBehaviour
{
    public Transform target;

    public bool X;
    public bool Y;
    public bool Z;

    public Vector3 offset;

    public bool applyLimits;
    public Vector3 minimalRotation;
    public Vector3 maximalRotation;

    // Update is called once per frame
    void Update()
    {
        float rotationX = X ? target.rotation.eulerAngles.x + offset.x : transform.rotation.eulerAngles.x;
        float rotationY = Y ? target.rotation.eulerAngles.y + offset.y : transform.rotation.eulerAngles.y;
        float rotationZ = Z ? target.rotation.eulerAngles.z + offset.z : transform.rotation.eulerAngles.z;

        if (rotationX > 360)
        {
            rotationX -= 360;
        }
        if (rotationY > 360)
        {
            rotationY -= 360;
        }
        if (rotationZ > 360)
        {
            rotationZ -= 360;
        }


        if (applyLimits)
        {
            if (minimalRotation.x >= 0)
            {
                rotationX = Mathf.Min(maximalRotation.x, Mathf.Max(minimalRotation.x, rotationX));
            }
            else if (!(rotationX > (360 + minimalRotation.x)))
            {
                rotationX = Mathf.Min(maximalRotation.x, rotationX);
            }

            if (minimalRotation.y >= 0)
            {
                rotationY = Mathf.Min(maximalRotation.y, Mathf.Max(minimalRotation.y, rotationY));
            }
            else if (!(rotationY > (360 + minimalRotation.y)))
            {
                rotationY = Mathf.Min(maximalRotation.y, rotationY);
            }


            if (minimalRotation.z >= 0)
            {
                rotationZ = Mathf.Min(maximalRotation.z, Mathf.Max(minimalRotation.z, rotationZ));
            }
            else if (!(rotationZ > (360 + minimalRotation.z)))
            {
                rotationZ = Mathf.Min(maximalRotation.z, rotationZ);
            }
        }

        transform.rotation = transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
