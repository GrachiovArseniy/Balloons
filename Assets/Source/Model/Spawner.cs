using System;

namespace Balloons.Model
{
    public abstract class Spawner<T> : IUpdateable
    {
        public event Action<T> EntitySpawned;

        private Time _time;

        protected virtual float EntitiesPerSecond { get; private set; }

        protected float Multiplier = 1;
        private float _timeOut;

        public void SetTime(Time time)
        {
            _time = time;
        }

        internal override void Update(float deltaTime)
        {
            _timeOut += deltaTime;

            if (_timeOut > (1 / (EntitiesPerSecond * Multiplier)))
            {
                int balloonType = new Random().Next(1, 4);

                switch (balloonType)
                {
                    case 1:
                        Spawn(new LittleBalloon());
                        break;

                    case 2:
                        Spawn(new MediumBalloon());
                        break;

                    case 3:
                        Spawn(new BigBalloon());
                        break;
                }

                _timeOut = 0;
            }

            Multiplier += Config.SpawnerAcceleration;
        }

        private void Spawn(BalloonType balloonType)
        {
            Transformable newEntity = SpawnEntity(balloonType);
            _time.AddEntity(newEntity);

            EntitySpawned?.Invoke((dynamic)newEntity);
        }

        protected virtual Transformable SpawnEntity(BalloonType balloonType)
        {
            return null;
        }
    }
}
