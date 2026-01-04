using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    [SerializeField] private Explosion _bangPrefab;
    private float _timeToDestroy = 1f;

    public void SpawnEffect(Vector3 position)
    {
        GameObject explosion = Instantiate(_bangPrefab.gameObject, position, Quaternion.identity, transform);
        Destroy(explosion, _timeToDestroy);
    }
}
