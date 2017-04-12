using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    float walkMoveStopRadius = 0.2f;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
        
    bool isIndirectMode = false;


    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.G)) // TODO G for gamepad  allow player to map later
        {
            isIndirectMode = !isIndirectMode;
            currentClickTarget = transform.position;
        }

        if (isIndirectMode)
        {
            KeyboardMovement();
        }
        else
        {
            MouseMovement();
        }

    }

    private void KeyboardMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // calculate camera relative direction to move
        Vector3 camForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1,0,1).normalized);
        Vector3 move = (v * camForward + h * Camera.main.transform.right).normalized;

        m_Character.Move(move, false, false);
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButton(0))
        {

            switch (cameraRaycaster.currentLayerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    m_Character.Move(currentClickTarget - transform.position, false, false);
                    break;
                case Layer.Enemy:                    
                    break;
                case Layer.RaycastEndStop:
                    break;
                default:
                    print("this shouldn't happen");
                    break;
            }
        }
        var playerToClickPoint = currentClickTarget - transform.position;
        if (playerToClickPoint.sqrMagnitude >= walkMoveStopRadius)
        {
            m_Character.Move(currentClickTarget - transform.position, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}

