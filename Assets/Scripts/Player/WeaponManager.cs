using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List <GameObject> _weapons;
    private int _lastActiveWeapon;

    private void Awake()
    {
        foreach (GameObject weapon in _weapons)
        {
            ResetWeapon(weapon);
        }
    }

    public void ResetWeapon(GameObject weapon)
    {
        weapon.transform.SetParent(transform);
        weapon.transform.localPosition = Vector3.zero;
        weapon.SetActive(false);
    }

    public GameObject GetWeapon(int weaponId)
    {
        _weapons[weaponId].SetActive(true);
        return _weapons[weaponId];
    }
}
