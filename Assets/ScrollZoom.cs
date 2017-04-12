using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MBK;

public class ScrollZoom : MonoBehaviour {


    public float MinZ;
    public float MaxZ;

    float zTarget;
    float cameraArmAngleTarget;
    private float MinArmDegree;

    void Update ()
    {
        CheckScrollZoom();
	}

    private void CheckScrollZoom()
    {
        if (Input.mouseScrollDelta.y != 0f)
        {
            zTarget = transform.localPosition.z + Input.mouseScrollDelta.y * 5f;

            if (zTarget > MaxZ) zTarget = MaxZ;
            if (zTarget < MinZ) zTarget = MinZ;
            transform.DOLocalMoveZ(zTarget, 10f / 60f).SetRecyclable();

            cameraArmAngleTarget = (zTarget - MinZ)*0.5f + MinArmDegree;
            transform.parent.DOLocalRotate(transform.parent.localRotation.eulerAngles.WithX(cameraArmAngleTarget), 10f / 60f);
        }
    }
}
