using UnityEngine;

public class Barrel : MonoBehaviour, IGrabable
{
    private Rigidbody _rigidbody;

    private float _rotationForce = 5f;
    private float _deadZone = 0.1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularDrag = 1f;
    } 

    public void Move(Vector3 position)
    {
        _rigidbody.useGravity = false;
        _rigidbody.MovePosition(position);

        Vector3 axis = Vector3.Cross(transform.up, Vector3.up);
        float error = axis.magnitude;

        if (error < _deadZone)
        {
            _rigidbody.angularVelocity = Vector3.zero;
            return;
        }
        _rigidbody.AddTorque(axis * _rotationForce, ForceMode.Acceleration);
    }

    public void OnGrab()
    {
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void OnRelease()
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
    }
}
