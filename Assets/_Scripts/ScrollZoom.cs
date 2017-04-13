using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MBK;

public class ScrollZoom : MonoBehaviour {

    [Range(0.5f,5f)]
    public float ScrollSpeed;

    public float MinZ;
    public float MaxZ;

    float zTarget;
    float cameraArmAngleTarget;

    public float MinArmDegree;
    public float MaxArmDegree;

    void Update ()
    {
        CheckScrollZoom();
	}

    private void CheckScrollZoom()
    {
        if (Input.mouseScrollDelta.y != 0f)
        {
            zTarget = transform.localPosition.z + Input.mouseScrollDelta.y * ScrollSpeed;

            if (zTarget > MaxZ) zTarget = MaxZ;
            if (zTarget < MinZ) zTarget = MinZ;
            transform.DOLocalMoveZ(zTarget, 10f / 60f).SetRecyclable();

            cameraArmAngleTarget = Utility.InverseMap(zTarget, MinZ, MaxZ, MinArmDegree, MaxArmDegree);
            //transform.parent.localEulerAngles = transform.parent.localEulerAngles.WithX(cameraArmAngleTarget);
            transform.parent.DOLocalRotate(transform.parent.localEulerAngles.WithX(cameraArmAngleTarget), 6f / 60f).SetRecyclable();
                
            
        }
    }
}
