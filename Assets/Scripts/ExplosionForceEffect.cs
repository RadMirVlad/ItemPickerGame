using UnityEngine;

public class ExplosionForceEffect
{
    private float _explosionForce;
    private float _explosionRadius;

    public ExplosionForceEffect(float explosionForce, float explosionRadius)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }

    public void ExplosionExecute(Vector3 explosionPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody itemRigidbody = collider.GetComponent<Rigidbody>();
            if (itemRigidbody != null)
            {
                itemRigidbody.useGravity = true;
                itemRigidbody.velocity = Vector3.zero;

                itemRigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, 5f, ForceMode.Impulse);
            }
        }
    }
}
