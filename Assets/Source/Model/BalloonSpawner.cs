namespace Balloons.Model
{
    public class BalloonSpawner : Spawner<Balloon>
    {
        private readonly PlayerHealth _playerHealth;

        public BalloonSpawner(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }

        protected override float EntitiesPerSecond => Config.BalloonSpawnerSpeed;

        protected override Transformable SpawnEntity(BalloonType balloonType)
        {
            return new Balloon(balloonType, Config.StartBalloonSpeed * (1 + (new System.Random().Next(-Config.BalloonSpeedSpread, Config.BalloonSpeedSpread) / 100)) * (((multiplier - 1) / 3) + 1),
                                    new Position(System.Convert.ToSingle((new System.Random().NextDouble() * 2) - 1) * Config.GameFieldWidth, Config.UpGameFieldBorder), _playerHealth);
        }
    }
}
