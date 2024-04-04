using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Transform _cameraTransform;
    // rotating fields
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float speedRotating = 7.0f;
    // moving fields
    private float speedMoving = 8.5f;

    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        _cameraTransform = GameObject.FindGameObjectWithTag("Direction").transform;

        if (rigidBody != null)
        {
            rigidBody.freezeRotation = true;
        }
    }

    void Update()
    {
        // rotating
        rotationX -= Input.GetAxis("Mouse Y") * speedRotating;
        rotationX = Mathf.Clamp(rotationX, -45, 45);
        float delta = Input.GetAxis("Mouse X") * speedRotating;
        rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        _cameraTransform.localEulerAngles = new Vector3(rotationX, 0, 0);
        // moving
        float moveX = Input.GetAxis("Horizontal") * speedMoving;
        float moveZ = Input.GetAxis("Vertical") * speedMoving;
        transform.Translate(moveX * Time.deltaTime, 0, moveZ * Time.deltaTime);
    }
}
