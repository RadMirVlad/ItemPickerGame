using Cinemachine;
using System.Collections.Generic;

public class CameraSwitcher
{
    private Queue<CinemachineVirtualCamera> _virtualCameras;

    private int _currentCameraPriority = 10;
    private int _switchedOffCameraPriority = 0;

    public CameraSwitcher(Queue<CinemachineVirtualCamera> virtualCameras) => _virtualCameras = virtualCameras;

    public void CameraSwitch()
    {
        foreach (CinemachineVirtualCamera camera in _virtualCameras)
            camera.Priority = _switchedOffCameraPriority;

        CinemachineVirtualCamera currentCamera = _virtualCameras.Dequeue();
        _virtualCameras.Enqueue(currentCamera);

        _virtualCameras.Peek().Priority = _currentCameraPriority;
    }
}
