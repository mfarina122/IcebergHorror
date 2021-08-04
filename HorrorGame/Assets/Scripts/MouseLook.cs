using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    public float mouseSensitivity = 300f;
    [SerializeField]
    public Transform playerBody;
    [SerializeField]
    float xRotation = 0f;
    //Better not have any trouble with the Cursor, so let's just lock it
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    //With this script, we're gonna let the camera turn around and watch everything
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
