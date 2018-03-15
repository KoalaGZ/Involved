using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;

    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float mouseSensitivity = 250f;
    private float verticallookRotation;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;

	}
	
	// Update is called once per frame
	void Update () {

        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * yMov;
        Vector3 movUp = transform.up * zMov;
        velocity = (movHor + movVer + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticallookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        verticallookRotation = Mathf.Clamp(verticallookRotation, -90, 45);
        cam.localEulerAngles = Vector3.left * verticallookRotation;
    }

    private void FixedUpdate()
    {
        if (velocity  !=  Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
