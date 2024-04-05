using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private float maxAngleRecoil_x;
    [SerializeField] private float maxAngleRecoil_y;

    [SerializeField] private float maxTrans_x;
    [SerializeField] private float maxTrans_z;

    [SerializeField] private float recoilSpeed;
    [SerializeField] private float _powerOfRecoil;
    public float PowerOfRecoil
    {
        get
        {
            return _powerOfRecoil;
        }
        set
        {
            _powerOfRecoil = value;
        }
    }

    void Update()
    {
        
        Recoiling();
    }

    private void Recoiling()
    {
        if (_powerOfRecoil > 0)
        {
            var maxRecoil = Quaternion.Euler(
                Random.Range(transform.localRotation.x, maxAngleRecoil_x),
                Random.Range(transform.localRotation.y, Random.Range(-maxAngleRecoil_y, maxAngleRecoil_y)),
                transform.localRotation.z);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);

            var maxTranslation = new Vector3(
                Random.Range(transform.localPosition.x, Random.Range(-maxTrans_x, maxTrans_x)),
                transform.localPosition.y,
                Random.Range(transform.localPosition.z, maxTrans_z));

            transform.localPosition = Vector3.Slerp(transform.localPosition, maxTranslation, Time.deltaTime * recoilSpeed);
            _powerOfRecoil -= Time.deltaTime;
        }

        else
        {
            _powerOfRecoil = 0;
            var minRecoil = Quaternion.Euler(
                Random.Range(0, transform.localRotation.x),
                Random.Range(0, transform.localRotation.y),
                transform.localRotation.z);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, minRecoil, Time.deltaTime * recoilSpeed / 2);

            var minTranslation = new Vector3(
                Random.Range(0, transform.localPosition.x),
                transform.localPosition.y,
                Random.Range(0, transform.localPosition.z));

            transform.localPosition = Vector3.Slerp(transform.localPosition, minTranslation, Time.deltaTime * recoilSpeed);
        }
    }
}
