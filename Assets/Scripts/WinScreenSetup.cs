using UnityEngine;

public class WinScreenSetup : MonoBehaviour
{
    public float distance = 2f;

    void Start()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        transform.position = cam.transform.position + cam.transform.forward * distance;
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}