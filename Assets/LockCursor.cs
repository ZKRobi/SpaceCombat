using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour
{
    public GameObject crosshair;
    TurnWithMouse turnWithMouse;

    void Start()
    {
        turnWithMouse = GetComponent<TurnWithMouse>();
    }

    void DoLockCursor()
    {
        crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        turnWithMouse.enabled = true;

    }
    void UnlockCursor()
    {
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        turnWithMouse.enabled = false;
    }

    private bool wasLocked = false;
    private bool shouldBeLocked = true;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            shouldBeLocked = !shouldBeLocked;
        }

        if (wasLocked && !shouldBeLocked)
        {
            wasLocked = false;
            UnlockCursor();
        }
        else if (!wasLocked && shouldBeLocked)
        {
            wasLocked = true;
            DoLockCursor();
        }
    }
}
