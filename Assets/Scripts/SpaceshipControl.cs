using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipControl : MonoBehaviour
{

    public float maxThrottle = 15;
    public float maneuverabilityX = 5;
    public float maneuverabilityY = 3;
    public float maneuverabilityZ = 5;
    public float enginePower = 5;

    private float throttle = 0;

    new private Rigidbody rigidbody;

    public Text throttleText;

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            throttle = 0;
        }
        else
        {
            throttle = Mathf.Max(Mathf.Min(throttle + (throttleInput * enginePower * Time.deltaTime), maxThrottle), -1 * maxThrottle);
        }
        rigidbody.AddRelativeForce(0, 0, throttle);

        transform.Rotate(new Vector3(rotationX * maneuverabilityX, rotationY * maneuverabilityY, rotationZ * maneuverabilityZ) * Time.deltaTime, Space.Self);



        UpdateUI();
    }

    void UpdateUI()
    {
        if (throttleText != null)
        {
            throttleText.text = throttle.ToString();
        }
    }
}
