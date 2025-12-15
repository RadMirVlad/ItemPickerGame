using UnityEngine;

public class ExplosionForceEffect : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    //[SerializeField] private LayerMask _itemLayer;

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
