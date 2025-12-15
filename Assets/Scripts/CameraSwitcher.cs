using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    private CinemachineBrain _cinemachineBrain;

    private void Awake()
    {
        _cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    public void CameraSwitch()
    {
        GetCinemachineVirtualCamera();

        foreach (CinemachineVirtualCamera virtualCamera in _virtualCameras)
        {
            if (virtualCamera.name == GetCinemachineVirtualCamera().name)
                virtualCamera.gameObject.SetActive(false);
            else
                virtualCamera.gameObject.SetActive(true);
        }
    }
    public GameObject GetCinemachineVirtualCamera() => _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject;
}
