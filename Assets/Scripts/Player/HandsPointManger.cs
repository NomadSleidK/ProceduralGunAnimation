using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsPointManger : MonoBehaviour
{
    [SerializeField] private GameObject _leftHandPoint;
    [SerializeField] private GameObject _rightHandPoint;


    private GameObject _targetLeftHandPoint;
    public GameObject TargetLeftHandPoint
    {
        get { return _targetLeftHandPoint; }
        set
        {
            if (value != _targetLeftHandPoint)
                _targetLeftHandPoint = value;
        }
    }
    private GameObject _targetRightHandPoint;
    public GameObject TargetRightHandPoint
    {
        get { return _targetRightHandPoint; }
        set
        {
            if (value != _targetRightHandPoint)
                _targetRightHandPoint = value;
        }
    }

    private void Update()
    {
        if (_targetLeftHandPoint != null)
        {
            _leftHandPoint.transform.position = _targetLeftHandPoint.transform.position;
            _leftHandPoint.transform.rotation = _targetLeftHandPoint.transform.rotation;
        }
            
        if (_targetRightHandPoint != null)
        {
            _rightHandPoint.transform.position = _targetRightHandPoint.transform.position;
            _rightHandPoint.transform.rotation = _targetRightHandPoint.transform.rotation;
        }

    }
}
