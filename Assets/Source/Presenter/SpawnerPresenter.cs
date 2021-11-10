using Balloons.Model;
using UnityEngine;

internal abstract class SpawnerPresenter<T> : MonoBehaviour
{
    private Spawner<T> _spawner;
    protected GameObject _entityPrefab;

    internal void Init(Spawner<T> spawner, GameObject entityPrefab)
    {
        _spawner = spawner;
        _entityPrefab = entityPrefab;
        enabled = true;
    }

    private void OnEnable()
    {
        _spawner.EntitySpawned += SpawnEntity;
    }

    private void OnDisable()
    {
        _spawner.EntitySpawned -= SpawnEntity;
    }

    protected virtual void SpawnEntity(T entity) { }
}