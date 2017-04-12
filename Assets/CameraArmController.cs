using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBK;
using UnityEngine.EventSystems;

public class CameraArmController : MonoBehaviour {
    private float _lastMouseX;
    [Range(0.01f,1f)]
    public float Sensitivity;

    private void Update()
    {
        CheckCameraTurn();
    }

    private void CheckCameraTurn()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _lastMouseX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(2))
        {
            TurnCameraArm((Input.mousePosition.x - _lastMouseX)*Sensitivity);
            _lastMouseX = Input.mousePosition.x;
        }
    }    

    public void TurnCameraArm(float degrees)
    {        
        transform.localEulerAngles += Vector3.zero.WithY(degrees);
    }
}
