using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;

    private CameraActionController _cameraActionController;

    private void Awake()
    {
        Queue<CinemachineVirtualCamera> camerasQueue = new Queue<CinemachineVirtualCamera>(_virtualCameras);
        CameraSwitcher cameraSwitcher = new CameraSwitcher(camerasQueue);

        _cameraActionController = new CameraActionController(_inputManager, cameraSwitcher);
    }

    private void Update() => _cameraActionController.Update();
}
