using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    float walkMoveStopRadius = 0.2f;
    [SerializeField]
    float attackMoveStopRadius = 5f;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentDestination;
        
    bool isIndirectMode = false;
    private Vector3 clickPoint;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.G)) // TODO G for gamepad  allow player to map later
        {
            isIndirectMode = !isIndirectMode;
            currentDestination = transform.position;
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
            clickPoint = cameraRaycaster.hit.point;
            switch (cameraRaycaster.currentLayerHit)
            {
                case Layer.Walkable:
                    currentDestination = ShortDestination(clickPoint, walkMoveStopRadius);

                    break;
                case Layer.Enemy:
                    currentDestination = ShortDestination(clickPoint, attackMoveStopRadius);

                    break;
                case Layer.RaycastEndStop:
                    break;
                default:
                    print("this shouldn't happen");
                    break;
            }
        }

        WalkToDestination();

    }

    private void WalkToDestination()
    {
        var playerToClickPoint = currentDestination - transform.position;
        if (playerToClickPoint.magnitude >= 0.1f)
        {
            m_Character.Move(currentDestination - transform.position, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }

    Vector3 ShortDestination(Vector3 dest, float shortening)
    {
        Vector3 reductionVect = (dest - transform.position).normalized * shortening;
        return dest - reductionVect;
    }

    private void OnDrawGizmos()
    {
        // visualize walk target
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, currentDestination);
        Gizmos.DrawSphere(currentDestination, 0.05f);
        Gizmos.DrawSphere(clickPoint, 0.1f);
    }
}

