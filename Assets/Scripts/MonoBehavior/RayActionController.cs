using UnityEngine;

public class RayActionController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private ExplosionVFX _explosionVFX;

    [SerializeField] private LayerMask _groundMask;

    private ItemManipulator _itemManipulator;
    private ExplosionSpawner _explosionSpawner;
    private ExplosionForceEffect _explosionForceEffect;

    private float _manipulatorHeight = 2f;
    private float _explosionForce = 4f;
    private float _explosionRadius = 2f;

    private void Awake()
    {
        _itemManipulator = new ItemManipulator(_groundMask, _manipulatorHeight);
        _explosionForceEffect = new ExplosionForceEffect(_explosionForce, _explosionRadius);
        _explosionSpawner = new ExplosionSpawner(_explosionVFX, _explosionForceEffect);
    }
    private void Update()
    {
        if (_inputManager.CurrentAction == InputActionEnum.None)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (_inputManager.CurrentAction == InputActionEnum.LeftHold)
        {
            _itemManipulator.TryGrab(ray);
            _itemManipulator.Move(ray);
        }
            
        if (_inputManager.CurrentAction == InputActionEnum.LeftRelease)
        {
            _itemManipulator.Release();
        }

        if (_inputManager.CurrentAction == InputActionEnum.RightClick)
        {
            if (_itemManipulator.IsHoldingItem)
                return;
            _explosionSpawner.Execute(ray);
        }
    }
}
