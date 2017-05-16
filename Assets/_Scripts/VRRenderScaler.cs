using UnityEngine;
using UnityEngine.VR;

public class VRRenderScaler : MonoBehaviour {

    [Range(0.8f,3f)]
    [SerializeField] private float renderScale;


    private void Start()
    {
        VRSettings.renderScale = renderScale;
    }
}
