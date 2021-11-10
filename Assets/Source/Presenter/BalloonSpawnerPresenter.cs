using Balloons.Model;

internal class BalloonSpawnerPresenter : SpawnerPresenter<Balloon>
{
    protected override void SpawnEntity(Balloon entity)
    {
        Instantiate(_entityPrefab).GetComponent<BalloonPresenter>().Init(entity, entity.Color, entity.Type);
    }
}
