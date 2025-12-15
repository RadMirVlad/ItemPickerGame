using UnityEngine;

public class CameraActionController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private CameraSwitcher _cameraSwitcher;

    private void Update()
    {
        if (_inputManager.CurrentAction != InputActionEnum.SwitchCamera)
            return;

        _cameraSwitcher.CameraSwitch();
    }
}
