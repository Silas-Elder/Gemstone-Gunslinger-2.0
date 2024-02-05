using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform cam;
    public float sens;
    public float camSens;
    float camRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

        camRotation -= MouseY * camSens;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);

        cam.localEulerAngles = Vector3.right * camRotation;

        transform.Rotate(Vector3.up * MouseX);
    }
}
