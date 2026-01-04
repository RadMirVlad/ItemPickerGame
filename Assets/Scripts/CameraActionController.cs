public class CameraActionController
{
    private InputManager _inputManager;
    private CameraSwitcher _cameraSwitcher;

    public CameraActionController(InputManager inputManager, CameraSwitcher cameraSwitcher)
    {
        _inputManager = inputManager;
        _cameraSwitcher = cameraSwitcher;
    }

    public void Update()
    {
        if (_inputManager.CurrentAction != InputActionEnum.SwitchCamera)
            return;

        _cameraSwitcher.CameraSwitch();
    }

}
