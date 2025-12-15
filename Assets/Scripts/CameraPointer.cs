using Cinemachine;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private CinemachineBrain _cinemachineBrain;
    private RaycastHit _raycastHit;
    public Camera OutputCamera { get; private set; }
    public Ray CameraRay { get; private set; }
    public RaycastHit Hit => _raycastHit;

    private void Awake() => _cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();

    public bool ShootRay()
    {
        OutputCamera = _cinemachineBrain.OutputCamera;
        if (OutputCamera == null)
            return false;

        CameraRay = OutputCamera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(CameraRay, out _raycastHit);
    }
}
