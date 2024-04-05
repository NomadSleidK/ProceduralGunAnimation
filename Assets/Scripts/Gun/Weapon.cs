using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileForce;

    private Recoil _weaponRecoil; 

    [SerializeField] private Transform _firePoint;

    [SerializeField] private Transform _leftHandPoint;
    [SerializeField] private Transform _rightHandPoint;

    private void Start()
    {
        _weaponRecoil = GetComponent<Recoil>();
    }

    public void AddRecoil(float value)
    {
        _weaponRecoil.PowerOfRecoil += value;
    }
    public void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddRecoil(0.1f);

            GameObject projectile = Instantiate(projectilePrefab, _firePoint.position, _firePoint.rotation);
            projectile.transform.rotation = Quaternion.LookRotation(transform.forward);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(_firePoint.forward * projectileForce, ForceMode.Impulse);
        }
    }


}
