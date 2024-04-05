using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Transform _cameraTransform;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Rigidbody _rigidBody;

    [SerializeField]  private float speedRotating;
    [SerializeField]  private float _speedMoving;
    [SerializeField] private Recoil RecoilObject;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rigidBody = GetComponent<Rigidbody>();
        _cameraTransform = GameObject.FindGameObjectWithTag("Direction").transform;
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
        float moveX = Input.GetAxis("Horizontal") * _speedMoving;
        float moveZ = Input.GetAxis("Vertical") * _speedMoving;
        transform.Translate(moveX * Time.deltaTime, 0, moveZ * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RecoilObject.recoil += 0.1f;
        }
    }
}
