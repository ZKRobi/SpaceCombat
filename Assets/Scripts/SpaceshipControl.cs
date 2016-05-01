using UnityEngine;
using System.Collections;

public class SpaceshipControl : MonoBehaviour
{

    public float enginePower = 30;
    public float maneuverabilityX = 10;
    public float maneuverabilityY = 5;
    public float maneuverabilityZ = 10;
    private float throttle = 0;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float throttleInput = Input.GetAxis("Throttle");
        float rotationX = Input.GetAxis("Vertical");
        float rotationZ = -1 * Input.GetAxis("Horizontal");
        float rotationY = Input.GetAxis("Jaw");
        
        throttle = enginePower * throttleInput;

        rigidbody.AddRelativeForce(0, 0, throttle);

        transform.Rotate(new Vector3(rotationX * maneuverabilityX, rotationY*maneuverabilityY, rotationZ * maneuverabilityZ) * Time.deltaTime, Space.Self);
    }
}
