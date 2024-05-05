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
    private Weapon weapon;

    void Start()
    {
        // Gets the components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();

        // disables cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
            TryJump();

        if(Input.GetButton("Fire1"))
        {
            if (weapon.CanShoot())
                weapon.Shoot();
        }

        CamLook();
    }

    // Move horizontally base on movement inputs
    void Move()
    {
        // Gets the X and Z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rig.velocity.y;

        // Applies velocity
        rig.velocity = dir;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }


        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //sprinting = false;
            moveSpeed /= 2;
        }
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void TryJump()
    {
        // Creates a ray cast that shoots downwards
        Ray ray = new Ray(transform.position, Vector3.down);

        // Detects if the ray cast hits an object and decides if up force is applied to the player
        if(Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
