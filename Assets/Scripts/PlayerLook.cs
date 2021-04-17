using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerLook : NetworkBehaviour
{
    

    public Camera cam;

    public Transform playerBody;
    public float mouseSensetivity = 100f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            if(Input.GetButtonDown("Cancel"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
}
