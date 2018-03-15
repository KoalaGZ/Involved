using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public Transform playerBody;
    public float mouseSensitivity;

    float xAxisClamp = 0.0f;

    [SerializeField] Vector3 targetRotCam;
    [SerializeField] float rotAmountY;
    [SerializeField] float rotAmountX;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        RotateCamera();
	}

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotAmountX = mouseX * mouseSensitivity;
        rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotCam.y += rotAmountX;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);

    }

}
