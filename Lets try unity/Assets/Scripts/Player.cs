using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;         // Movement speed in units per second
    public float jumpForce;         // Force applied upwards


    [Header("Camera")]
    public float lookSensitivity;   // Mouse look sensitivity
    public float maxLookX;          // Lowest the camera can look down
    public float minLookX;          // Highers the camera can look up
    private float rotX;             // current x position of the camera

    private Camera cam;
    private Rigidbody rig;

    void Start()
    {
        // Gets the components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        CamLook();
    }

    // Move horizontally base on movement inputs
    void Move()
    {
        // Gets the X and Z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Applies velocity
        rig.velocity = new Vector3(x, rig.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
}
