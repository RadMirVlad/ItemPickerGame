using UnityEngine;

public class RayActionController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private CameraPointer _cameraPointer;
    [SerializeField] private ItemManipulator _itemManipulator;
    [SerializeField] private ExplosionSpawner _explosionSpawner;

    private void Update()
    {
        if (_inputManager.CurrentAction == InputActionEnum.None)
            return;
        if (_cameraPointer.ShootRay() == false)
            return;

        if (_inputManager.CurrentAction == InputActionEnum.LeftHold)
            _itemManipulator.Execute(_cameraPointer);
        if (_inputManager.CurrentAction == InputActionEnum.LeftRelease)
            _itemManipulator.Release();

        if (_inputManager.CurrentAction == InputActionEnum.RightClick)
        {
            _itemManipulator.Release();
            _explosionSpawner.Execute(_cameraPointer);
        }
    }
}
