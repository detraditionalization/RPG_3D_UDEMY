using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    
    private CameraRaycaster cr;

    [SerializeField]
    private Vector2 cursorHotspot = new Vector2(96,96);

    [SerializeField]
    Texture2D walkCursor = null;
    [SerializeField]
    Texture2D enemyCursor = null;
    [SerializeField]
    Texture2D unknownCursor = null;

    private void Awake()
    {
        cr = Camera.main.GetComponent<CameraRaycaster>();
    }

    private void OnEnable()
    {
        cr.OnLayerChange += HandleOnLayerChange;
    }

    private void OnDisable()
    {
        cr.OnLayerChange -= HandleOnLayerChange;
    }

    private void HandleOnLayerChange(Layer layer)
    {
        switch (layer)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("Don't know what cursor to show");
                break;
        }
    }
}
