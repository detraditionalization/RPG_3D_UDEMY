using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MBK;



public class SunRotation : MonoBehaviour {
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    Gradient SunColor;
    [SerializeField]
    bool IsRotating;

    private Light lgt;

    Transform tr;

    private void Awake()
    {
        tr = transform;
        lgt = GetComponent<Light>();
    }

    private void LateUpdate()
    {
        if (IsRotating)
            tr.Rotate(Vector3.right, RotationSpeed * Time.smoothDeltaTime);
        lgt.color = SunColor.Evaluate((tr.rotation.eulerAngles.x % 360f) / 360f);        
    }

}
