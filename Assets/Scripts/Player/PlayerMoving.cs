using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Transform _directionTransform;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Rigidbody _rigidBody;

    [SerializeField]  private float speedRotating;
    [SerializeField]  private float _speedMoving;

    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private HandsPointManger _handPointManger;

    private Weapon _activeWeapon;
    public Weapon ActiveWeapon
    {
        get { return _activeWeapon; }
        set 
        {
            if(_activeWeapon != null && _activeWeapon != value)
                _weaponManager.ResetWeapon(_activeWeapon.gameObject);
            _activeWeapon = value;
            _activeWeapon.transform.SetParent(GameObject.FindGameObjectWithTag("Direction").transform);
            _activeWeapon.transform.localPosition = Vector3.zero;

            _handPointManger.TargetLeftHandPoint = _activeWeapon.LeftHandPoint;
            _handPointManger.TargetRightHandPoint = _activeWeapon.RightHandPoint;
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ActiveWeapon = _weaponManager.GetWeapon(0).GetComponent<Weapon>();

        _rigidBody = GetComponent<Rigidbody>();

        if(_rigidBody != null)
            _rigidBody.freezeRotation = true;

        _directionTransform = GameObject.FindGameObjectWithTag("Direction").transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveWeapon = _weaponManager.GetWeapon(0).GetComponent<Weapon>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveWeapon = _weaponManager.GetWeapon(1).GetComponent<Weapon>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveWeapon = _weaponManager.GetWeapon(2).GetComponent<Weapon>();
        }

        Rotation();
        ActiveWeapon.Shooting();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
        float moveX = Input.GetAxis("Horizontal") * _speedMoving;
        float moveZ = Input.GetAxis("Vertical") * _speedMoving;
        
        transform.Translate(moveX, 0, moveZ);
        
    }

    private void Rotation()
    {
        float delta = Input.GetAxis("Mouse X") * speedRotating;

        rotationX -= Input.GetAxis("Mouse Y") * speedRotating;
        rotationX = Mathf.Clamp(rotationX, -45, 45);
        rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        _directionTransform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
