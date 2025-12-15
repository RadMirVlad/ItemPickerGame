using UnityEngine;

public class ItemManipulator : MonoBehaviour, IRayAction
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _heightAboveGround = 2f;

    private Rigidbody _heldItem;
    public void Execute(CameraPointer cameraPointer)
    {
        if (cameraPointer.Hit.rigidbody == null)
            return;

        if (_heldItem == null)
        {
            _heldItem = cameraPointer.Hit.rigidbody;
            _heldItem.useGravity = false;
        }

        Ray cameraRay = cameraPointer.CameraRay;

        if(Physics.Raycast(cameraRay, out RaycastHit groundHit, Mathf.Infinity, _groundMask)) 
        {
            Vector3 targetPosition = cameraPointer.CameraRay.origin + cameraPointer.CameraRay.direction * (groundHit.distance - _heightAboveGround);
            _heldItem.MovePosition(targetPosition);
        }
    }

    public void Release()
    {
        if (_heldItem == null)
            return;

        _heldItem.velocity = Vector3.zero;
        _heldItem.useGravity = true;
        _heldItem = null;
    }
}
