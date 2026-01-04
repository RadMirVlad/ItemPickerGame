using UnityEngine;

public class ItemManipulator
{
    private IGrabable _heldItem;
    private LayerMask _groundMask;
    private float _heightAboveGround;

    public bool IsHoldingItem => _heldItem != null;

    public ItemManipulator(LayerMask groundMask, float heightAboveGround)
    {
        _groundMask = groundMask;
        _heightAboveGround = heightAboveGround;
    }

    public void TryGrab(Ray ray)
    {
        if (_heldItem != null)
            return;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<IGrabable>(out IGrabable grabable))
            {
                _heldItem = grabable;
                _heldItem.OnGrab();
            }
        }
    }

    public void Move(Ray ray)
    {
        if (_heldItem == null)
            return;

        if (Physics.Raycast(ray, out RaycastHit groundHit, Mathf.Infinity, _groundMask))
        {
            Vector3 targetPosition = ray.origin + ray.direction * (groundHit.distance - _heightAboveGround);
            _heldItem.Move(targetPosition);
        }
    }

    public void Release()
    {
        if (_heldItem == null)
            return;

        _heldItem.OnRelease();
        _heldItem = null;
    }
}
