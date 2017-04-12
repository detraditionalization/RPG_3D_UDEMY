using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {


    private void Update()
    {
        CheckForClickMove();
    }

    private void CheckForClickMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log(hit.point);
                transform.position = hit.point;

            }
        }
        
    }
}
