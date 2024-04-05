using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileForce = 100f;

    private Transform _directionTransform;

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

        if(_rigidBody != null)
            _rigidBody.freezeRotation = true;

        _directionTransform = GameObject.FindGameObjectWithTag("Direction").transform;
    }

    private void Update()
    {
        Shooting();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float delta = Input.GetAxis("Mouse X") * speedRotating;
        float moveX = Input.GetAxis("Horizontal") * _speedMoving;
        float moveZ = Input.GetAxis("Vertical") * _speedMoving;

        rotationX -= Input.GetAxis("Mouse Y") * speedRotating;
        rotationX = Mathf.Clamp(rotationX, -45, 45);
        rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        _directionTransform.localEulerAngles = new Vector3(rotationX, 0, 0);
        
        transform.Translate(moveX, 0, moveZ);
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RecoilObject.recoil += 0.1f;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.rotation = Quaternion.LookRotation(transform.forward);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
        }
    }
}
