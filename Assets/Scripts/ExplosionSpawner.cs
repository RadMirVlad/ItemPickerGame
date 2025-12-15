using UnityEngine;

public class ExplosionSpawner : MonoBehaviour, IRayAction
{
    [SerializeField] private Explosion _bangPrefab;
    [SerializeField] private ExplosionForceEffect _explosionForceEffect;

    private float _timeToDestroy = 1f;

    public void Execute(CameraPointer cameraPointer)
    {
        Vector3 position = cameraPointer.Hit.point;
        GameObject explosion = Instantiate(_bangPrefab.gameObject, position, Quaternion.identity, transform);
        _explosionForceEffect.ExplosionExecute(position);

        Destroy(explosion, _timeToDestroy);
    }
}
