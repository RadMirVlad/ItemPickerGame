using UnityEngine;

public class ExplosionSpawner
{
    private ExplosionForceEffect _explosionForceEffect;
    private ExplosionVFX _explosionVFX;

    public ExplosionSpawner(ExplosionVFX explosionVFX, ExplosionForceEffect explosionForceEffect)
    {
        _explosionVFX = explosionVFX;
        _explosionForceEffect = explosionForceEffect;
    }

    public void Execute(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit) == false)
            return;

        Vector3 position = hit.point;

        _explosionVFX.SpawnEffect(position);
        _explosionForceEffect.ExplosionExecute(position);
    }
}
