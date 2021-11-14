using Balloons.Model;
using UnityEngine;

internal abstract class SpawnerPresenter<T> : MonoBehaviour
{
    protected GameObject _entityPrefab;
    private Spawner<T> _spawner;

    internal void Init(Spawner<T> spawner, GameObject entityPrefab)
    {
        _spawner = spawner;
        _entityPrefab = entityPrefab;
        enabled = true;
    }

    protected virtual void SpawnEntity(T entity) { }

    private void OnEnable()
    {
        _spawner.EntitySpawned += SpawnEntity;
    }

    private void OnDisable()
    {
        _spawner.EntitySpawned -= SpawnEntity;
    }
}